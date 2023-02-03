using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace BookStoreApp.Screens
{
    public class SingleBookScreen
    {
        public bool addToCartButtonPressed = false;
        public bool backButtonPressed = false;

        private PictureBoxCLass bookPicture;
        private LabelClass title;
        private LabelClass autor;
        private LabelClass year;
        private LabelClass pages;
        private LabelClass price;
        private LabelClass loan;
        private ButtonClass addToCartButton;
        private ButtonClass backButton;

        private List<ButtonClass> buttonList;
        private List<LabelClass> labelList;

        public SingleBookScreen(int win_x, int win_y)
        {
            labelList = new List<LabelClass>();
            buttonList = new List<ButtonClass>();

            bookPicture = new PictureBoxCLass(win_x / 2 - 400, 70, 150, 200);
            bookPicture.GetObject().Visible = false;

            title = new LabelClass(win_x / 2, 70, "", 300, 50);
            title.GetObject().Font = UtilitiesClass.arial12Bold;
            title.GetObject().Visible = false;
            labelList.Add(title);

            autor = new LabelClass(win_x / 2, 170, "", 250, 50);
            autor.GetObject().Font = UtilitiesClass.arial12Regular;
            autor.GetObject().Visible = false;
            labelList.Add(autor);

            year = new LabelClass(win_x / 2, 220, "", 250, 50);
            year.GetObject().Font = UtilitiesClass.arial12Regular;
            year.GetObject().Visible = false;
            labelList.Add(year);

            pages = new LabelClass(win_x / 2, 270, "", 250, 50);
            pages.GetObject().Font = UtilitiesClass.arial12Regular;
            pages.GetObject().Visible = false;
            labelList.Add(pages);

            price = new LabelClass(win_x / 2, 320, "", 250, 50);
            price.GetObject().Font = UtilitiesClass.arial12Regular;
            price.GetObject().Visible = false;
            labelList.Add(price);

            loan = new LabelClass(win_x / 2, 370, "", 250, 50);
            loan.GetObject().Font = UtilitiesClass.arial12Regular;
            loan.GetObject().Visible = false;
            labelList.Add(loan);


            addToCartButton = new ButtonClass(win_x - 200, win_y - 200, 200, 50, "Add to cart");
            addToCartButton.GetObject().Click += new EventHandler(AddToCartClick);
            addToCartButton.GetObject().Font = UtilitiesClass.arial12Regular;
            addToCartButton.GetObject().Visible = false;
            buttonList.Add(addToCartButton);

            backButton = new ButtonClass(win_x - 200, win_y - 100, 200, 50, "Back");
            backButton.GetObject().Click += new EventHandler(backButtonClick);
            backButton.GetObject().Font = UtilitiesClass.arial12Regular;
            backButton.GetObject().Visible = false;
            buttonList.Add(backButton);
        }
        public void SetVisible(bool value)
        {
            if(value==true)
            {
                foreach (var i in buttonList)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in labelList)
                {
                    i.GetObject().Visible = true;
                }
                bookPicture.GetObject().Visible = true;
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
                bookPicture.GetObject().Visible = false;
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
        public PictureBoxCLass GetPictureObject()
        {
            return bookPicture;
        }
        public void SetParams(string titl, string aut, string yr, string pgs, string pri, string possibleToLoan, string imageName)
        {
            Bitmap picture = new Bitmap(Image.FromFile(UtilitiesClass.booksImagesDir + imageName), new Size(150, 200));
            bookPicture.GetObject().BackgroundImage = picture;
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
