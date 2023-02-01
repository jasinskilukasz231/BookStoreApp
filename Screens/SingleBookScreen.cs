using System;
using System.Windows.Forms;
using System.Drawing;

namespace BookStoreApp.Screens
{
    public class SingleBookScreen
    {
        public PictureBox bookPicture { get; set; }
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
            bookPicture = new PictureBox();
            bookPicture.Width = 150;
            bookPicture.Height = 200;
            bookPicture.Left = win_x / 2 - 400;
            bookPicture.Top = 70;
            bookPicture.Visible = false;
            title = new LabelClass(win_x / 2, 70, "", 300, 50);
            title.GetObject().Font = UtilitiesClass.arial12Bold;
            title.GetObject().Visible = false;
            autor = new LabelClass(win_x / 2, 170, "", 250, 50);
            autor.GetObject().Font = UtilitiesClass.arial12Regular;
            autor.GetObject().Visible = false;
            year = new LabelClass(win_x / 2, 220, "", 250, 50);
            year.GetObject().Font = UtilitiesClass.arial12Regular;
            year.GetObject().Visible = false;
            pages = new LabelClass(win_x / 2, 270, "", 250, 50);
            pages.GetObject().Font = UtilitiesClass.arial12Regular;
            pages.GetObject().Visible = false;
            price = new LabelClass(win_x / 2, 320, "", 250, 50);
            price.GetObject().Font = UtilitiesClass.arial12Regular;
            price.GetObject().Visible = false;
            loan = new LabelClass(win_x / 2, 370, "", 250, 50);
            loan.GetObject().Font = UtilitiesClass.arial12Regular;
            loan.GetObject().Visible = false;

            addToCart = new ButtonClass(win_x - 200, win_y - 200, 200, 50, "Add to cart");
            addToCart.GetObject().Click += new EventHandler(AddToCartClick);
            addToCart.GetObject().Font = UtilitiesClass.arial12Regular;
            addToCart.GetObject().Visible = false;
            backButton = new ButtonClass(win_x - 200, win_y - 100, 200, 50, "Back");
            backButton.GetObject().Click += new EventHandler(backButtonClick);
            backButton.GetObject().Font = UtilitiesClass.arial12Regular;
            backButton.GetObject().Visible = false;
        }

        public void SetParams(string titl, string aut, string yr, string pgs, string pri, string possibleToLoan, string imageName)
        {
            Bitmap picture = new Bitmap(Image.FromFile(UtilitiesClass.booksImagesDir + imageName), new Size(150, 200));
            bookPicture.BackgroundImage = picture;
            title.GetObject().Text = titl;
            autor.GetObject().Text = "Autor: " + aut;
            year.GetObject().Text = "Year: " + yr;
            pages.GetObject().Text = "Number of pages: " + pgs;
            price.GetObject().Text = "Price: " + pri;

            if(possibleToLoan == "False")
            {
                loan.GetObject().Text = "Book not possible to loan";
            }
            else if(possibleToLoan == "True")
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
