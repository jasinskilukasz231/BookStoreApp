using System;
using System.Collections.Generic;

namespace BookStoreApp.Screens
{
    public class CustomerAccountScreen
    {
        public bool cartButtonPressed { get; set; }
        public bool settingsButtonPressed { get; set; }
        public bool searchButtonPressed { get; set; }
        public bool logOutButtonPressed { get; set; }
        public ButtonClass cartButton { get; set; }
        public ButtonClass settingsButton { get; set; }
        public ButtonClass searchButton { get; set; }
        public ButtonClass logOutButton { get; set; }
        public TextBoxClass searchTextBox { get; set; }

        public List<ButtonClass> buttonsList = new List<ButtonClass>();
        public List<LabelClass> labelsList = new List<LabelClass>();
        public List<LabelClass> priceLabelsList = new List<LabelClass>();
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

            int topPositon = win_y - 500;
            for (int i = 0; i < 10; i++) //10->max books shown on one page
            {
                ButtonClass bookButton = new ButtonClass(win_x - 300, topPositon * (1 + i), 70, 70, "");
                bookButton.GetObject().Visible = false;

                LabelClass bookLabel = new LabelClass(win_x - 200, topPositon * (1 + i), "", 300, 70);
                bookLabel.GetObject().Visible = false;

                LabelClass bookPriceLabel = new LabelClass(win_x + 100, topPositon * (1 + i), "", 300, 70);
                bookPriceLabel.GetObject().Visible = false;

                buttonsList.Add(bookButton);
                labelsList.Add(bookLabel);
                priceLabelsList.Add(bookPriceLabel);
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
            DisplayBooks(SearchBook(searchTextBox.GetObject().Text));
        }
        private void logOutButtonClick(object sender, EventArgs e)
        {
            logOutButtonPressed = true;
        }
        private string SearchBook(string s)
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
                Console.WriteLine(ids);
                //SELECT books.id FROM books, tags_name, books_tags WHERE books_tags.id_book=books.id AND books_tags.id_tag=tags_name.id
                //AND tags_name.name LIKE(%i%)
                string query1 = "";
                ids += Database.FindMany(query1);
            }

            return UtilitiesClass.RemoveSameNumbers(ids);
        }
        private void DisplayBooks(string ids)
        {
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
            for (int i = 0; i < num; i++)//displaying
            {
                buttonsList[i].GetObject().BackgroundImage = 
                buttonsList[i].GetObject().Visible = true;
                labelsList[i].GetObject().Text = 
                labelsList[i].GetObject().Visible = true;
                priceLabelsList[i].GetObject().Text = 
                priceLabelsList[i].GetObject().Visible = true;
            }
            
        }

    }
}
