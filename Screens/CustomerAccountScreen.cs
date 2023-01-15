﻿using System;

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
            cartButton = new ButtonClass(win_x - 80, 60, 150, 50, "");

            cartButton.GetObject().Click += new EventHandler(CartButtonClick);


            settingsButton = new ButtonClass(win_x - 60, 80, 50, 50, "");

            settingsButton.GetObject().Click += new EventHandler(settingsButtonClick);


            searchButton = new ButtonClass(win_x/2, 60, 50, 50, "");

            searchButton.GetObject().Click += new EventHandler(searchButtonClick);


            searchTextBox = new TextBoxClass(win_x / 2 - 120, 60, 200);
            searchTextBox.GetObject().Font = UtilitiesClass.arial12Regular;


            logOutButton = new ButtonClass(win_x - 60, 150, 50, 50, "");

            logOutButton.GetObject().Click += new EventHandler(logOutButtonClick);
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
        }
        private void logOutButtonClick(object sender, EventArgs e)
        {
            logOutButtonPressed = true;
        }
    }
    
}
