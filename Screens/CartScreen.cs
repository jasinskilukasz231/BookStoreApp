using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BookStoreApp.Screens
{   
    public class CartScreen
    {
        public List<int> booksIdsInCart = new List<int>();
        public List<LabelClass> titles = new List<LabelClass>();
        public List<PictureBox> images = new List<PictureBox>();
        public List<LabelClass> prices = new List<LabelClass>();
        public List<TextBoxClass> numberField = new List<TextBoxClass>();

        public bool backButtonPressed = false;
        public bool orderButtonPressed = false;
        public ButtonClass backButton { get; set; }
        public ButtonClass orderButton { get; set; }
        public LabelClass headerLabel1 { get; set; }
        public LabelClass headerLabel2 { get; set; }
        public LabelClass headerLabel3 { get; set; }

        public CartScreen(int win_x, int win_y)
        {
            backButton = new ButtonClass(win_x - 200, win_y - 100, 200, 50, "Back");
            backButton.GetObject().Font = UtilitiesClass.arial12Regular;
            backButton.GetObject().Visible = false;
            backButton.GetObject().Click += new EventHandler(BackButtonClick);

            orderButton = new ButtonClass(win_x - 200, win_y - 200, 200, 50, "Order books");
            orderButton.GetObject().Font = UtilitiesClass.arial12Regular;
            orderButton.GetObject().Visible = false;
            orderButton.GetObject().Click += new EventHandler(OrderButtonClick);

            headerLabel1 = new LabelClass(230, 40, "Book", 100, 50);
            headerLabel1.GetObject().Font = UtilitiesClass.arial12Bold;
            headerLabel1.GetObject().Visible = false;

            headerLabel2 = new LabelClass(700, 40, "Price", 100, 50);
            headerLabel2.GetObject().Font = UtilitiesClass.arial12Bold;
            headerLabel2.GetObject().Visible = false;

            headerLabel3 = new LabelClass(820, 40, "Number", 100, 50);
            headerLabel3.GetObject().Font = UtilitiesClass.arial12Bold;
            headerLabel3.GetObject().Visible = false;
        }
        public void CreateCartScreen(int win_x, int win_y)
        {
            titles.Clear();
            images.Clear();
            prices.Clear();
            numberField.Clear();

            int startingPosY = 100;
            int gap = 70;
            string queryImage = "SELECT imageName FROM books WHERE id=";
            string queryTitle = "SELECT displayTitle FROM books WHERE id=";
            string queryPrice = "SELECT price FROM books WHERE id=";
            for (int i = 0; i < booksIdsInCart.Count; i++)
            {
                var image = new Bitmap(Image.FromFile(UtilitiesClass.booksImagesDir + Database.FindOneThing(queryImage + booksIdsInCart[i])), new Size(50, 65));
                var title = new LabelClass(300, startingPosY + (i * gap), Database.FindOneThing(queryTitle + booksIdsInCart[i]), 250, 50);
                title.GetObject().Font = UtilitiesClass.arial12Regular;
                var price = new LabelClass(700, startingPosY + (i * gap), Database.FindOneThing(queryPrice + booksIdsInCart[i]), 100, 50);
                price.GetObject().Font = UtilitiesClass.arial12Regular;
                var numberBox = new TextBoxClass(800, (startingPosY - 30) + (i * gap), 50);
                titles.Add(title);

                PictureBox pic = new PictureBox();
                pic.Left = 100;
                pic.Top = (startingPosY - 50) + (i * gap);
                pic.Width = 50;
                pic.Height = 65;
                pic.BackgroundImage = image;
                images.Add(pic);
                prices.Add(price);
                numberField.Add(numberBox);
            }
        }
        public void BackButtonClick(object sender, EventArgs e)
        {
            backButtonPressed = true;
        }
        public void OrderButtonClick(object sender, EventArgs e)
        {
            orderButtonPressed = true;
        }
    }
}
