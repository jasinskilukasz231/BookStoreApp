using System;

namespace BookStoreApp.Screens
{
    public class SingleBookScreen
    {
        public LabelClass title { get; set; }
        public LabelClass autor { get; set; }
        public LabelClass year { get; set; }
        public LabelClass pages { get; set; }
        public LabelClass price { get; set; }
        public LabelClass loan { get; set; }
        public ButtonClass addToCart { get; set; }
        public ButtonClass backButton { get; set; }

        public bool addToCartButtonPressed = false;
        public bool backButtonPressed = false;

        public SingleBookScreen(int win_x, int win_y)
        {
            title = new LabelClass(win_x / 2, 100, "", 250, 50);
            title.GetObject().Font = UtilitiesClass.arial24Bold;
            autor = new LabelClass(win_x / 2, 150, "Autor: ", 250, 50);
            autor.GetObject().Font = UtilitiesClass.arial12Regular;
            year = new LabelClass(win_x / 2, 200, "Year: ", 250, 50);
            year.GetObject().Font = UtilitiesClass.arial12Regular;
            pages = new LabelClass(win_x / 2, 250, "Number of pages: ", 250, 50);
            pages.GetObject().Font = UtilitiesClass.arial12Regular;
            price = new LabelClass(win_x / 2, 300, "Price: ", 250, 50);
            price.GetObject().Font = UtilitiesClass.arial12Regular;
            loan = new LabelClass(win_x / 2, 350, "", 250, 50);
            loan.GetObject().Font = UtilitiesClass.arial12Regular;

            addToCart = new ButtonClass(win_x - 200, win_y - 200, 200, 50, "Add to cart");
            addToCart.GetObject().Click += new EventHandler(AddToCartClick);
            addToCart.GetObject().Font = UtilitiesClass.arial12Regular;

            backButton = new ButtonClass(win_x - 200, win_y - 100, 200, 50, "Back");
            backButton.GetObject().Click += new EventHandler(backButtonClick);
            backButton.GetObject().Font = UtilitiesClass.arial12Regular;
        }

        public void SetParams(string titl, string aut, string yr, string pgs, string pri, string possibleToLoan)
        {
            title.GetObject().Text = titl;
            autor.GetObject().Text += aut;
            year.GetObject().Text += yr;
            pages.GetObject().Text += pgs;
            price.GetObject().Text += pri;

            if(possibleToLoan == "0")
            {
                loan.GetObject().Text = "Book not possible to loan";
            }
            else if(possibleToLoan == "1")
            {
                loan.GetObject().Text = "Book possible to loan";
            }
        }

        private void AddToCartClick(object sender, EventArgs e)
        {
            addToCartButtonPressed = true;
        }
        private void backButtonClick(object sender, EventArgs e)
        {
            backButtonPressed = true;
        }
    }
}
