using System;
using System.Collections.Generic;

namespace BookStoreApp.Screens
{   
    public class CartScreen
    {
        private List<SingleBook> books = new List<SingleBook>();
        private List<TextBoxClass> numberOfBooks = new List<TextBoxClass>();
        public ButtonClass backButton { get; set; }
        public ButtonClass orderButton { get; set; }
        
        public CartScreen(int win_x, int win_y)
        {
            backButton = new ButtonClass(win_x - 200, win_y - 100, 200, 50, "Back");
            backButton.GetObject().Font = UtilitiesClass.arial12Regular;
            backButton.GetObject().Visible = false;

            orderButton = new ButtonClass(win_x - 200, win_y - 200, 200, 50, "Order books");
            orderButton.GetObject().Font = UtilitiesClass.arial12Regular;
            orderButton.GetObject().Visible = false;
        }
        public void CreateCartScreen(int size)
        {
            //size->number of books in cart
            //SingleBook book = new SingleBook()
            //for (int i = 0; i < size; i++)
            //{
            //    books.Add()
            //}
        }
    }
}
