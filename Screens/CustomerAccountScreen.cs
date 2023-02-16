using System;
using System.Collections.Generic;
using System.Drawing;

namespace BookStoreApp.Screens
{
    public class CustomerAccountScreen
    {
        private List<string> booksIDs = new List<string>();
        private int number_of_books_on_page = 10;
        private int pageNumber = 1;
        public int buttonNumber = 10;//indicator of buttons
        public bool singleBookButtonPressed = false;
        public bool cartButtonPressed { get; set; }
        public bool settingsButtonPressed { get; set; }
        public bool searchButtonPressed { get; set; }
        public bool logOutButtonPressed { get; set; }

        private ButtonClass cartButton;
        private ButtonClass settingsButton;
        private ButtonClass searchButton;
        private ButtonClass logOutButton;
        private ButtonClass nextPageButton;
        private ButtonClass prevPageButton;
        private TextBoxClass searchTextBox;

        private List<ButtonClass> buttonList;
        private List<TextBoxClass> textBoxList;
        private List<SingleBook> singlePageBooksList;

        public CustomerAccountScreen(int win_x, int win_y)
        {
            textBoxList = new List<TextBoxClass>();
            buttonList = new List<ButtonClass>();

            cartButton = new ButtonClass(win_x - 150, 30, 50, 50, "");
            cartButton.GetObject().Click += new EventHandler(CartButtonClick);
            buttonList.Add(cartButton);

            settingsButton = new ButtonClass(win_x - 100, 30, 50, 50, "");
            settingsButton.GetObject().Click += new EventHandler(settingsButtonClick);
            buttonList.Add(settingsButton);

            searchButton = new ButtonClass(win_x / 2, 30, 50, 50, "");
            searchButton.GetObject().Click += new EventHandler(searchButtonClick);
            buttonList.Add(searchButton);

            logOutButton = new ButtonClass(win_x - 50, 30, 50, 50, "");
            logOutButton.GetObject().Click += new EventHandler(logOutButtonClick);
            buttonList.Add(logOutButton);

            nextPageButton = new ButtonClass(win_x - 200, win_y - 50, 170, 50, "Next Page");
            nextPageButton.GetObject().Font = UtilitiesClass.arial12Regular;
            nextPageButton.GetObject().Click += new EventHandler(nextPageButtonClick);
            buttonList.Add(nextPageButton);

            prevPageButton = new ButtonClass(200, win_y - 50, 170, 50, "Previous Page");
            prevPageButton.GetObject().Click += new EventHandler(prevPageButtonClick);
            prevPageButton.GetObject().Font = UtilitiesClass.arial12Regular;
            buttonList.Add(prevPageButton);

            cartButton.GetObject().BackgroundImage = UtilitiesClass.images["cart"];
            logOutButton.GetObject().BackgroundImage = UtilitiesClass.images["logout"];
            searchButton.GetObject().BackgroundImage = UtilitiesClass.images["search"];
            settingsButton.GetObject().BackgroundImage = UtilitiesClass.images["settings"];

            searchTextBox = new TextBoxClass(win_x / 2 - 130, 15, 200);
            searchTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            textBoxList.Add(searchTextBox);

            singlePageBooksList = new List<SingleBook>();

            int starting_pos_y = 100;
            int gap = 80;
            for (int i = 0; i < number_of_books_on_page; i++)
            {
                singlePageBooksList.Add(new SingleBook(300, starting_pos_y + gap * i));
            }

            singlePageBooksList[0].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks0);
            singlePageBooksList[1].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks1);
            singlePageBooksList[2].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks2);
            singlePageBooksList[3].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks3);
            singlePageBooksList[4].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks4);
            singlePageBooksList[5].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks5);
            singlePageBooksList[6].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks6);
            singlePageBooksList[7].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks7);
            singlePageBooksList[8].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks8);
            singlePageBooksList[9].GetButtonObj().GetObject().Click += new EventHandler(SinglePageBooks9);
        }
        public void SetVisible(bool value)
        {
            //clearing text
            searchTextBox.GetObject().Text = "";

            if (value == true)
            {
                foreach (var i in buttonList)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in textBoxList)
                {
                    i.GetObject().Visible = true;
                }
            }
            else
            {
                foreach (var i in buttonList)
                {
                    i.GetObject().Visible = false;
                }
                foreach (var i in textBoxList)
                {
                    i.GetObject().Visible = false;
                }
                foreach (var i in singlePageBooksList)
                {
                    i.GetButtonObj().GetObject().Visible = false;
                    i.GetTtleObj().GetObject().Visible = false;
                    i.GetPriceObj().GetObject().Visible = false;
                }
            }
        }
        public List<ButtonClass> GetButtonList()
        {
            return buttonList;
        }
        public List<TextBoxClass> GetTextBoxList()
        {
            return textBoxList;
        }
        public List<SingleBook> GetSinglePageBooksList()
        {
            return singlePageBooksList;
        }
        private void CartButtonClick(object sender, EventArgs e)
        {
            cartButtonPressed = true;
        }
        private void settingsButtonClick(object sender, EventArgs e)
        {
            settingsButtonPressed = true;
        }
        private void searchButtonClick(object sender, EventArgs e)
        {
            if (searchTextBox.GetObject().Text != "") 
            {
                searchButtonPressed = true;
                nextPageButton.GetObject().Visible = true;
                prevPageButton.GetObject().Visible = true;
                string[] idss = UtilitiesClass.RemoveSameNumbers(FindBooks(searchTextBox.GetObject().Text).Split(',')).Split(',');
                booksIDs.Clear();

                foreach (var i in idss)
                {
                    booksIDs.Add(i);
                }

                pageNumber = 1;
                AssignBooksData(pageNumber, booksIDs);
            }
        }
        private void logOutButtonClick(object sender, EventArgs e)
        {
            logOutButtonPressed = true;
        }
        private void nextPageButtonClick(object sender, EventArgs e)
        {
            pageNumber++;
        }
        private void prevPageButtonClick(object sender, EventArgs e)
        {
            pageNumber--;
        }
        private string FindBooks(string s)
        {
            //function based on string which contains tags or names, shows books containing this tag
            //function returns id of books that should be shown

            //searching assumptions:
            //1.user can find book by name or part of the name
            //2.user can find book by tag or part of the tag

            //example string: morderstwo, salems lot, thedavincicode, XXI, book""12(()),

            string[] tags = UtilitiesClass.ClearString(s).Split('+');
            string ids = "";

            foreach (var i in tags)
            {
                string query = "SELECT id FROM books WHERE title LIKE(" + UtilitiesClass.quoteSign
                    + "%" + i + "%" + UtilitiesClass.quoteSign + ")";
                ids += Database.FindMany(query);

                string query1 = "SELECT books.id FROM books, tag_name, books_tags WHERE books_tags.id_tag =" +
                "tag_name.id AND books_tags.id_book = books.id AND tag_name.name LIKE(" + UtilitiesClass.quoteSign + "%" +
                i + "%" + UtilitiesClass.quoteSign + ")";    
                ids += Database.FindMany(query1);

                string query2 = "SELECT id FROM books WHERE autor LIKE(" + UtilitiesClass.quoteSign
                    + "%" + i + "%" + UtilitiesClass.quoteSign + ")";
                ids += Database.FindMany(query2);
            }

            return ids;
        }
        private void AssignBooksData(int pageNr, List<string> booksIds)
        {
            if (booksIds.Count >= pageNr * number_of_books_on_page)
            {
                //assign 10 books, begining (pageNumber - 1) * 10
                for (int i = (pageNumber - 1) * number_of_books_on_page; i < pageNumber * number_of_books_on_page - 1; i++)
                {
                    if (booksIds[i] != "")
                    {
                        string title_query = Database.FindOneThing("SELECT displayTitle FROM books WHERE id=" + booksIds[i]);
                        string price_query = Database.FindOneThing("SELECT price FROM books WHERE id=" + booksIds[i]);

                        string imageDir = UtilitiesClass.booksImagesDir + Database.FindOneThing("SELECT imageName FROM books WHERE id=" + booksIds[i]);
                        Bitmap image = new Bitmap(Image.FromFile(imageDir), new Size(70, 70));

                        singlePageBooksList[i].setParams(int.Parse(booksIds[i]), image, title_query, price_query);
                        singlePageBooksList[i].setVisible(true);
                    }
                }
            }
            else if (booksIds.Count < pageNr * number_of_books_on_page)
            {
                if (booksIds.Count > (pageNr - 1) * number_of_books_on_page)
                {

                    for (int i = 0; i < number_of_books_on_page; i++)
                    {
                        singlePageBooksList[i].setVisible(false);
                    }
                    //assign books beggining (pageNumber - 1) * 10, end size - 1
                    for (int i = (pageNumber - 1) * number_of_books_on_page; i < booksIds.Count - 1; i++)
                    {
                        if (booksIds[i] != "")
                        {
                            string title_query = Database.FindOneThing("SELECT displayTitle FROM books WHERE id=" + booksIds[i]);
                            string price_query = Database.FindOneThing("SELECT price FROM books WHERE id=" + booksIds[i]);

                            string imageDir = UtilitiesClass.booksImagesDir + Database.FindOneThing("SELECT imageName FROM books WHERE id=" + booksIds[i]);
                            Bitmap image = new Bitmap(Image.FromFile(imageDir), new Size(70, 70));

                            singlePageBooksList[i].setParams(int.Parse(booksIds[i]), image, title_query, price_query);
                            singlePageBooksList[i].setVisible(true);
                        }
                    }
                }
                else
                {
                    nextPageButton.GetObject().Enabled = false;
                    //make next page button dissabled
                }
            }
        }
        public int ReturnButtonNumber()
        {
            return buttonNumber;
        }
        private void SinglePageBooks0(Object sender, EventArgs e)
        {
            buttonNumber = 0;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks1(Object sender, EventArgs e)
        {
            buttonNumber = 1;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks2(Object sender, EventArgs e)
        {
            buttonNumber = 2;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks3(Object sender, EventArgs e)
        {
            buttonNumber = 3;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks4(Object sender, EventArgs e)
        {
            buttonNumber = 4;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks5(Object sender, EventArgs e)
        {
            buttonNumber = 5;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks6(Object sender, EventArgs e)
        {
            buttonNumber = 6;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks7(Object sender, EventArgs e)
        {
            buttonNumber = 7;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks8(Object sender, EventArgs e)
        {
            buttonNumber = 8;
            singleBookButtonPressed = true;
        }
        private void SinglePageBooks9(Object sender, EventArgs e)
        {
            buttonNumber = 9;
            singleBookButtonPressed = true;
        }
    }
}
