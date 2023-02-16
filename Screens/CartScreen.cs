using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BookStoreApp.Screens
{   
    public class CartScreen
    {
        public bool backButtonPressed = false;
        public bool orderButtonPressed = false;

        private List<int> booksIdsInCart = new List<int>();
        private List<LabelClass> titles = new List<LabelClass>();
        private List<PictureBoxCLass> images = new List<PictureBoxCLass>();
        private List<LabelClass> prices = new List<LabelClass>();
        private List<TextBoxClass> numberField = new List<TextBoxClass>();
        private ButtonClass backButton;
        private ButtonClass orderButton;
        private LabelClass headerLabel1;
        private LabelClass headerLabel2;
        private LabelClass headerLabel3;

        private List<ButtonClass> buttonList;
        private List<LabelClass> labelList;

        public CartScreen(int win_x, int win_y)
        {
            labelList = new List<LabelClass>();
            buttonList = new List<ButtonClass>();

            backButton = new ButtonClass(win_x - 200, win_y - 100, 200, 50, "Back");
            backButton.GetObject().Font = UtilitiesClass.arial12Regular;
            backButton.GetObject().Visible = false;
            backButton.GetObject().Click += new EventHandler(BackButtonClick);
            buttonList.Add(backButton);

            orderButton = new ButtonClass(win_x - 200, win_y - 200, 200, 50, "Order books");
            orderButton.GetObject().Font = UtilitiesClass.arial12Regular;
            orderButton.GetObject().Visible = false;
            orderButton.GetObject().Click += new EventHandler(OrderButtonClick);
            buttonList.Add(orderButton);

            headerLabel1 = new LabelClass(230, 40, "Book", 100, 50);
            headerLabel1.GetObject().Font = UtilitiesClass.arial12Bold;
            headerLabel1.GetObject().Visible = false;
            labelList.Add(headerLabel1);

            headerLabel2 = new LabelClass(700, 40, "Price", 100, 50);
            headerLabel2.GetObject().Font = UtilitiesClass.arial12Bold;
            headerLabel2.GetObject().Visible = false;
            labelList.Add(headerLabel2);

            headerLabel3 = new LabelClass(820, 40, "Number", 100, 50);
            headerLabel3.GetObject().Font = UtilitiesClass.arial12Bold;
            headerLabel3.GetObject().Visible = false;
            labelList.Add(headerLabel3);
        }
        public List<int> GetBooksIdsInCartList()
        {
            return booksIdsInCart;
        }
        public void SetVisible(bool value)
        {
            if (value == true)
            {
                foreach (var i in buttonList)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in labelList)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in titles)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in images)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in prices)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in numberField)
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
                foreach (var i in labelList)
                {
                    i.GetObject().Visible = false;
                }
                foreach (var i in titles)
                {
                    i.GetObject().Visible = false;
                }
                foreach (var i in images)
                {
                    i.GetObject().Visible = false;
                }
                foreach (var i in prices)
                {
                    i.GetObject().Visible = false;
                }
                foreach (var i in numberField)
                {
                    i.GetObject().Visible = false;
                }
            }
        }
        public List<ButtonClass> GetButtonList()
        {
            return buttonList;
        }
        public List<LabelClass> GetLabelList()
        {
            return labelList;
        }
        public List<LabelClass> GetTitlesList()
        {
            return titles;
        }
        public List<PictureBoxCLass> GetImagesList()
        {
            return images;
        }
        public List<LabelClass> GetPricesList()
        {
            return prices;
        }
        public List<TextBoxClass> GetTextBoxList()
        {
            return numberField;
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

                PictureBoxCLass pic = new PictureBoxCLass(100, (startingPosY - 75) + (i * gap), 50, 65);
                pic.GetObject().BackgroundImage = image;
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
