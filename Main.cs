using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class WindowFrame : Form
    {
        public const int win_x = 1262, win_y = 673; //size of the window
        private int whatToRender = 1; //variable that tells which screen should be rendered
        //big screens only
        //0->nothing
        //1->init all screens
        //2->starting screen
        //3->register screen
        //4->customer account screen

        Screens.StartingScreen startingScreen;
        Screens.RegisterScreen registerScreen;
        Screens.RegisterInfoScreen registerInfoScreen;
        Screens.CustomerAccountScreen customerAccountScreen;
        Screens.SingleBookScreen singleBookScreen;
        Screens.CartScreen cartScreen;
        Screens.SettingsScreen settingsScreen;

        Timer appTimer = new Timer();
        int showInfoTimer = 0;

        public WindowFrame()
        {
            InitResources();
            InitializeComponent();
        }
        private void InitResources()
        {
            appTimer.Enabled = true;
            appTimer.Start();
            appTimer.Tick += new EventHandler(AppRunning);
        }
        private void AppRunning(object sender, EventArgs e)
        {
            switch (whatToRender)
            {
                case 1: //inits
                    InitScreens();
                    AddToControls();
                    whatToRender = 0;
                    break;
                    //here are every possibilities, for example: program can show starting screen at first, after customer account screen(log out button)
                case 2: //show starting screen
                    startingScreen.ClearTextBoxes();
                    registerInfoScreen.SetVisible(false);
                    startingScreen.SetVisible(true);
                    customerAccountScreen.SetVisible(false);
                    whatToRender = 0;
                    break;
                case 3: //show register screen
                    startingScreen.SetVisible(false);
                    registerScreen.SetVisible(true);
                    whatToRender = 0;
                    break;
                case 4: //show customer account screen
                    startingScreen.SetVisible(false);
                    customerAccountScreen.SetVisible(true);
                    settingsScreen.SetVisible(false);
                    cartScreen.SetVisible(false);
                    singleBookScreen.SetVisible(false);
                    whatToRender = 0;
                    break;
                case 5: //register info screen
                    registerScreen.SetVisible(false);
                    registerInfoScreen.SetVisible(true);
                    showInfoTimer++;
                    if(showInfoTimer>=60)//register info screen time
                    {
                        whatToRender = 4;
                        registerInfoScreen.SetVisible(false);
                        showInfoTimer = 0;
                    }
                    break;
                case 6://cart screen
                    customerAccountScreen.SetVisible(false);
                    cartScreen.SetVisible(true);
                    whatToRender = 0;
                    break;
                case 7: //settings screen
                    customerAccountScreen.SetVisible(false);
                    settingsScreen.SetVisible(true);
                    whatToRender = 0;
                    break;
                case 8: //single book screen
                    customerAccountScreen.SetVisible(false);
                    singleBookScreen.SetVisible(true);
                    whatToRender = 0;
                    break;
                default: 
                    //starting screen
                    if (startingScreen.startingScreenRegisterButtonPressed==true)
                    {
                        whatToRender = 3;
                        startingScreen.startingScreenRegisterButtonPressed = false; 
                    }
                    if (startingScreen.logged == true)
                    {
                        startingScreen.logged = false;
                        whatToRender = 4;
                    }
                    //register screen
                    if(registerScreen.registered==true)
                    {
                        registerScreen.registered = false;
                        whatToRender = 5;
                    }

                    //customerAccount screen
                    if (customerAccountScreen.logOutButtonPressed == true)
                    {
                        customerAccountScreen.logOutButtonPressed = false;
                        whatToRender = 2;
                    }
                    if (customerAccountScreen.settingsButtonPressed == true)
                    {
                        customerAccountScreen.settingsButtonPressed = false;
                        whatToRender = 7;
                    }
                    if (customerAccountScreen.cartButtonPressed == true) 
                    {
                        customerAccountScreen.cartButtonPressed = false;
                        cartScreen.CreateCartScreen(win_x, win_y);
                        AddCartScreenItemsToControls();
                        whatToRender = 6;
                    }
                    //single book screen
                    if(customerAccountScreen.singleBookButtonPressed==true)
                    {
                        customerAccountScreen.singleBookButtonPressed = false;
                        string query = "SELECT displayTitle, autor, year, nr_pages, price, possible_to_loan, imageName FROM books WHERE id=" +
                            customerAccountScreen.GetSinglePageBooksList()[customerAccountScreen.buttonNumber].bookId;
                        string[] data = Database.FindBookData(query);
                        singleBookScreen.SetParams(data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
                        whatToRender = 8;
                    }
                    if(singleBookScreen.backButtonPressed==true)
                    {
                        singleBookScreen.backButtonPressed = false;
                        whatToRender = 4;
                    }
                    if(singleBookScreen.addToCartButtonPressed==true)
                    {
                        singleBookScreen.addToCartButtonPressed = false;
                        if(customerAccountScreen.ReturnButtonNumber()!=10)
                        {
                            //if add to cart button is pressed
                            //add to booksIds
                            //check id of book that hides on certain button 
                            cartScreen.GetBooksIdsInCartList().Add(customerAccountScreen.GetSinglePageBooksList()[customerAccountScreen.buttonNumber].bookId);
                            customerAccountScreen.buttonNumber = 10;
                        }
                        MessageBox.Show("Book added to cart");
                    }
                    //cart screen
                    if(cartScreen.backButtonPressed==true)
                    {
                        cartScreen.backButtonPressed = false;
                        whatToRender = 4;
                    }
                    if (cartScreen.orderButtonPressed == true)
                    {
                        cartScreen.orderButtonPressed = false;
                    }
                    break;
            }
        }
        private void InitScreens()
        {
            UtilitiesClass.LoadImages();

            startingScreen = new Screens.StartingScreen(win_x, win_y);
            startingScreen.SetVisible(true);
            registerScreen = new Screens.RegisterScreen(win_x, win_y);
            registerScreen.SetVisible(false);
            customerAccountScreen = new Screens.CustomerAccountScreen(win_x, win_y);
            customerAccountScreen.SetVisible(false);
            registerInfoScreen = new Screens.RegisterInfoScreen(win_x, win_y);
            registerInfoScreen.SetVisible(false);
            settingsScreen = new Screens.SettingsScreen(win_x, win_y);
            settingsScreen.SetVisible(false);
            singleBookScreen = new Screens.SingleBookScreen(win_x, win_y);
            singleBookScreen.SetVisible(false);
            cartScreen = new Screens.CartScreen(win_x, win_y);
            cartScreen.SetVisible(false);
        }
        private void AddToControls()
        {
            //starting screen
            foreach (var i in startingScreen.GetButtonList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in startingScreen.GetTextBoxList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in startingScreen.GetLabelList())
            {
                Controls.Add(i.GetObject());
            }
            Controls.Add(startingScreen.GetWrongDataLabel().GetObject());

            //register screen
            foreach (var i in registerScreen.GetButtonList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in registerScreen.GetTextBoxList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in registerScreen.GetLabelList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in registerScreen.GetCheckBoxList())
            {
                Controls.Add(i.GetObject());
            }
            //register info screen
            Controls.Add(registerInfoScreen.getLabel().GetObject());

            //customers accont screen 
            foreach (var i in customerAccountScreen.GetButtonList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in customerAccountScreen.GetTextBoxList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in customerAccountScreen.GetSinglePageBooksList())
            {
                Controls.Add(i.GetButtonObj().GetObject());
                Controls.Add(i.GetTtleObj().GetObject());
                Controls.Add(i.GetPriceObj().GetObject());
            }

            //single book screen
            foreach (var i in singleBookScreen.GetButtonList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in singleBookScreen.GetLabelList())
            {
                Controls.Add(i.GetObject());
            }
            Controls.Add(singleBookScreen.GetPictureObject().GetObject());

            //cart screen
            foreach (var i in cartScreen.GetButtonList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in cartScreen.GetLabelList())
            {
                Controls.Add(i.GetObject());
            }
        }
        private void AddCartScreenItemsToControls()
        {
            foreach (var i in cartScreen.GetTitlesList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in cartScreen.GetImagesList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in cartScreen.GetPricesList())
            {
                Controls.Add(i.GetObject());
            }
            foreach (var i in cartScreen.GetTextBoxList())
            {
                Controls.Add(i.GetObject());
            }
        }
    }
}
