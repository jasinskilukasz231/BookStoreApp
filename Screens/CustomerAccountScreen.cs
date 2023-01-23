using System;
using System.Collections.Generic;
using System.Drawing;

namespace BookStoreApp.Screens
{
    public class CustomerAccountScreen
    {
        public int numberOfBooks = 0;
        public string booksIDs = "";
        private int number_of_books_on_page = 10;
        public bool cartButtonPressed { get; set; }
        public bool settingsButtonPressed { get; set; }
        public bool searchButtonPressed { get; set; }
        public bool logOutButtonPressed { get; set; }
        public ButtonClass cartButton { get; set; }
        public ButtonClass settingsButton { get; set; }
        public ButtonClass searchButton { get; set; }
        public ButtonClass logOutButton { get; set; }
        public TextBoxClass searchTextBox { get; set; }
        List<SingleBook> singlePageBooks = new List<SingleBook>();

        public void CreateCustomerAccountScreen(int win_x, int win_y)
        {
            cartButton = new ButtonClass(win_x - 150, 30, 50, 50, "");
            cartButton.GetObject().Click += new EventHandler(CartButtonClick);


            settingsButton = new ButtonClass(win_x - 100, 30, 50, 50, "");
            settingsButton.GetObject().Click += new EventHandler(settingsButtonClick);


            searchButton = new ButtonClass(win_x / 2, 30, 50, 50, "");
            searchButton.GetObject().Click += new EventHandler(searchButtonClick);

            logOutButton = new ButtonClass(win_x - 50, 30, 50, 50, "");
            logOutButton.GetObject().Click += new EventHandler(logOutButtonClick);

            cartButton.GetObject().BackgroundImage = UtilitiesClass.images["cart"];
            logOutButton.GetObject().BackgroundImage = UtilitiesClass.images["logout"];
            searchButton.GetObject().BackgroundImage = UtilitiesClass.images["search"];
            settingsButton.GetObject().BackgroundImage = UtilitiesClass.images["settings"];

            searchTextBox = new TextBoxClass(win_x / 2 - 130, 15, 200);
            searchTextBox.GetObject().Font = UtilitiesClass.arial12Regular;

            int starting_pos_y = 70;
            for (int i = 0; i < number_of_books_on_page; i++)
            {
                singlePageBooks.Add(new SingleBook(200, starting_pos_y * (i + 1)));
            }
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
            searchButtonPressed = true;
            booksIDs = SearchBooks(searchTextBox.GetObject().Text);
        }
        private void logOutButtonClick(object sender, EventArgs e)
        {
            logOutButtonPressed = true;
        }
        private string SearchBooks(string s)
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
            }

            return ids;
        }
        private  SplitBooks(Dictionary<string, Image> images, IEnumerable<string> titles, IEnumerable<string> prices)
        {
            //TODO pierwsza ma byc wyswietlana ksiazka ktora ma najwiecej liter
            //czyli policzyc cyfry w stringu i wyswietlic tylko te unikalne czyli nie wyswietlac dwa razy numeru 2
            int num = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == ',') num++; //counting numbers
            }

            for (int i = 0; i < 10; i++)//clearing all objects
            {
                buttonsList[i].GetObject().BackgroundImage = null;
                buttonsList[i].GetObject().Visible = false;
                labelsList[i].GetObject().Text = "";
                labelsList[i].GetObject().Visible = false;
                priceLabelsList[i].GetObject().Text = "";
                priceLabelsList[i].GetObject().Visible = false;
            }
            string[] seperatedIDs = ids.Split(',');
            for (int i = 0; i < num; i++)//displaying
            {
                //buttonsList[i].GetObject().BackgroundImage = 
                //buttonsList[i].GetObject().Visible = true;
                //labelsList[i].GetObject().Text = Database.FindOneThing()
                //labelsList[i].GetObject().Visible = true;
                //priceLabelsList[i].GetObject().Text = Database.FindOneThing("SELECT price FROM books WHERE id=" + UtilitiesClass.quoteSign +
                //    seperatedIDs[i] + UtilitiesClass.quoteSign);
                //priceLabelsList[i].GetObject().Visible = true;
            }
            
        }

    }
}
