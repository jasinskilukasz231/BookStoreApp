using System;

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
        public ButtonClass bookButton { get; set; } 
        public LabelClass bookLabel { get; set; }
        public LabelClass bookPriceLabel { get; set; }
        public void CreateCustomerAccountScreen(int win_x, int win_y)
        {
            cartButton = new ButtonClass(win_x - 150, 30, 50, 50, "");
            cartButton.GetObject().Click += new EventHandler(CartButtonClick);


            settingsButton = new ButtonClass(win_x - 100, 30, 50, 50, "");
            settingsButton.GetObject().Click += new EventHandler(settingsButtonClick);


            searchButton = new ButtonClass(win_x/2, 30, 50, 50, "");
            searchButton.GetObject().Click += new EventHandler(searchButtonClick);

            logOutButton = new ButtonClass(win_x - 50, 30, 50, 50, "");
            logOutButton.GetObject().Click += new EventHandler(logOutButtonClick);

            cartButton.GetObject().BackgroundImage = UtilitiesClass.images["cart"];
            logOutButton.GetObject().BackgroundImage = UtilitiesClass.images["logout"];
            searchButton.GetObject().BackgroundImage = UtilitiesClass.images["search"];
            settingsButton.GetObject().BackgroundImage = UtilitiesClass.images["settings"];

            searchTextBox = new TextBoxClass(win_x / 2 - 130, 15, 200);
            searchTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
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
            SearchBook(searchTextBox.GetObject().Text);
        }
        private void logOutButtonClick(object sender, EventArgs e)
        {
            logOutButtonPressed = true;
        }
        private string SearchBook(string tags)
        {
            //function based on string which contains tags or names, shows books containing this tag
            //function returns id of books that should be shown

            //searching assumptions:
            //1.user can find book by name or part of the name
            //2.user can find book by tag or part of the tag

            //example string: morderstwo, salems lot, thedavincicode, XXI, book""12(()),

            string tagsCleared = ClearString(tags);

            
            return tags;
        }
        private string ClearString(string s)
        {
            //isolating key words from the string:
            //adding + as a seperator
            //lowering all signs
            //removing not letters and not numbers

            string new_s = "";
            string stringReady = "";
            foreach (char i in s)
            {
                if (i == ' ') new_s += "+";
                else new_s += Char.ToLower(i);
            }
            for (int i = 0; i < new_s.Length; i++)
            {
                if (new_s[i] != '+')
                {
                    if (Char.IsLetterOrDigit(new_s[i]))
                    {
                        stringReady += new_s[i];
                    }
                }
                else
                {
                    stringReady += "+";
                }
            }

            return stringReady;
        }
    }
    
}
