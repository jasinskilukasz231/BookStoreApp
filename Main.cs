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
        const int win_x = 1262, win_y = 673; //size of the window
        int whatToRender = 1; //variable that tells which screen should be rendered
        //0->nothing
        //1->init all screens
        //2->starting screen
        //3->register screen

        //change this 
        Screens.StartingScreen startingScreen = new Screens.StartingScreen();
        Screens.RegisterScreen registerScreen = new Screens.RegisterScreen();
        Screens.RegisterInfoScreen registerInfoScreen = new Screens.RegisterInfoScreen();
        Screens.CustomerAccountScreen customerAccountScreen = new Screens.CustomerAccountScreen();
        Screens.SingleBookScreen singleBookScreen;
        Screens.CartScreen cartScreen;

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
                    InitStartingScreen();
                    InitRegisterScreen();
                    UtilitiesClass.LoadImages();
                    InitCustomerAccountScreen();
                    ShowStartingScreen();
                    HideRegisterScreen();
                    HideCustomerAccountScreen();
                    singleBookScreen = new Screens.SingleBookScreen(win_x, win_y);
                    cartScreen = new Screens.CartScreen(win_x, win_y);
                    AddToControls();
                    whatToRender = 0;
                    break;
                case 2: //show starting screen
                    ShowStartingScreen();
                    HideRegisterScreen();
                    whatToRender = 0;
                    break;
                case 3: //show register screen
                    ShowRegisterScreen();
                    HideStartingScreen();
                    whatToRender = 0;
                    break;
                case 4: //show customer account screen
                    HideStartingScreen();
                    ShowCustomerAccountScreen();
                    whatToRender = 0;
                    break;
                case 5: //info screen
                    registerInfoScreen.infoLabel.GetObject().Visible = true;
                    showInfoTimer++;
                    if(showInfoTimer>=60)
                    {
                        whatToRender = 4;
                        showInfoTimer = 0;
                        registerInfoScreen.infoLabel.GetObject().Visible = false;
                    }
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
                    if (startingScreen.showWrongDataInfo == true)
                    {
                        startingScreen.showWrongDataInfo = false;
                        startingScreen.StartingScreenWrongDataLabel.GetObject().Visible = true;
                    }
                    //register screen
                    if (registerScreen.registerButtonPressed == true) 
                    {
                        registerScreen.registerButtonPressed = false;
                        if(registerScreen.Register()=="missingData")
                        {
                            MessageBox.Show("Please enter all required data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if(registerScreen.Register()== "wrongPasswordLogin")
                        {
                            MessageBox.Show("Password or login is too long or too short", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (registerScreen.Register() == "loginTaken")
                        {
                            MessageBox.Show("Your login is taken", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else //registered
                        {
                            whatToRender = 5;
                            registerInfoScreen.createInfoScreen(win_x, win_y);
                            HideRegisterScreen();
                        }
                    }
                    //customerAccount screen
                    if (customerAccountScreen.logOutButtonPressed == true)
                    {
                        HideCustomerAccountScreen();
                        ShowStartingScreen();
                        startingScreen.StartingScreenTextBoxLogin.GetObject().Text = "";
                        startingScreen.StartingScreenTextBoxPassword.GetObject().Text = "";
                        customerAccountScreen.logOutButtonPressed = false;
                    }
                    if (customerAccountScreen.settingsButtonPressed == true)
                    {
                        HideCustomerAccountScreen();
                        ShowSettingsScreen();
                        customerAccountScreen.settingsButtonPressed = false;
                    }
                    if (customerAccountScreen.cartButtonPressed == true) 
                    {
                        customerAccountScreen.cartButtonPressed = true;
                        HideCustomerAccountScreen();
                        ShowCartScreen();
                    }
                    //single book screen
                    if(customerAccountScreen.singleBookButtonPressed==true)
                    {
                        customerAccountScreen.singleBookButtonPressed = false;
                        string query = "SELECT displayTitle, autor, year, pages, price, possibleToLoan FROM books WHERE id=" +
                            customerAccountScreen.singlePageBooks[customerAccountScreen.buttonNumber].bookId;
                        string[] data = Database.FindBookData(query);
                        singleBookScreen.SetParams(data[0], data[1], data[2], data[3], data[4], data[5]);
                        ShowSingleBookScreen();
                    }
                    if(singleBookScreen.backButtonPressed==true)
                    {
                        singleBookScreen.backButtonPressed = false;
                        HideSingleBookScreen();
                        ShowCustomerAccountScreen();
                    }
                    if(singleBookScreen.addToCartButtonPressed==true)
                    {
                        singleBookScreen.addToCartButtonPressed = false;
                        MessageBox.Show("Book added to cart");
                    }
                    break;
            }
        }
        private void InitStartingScreen()
        {
            startingScreen.CreateStartingScreen(win_x, win_y);
            Controls.Add(startingScreen.StartingScreenRegisterButton.GetObject());
            Controls.Add(startingScreen.StartingScreenStafLoginButton.GetObject());
            Controls.Add(startingScreen.StartingScreenLoginButton.GetObject());
            Controls.Add(startingScreen.StartingScreenTextBoxLogin.GetObject());
            Controls.Add(startingScreen.StartingScreenTextBoxPassword.GetObject());
            Controls.Add(startingScreen.StartingScreenLoginLabel.GetObject());
            Controls.Add(startingScreen.StartingScreenPasswordLabel.GetObject());
            Controls.Add(startingScreen.StartingScreenWrongDataLabel.GetObject());
        }
        private void HideStartingScreen()
        {
            startingScreen.StartingScreenRegisterButton.GetObject().Visible = false;
            startingScreen.StartingScreenStafLoginButton.GetObject().Visible = false;
            startingScreen.StartingScreenLoginButton.GetObject().Visible = false;
            startingScreen.StartingScreenTextBoxLogin.GetObject().Visible = false;
            startingScreen.StartingScreenTextBoxPassword.GetObject().Visible = false;
            startingScreen.StartingScreenLoginLabel.GetObject().Visible = false;
            startingScreen.StartingScreenPasswordLabel.GetObject().Visible = false;
            startingScreen.StartingScreenWrongDataLabel.GetObject().Visible = false;
        }
        private void ShowStartingScreen()
        {
            startingScreen.StartingScreenRegisterButton.GetObject().Visible = true;
            startingScreen.StartingScreenStafLoginButton.GetObject().Visible = true;
            startingScreen.StartingScreenLoginButton.GetObject().Visible = true;
            startingScreen.StartingScreenTextBoxLogin.GetObject().Visible = true;
            startingScreen.StartingScreenTextBoxPassword.GetObject().Visible = true;
            startingScreen.StartingScreenLoginLabel.GetObject().Visible = true;
            startingScreen.StartingScreenPasswordLabel.GetObject().Visible = true;
        }
        private void InitRegisterScreen()
        {
            registerScreen.CreateRegisterScreen(win_x,win_y);
            Controls.Add(registerScreen.RegisterScreenRegisterButton.GetObject());
            Controls.Add(registerScreen.RegisterScreenNameTextBox.GetObject());
            Controls.Add(registerScreen.RegisterScreenLastNameTextBox.GetObject());
            Controls.Add(registerScreen.RegisterScreenEmailTextBox.GetObject());
            Controls.Add(registerScreen.RegisterScreenPhoneTextBox.GetObject());
            Controls.Add(registerScreen.RegisterScreenAddressTextBox.GetObject());
            Controls.Add(registerScreen.RegisterScreenLoginTextBox.GetObject());
            Controls.Add(registerScreen.RegisterScreenPasswordTextBox.GetObject());
            Controls.Add(registerScreen.RegisterScreenNameLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenLastNameLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenEmailLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenPhoneLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenAddressLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenSexLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenLoginLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenPasswordLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenManLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenWomanLabel.GetObject());
            Controls.Add(registerScreen.RegisterScreenOtherLabel.GetObject());
            Controls.Add(registerScreen.registerScreenOtherCheckBox.GetObject());
            Controls.Add(registerScreen.registerScreenManCheckBox.GetObject());
            Controls.Add(registerScreen.registerScreenWomanCheckBox.GetObject());
        }
        private void ShowRegisterScreen()
        {
            registerScreen.RegisterScreenRegisterButton.GetObject().Visible = true;
            registerScreen.RegisterScreenNameTextBox.GetObject().Visible = true;
            registerScreen.RegisterScreenLastNameTextBox.GetObject().Visible = true;
            registerScreen.RegisterScreenEmailTextBox.GetObject().Visible = true;
            registerScreen.RegisterScreenPhoneTextBox.GetObject().Visible = true;
            registerScreen.RegisterScreenAddressTextBox.GetObject().Visible = true;
            registerScreen.RegisterScreenLoginTextBox.GetObject().Visible = true;
            registerScreen.RegisterScreenPasswordTextBox.GetObject().Visible = true;
            registerScreen.RegisterScreenNameLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenLastNameLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenEmailLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenPhoneLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenAddressLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenSexLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenLoginLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenPasswordLabel.GetObject().Visible = true;
            registerScreen.registerScreenOtherCheckBox.GetObject().Visible = true;
            registerScreen.registerScreenManCheckBox.GetObject().Visible = true;
            registerScreen.registerScreenWomanCheckBox.GetObject().Visible = true;
            registerScreen.RegisterScreenManLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenWomanLabel.GetObject().Visible = true;
            registerScreen.RegisterScreenOtherLabel.GetObject().Visible = true;
        }
        private void HideRegisterScreen()
        {
            registerScreen.RegisterScreenRegisterButton.GetObject().Visible = false;
            registerScreen.RegisterScreenNameTextBox.GetObject().Visible = false;
            registerScreen.RegisterScreenLastNameTextBox.GetObject().Visible = false;
            registerScreen.RegisterScreenEmailTextBox.GetObject().Visible = false;
            registerScreen.RegisterScreenPhoneTextBox.GetObject().Visible = false;
            registerScreen.RegisterScreenAddressTextBox.GetObject().Visible = false;
            registerScreen.RegisterScreenLoginTextBox.GetObject().Visible = false;
            registerScreen.RegisterScreenPasswordTextBox.GetObject().Visible = false;
            registerScreen.RegisterScreenNameLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenLastNameLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenEmailLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenPhoneLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenAddressLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenSexLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenLoginLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenPasswordLabel.GetObject().Visible = false;
            registerScreen.registerScreenOtherCheckBox.GetObject().Visible = false;
            registerScreen.registerScreenManCheckBox.GetObject().Visible = false;
            registerScreen.registerScreenWomanCheckBox.GetObject().Visible = false;
            registerScreen.RegisterScreenManLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenWomanLabel.GetObject().Visible = false;
            registerScreen.RegisterScreenOtherLabel.GetObject().Visible = false;
        }
        private void InitCustomerAccountScreen()
        {
            customerAccountScreen.CreateCustomerAccountScreen(win_x, win_y);
            Controls.Add(customerAccountScreen.cartButton.GetObject());
            Controls.Add(customerAccountScreen.settingsButton.GetObject());
            Controls.Add(customerAccountScreen.logOutButton.GetObject());
            Controls.Add(customerAccountScreen.searchButton.GetObject());
            Controls.Add(customerAccountScreen.searchTextBox.GetObject());
            Controls.Add(customerAccountScreen.nextPageButton.GetObject());
            Controls.Add(customerAccountScreen.prevPageButton.GetObject());
            foreach (var i in customerAccountScreen.singlePageBooks)
            {
                Controls.Add(i.GetButtonObj().GetObject());
                Controls.Add(i.GetTtleObj().GetObject());
                Controls.Add(i.GetPriceObj().GetObject());
            }
        }
        private void ShowCustomerAccountScreen()
        {
            customerAccountScreen.cartButton.GetObject().Visible = true;
            customerAccountScreen.settingsButton.GetObject().Visible = true;
            customerAccountScreen.logOutButton.GetObject().Visible = true;
            customerAccountScreen.searchButton.GetObject().Visible = true;
            customerAccountScreen.searchTextBox.GetObject().Visible = true;
            customerAccountScreen.nextPageButton.GetObject().Visible = true;
            customerAccountScreen.prevPageButton.GetObject().Visible = true;
        }
        private void HideCustomerAccountScreen()
        {
            customerAccountScreen.cartButton.GetObject().Visible = false;
            customerAccountScreen.settingsButton.GetObject().Visible = false;
            customerAccountScreen.logOutButton.GetObject().Visible = false;
            customerAccountScreen.searchButton.GetObject().Visible = false;
            customerAccountScreen.searchTextBox.GetObject().Visible = false;
            customerAccountScreen.nextPageButton.GetObject().Visible = false;
            customerAccountScreen.prevPageButton.GetObject().Visible = false;
            for (int i = 0; i < 10; i++)
            {
                customerAccountScreen.singlePageBooks[i].GetButtonObj().GetObject().Visible = false;
                customerAccountScreen.singlePageBooks[i].GetPriceObj().GetObject().Visible = false;
                customerAccountScreen.singlePageBooks[i].GetTtleObj().GetObject().Visible = false;
            }
        }
        private void InitSettingsScreen()
        {

        }
        private void ShowSettingsScreen()
        {

        }
        private void HideSettingsScreen()
        {

        }
        private void InitCartScreen()
        {

        }
        private void ShowCartScreen()
        {

        }
        private void HideCartScreen()
        {

        }

        private void ShowSingleBookScreen()
        {
            singleBookScreen.title.GetObject().Visible = true;
            singleBookScreen.autor.GetObject().Visible = true;
            singleBookScreen.year.GetObject().Visible = true;
            singleBookScreen.pages.GetObject().Visible = true;
            singleBookScreen.price.GetObject().Visible = true;
            singleBookScreen.loan.GetObject().Visible = true;
            singleBookScreen.addToCart.GetObject().Visible = true;
            singleBookScreen.loan.GetObject().Visible = true;
        }
        private void HideSingleBookScreen()
        {
            singleBookScreen.title.GetObject().Visible = false;
            singleBookScreen.autor.GetObject().Visible = false;
            singleBookScreen.year.GetObject().Visible = false;
            singleBookScreen.pages.GetObject().Visible = false;
            singleBookScreen.price.GetObject().Visible = false;
            singleBookScreen.loan.GetObject().Visible = false;
            singleBookScreen.addToCart.GetObject().Visible = false;
            singleBookScreen.loan.GetObject().Visible = false;
        }
        private void AddToControls()
        {
            //single book screen
            Controls.Add(singleBookScreen.title.GetObject());
            Controls.Add(singleBookScreen.autor.GetObject());
            Controls.Add(singleBookScreen.year.GetObject());
            Controls.Add(singleBookScreen.pages.GetObject());
            Controls.Add(singleBookScreen.price.GetObject());
            Controls.Add(singleBookScreen.loan.GetObject());
            Controls.Add(singleBookScreen.addToCart.GetObject());
            Controls.Add(singleBookScreen.loan.GetObject());

            //cart screen
            Controls.Add(cartScreen.backButton.GetObject());
            Controls.Add(cartScreen.orderButton.GetObject());
        }
    }
}
