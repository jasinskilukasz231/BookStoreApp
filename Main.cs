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

        StartingScreen startingScreen = new StartingScreen();
        RegisterScreen registerScreen = new RegisterScreen();

        Timer appTimer = new Timer();
        public WindowFrame()
        {
            InitResources();
            InitializeComponent();
            InitStartingScreen();
            ShowStartingScreen();
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
                    //ShowStartingScreen();
                    //HideRegisterScreen();
                    whatToRender = 0;
                    break;
                case 2: //show starting screen
                    //ShowStartingScreen();
                    //HideRegisterScreen();
                    whatToRender = 0;
                    break;
                case 3: //show register screen
                    //ShowRegisterScreen();
                    //HideStartingScreen();
                    whatToRender = 0;
                    break;
                default: //0->nothing

                    if (startingScreen.StartingScreenRegisterButtonPressed==true)
                    {
                        whatToRender = 3;
                        startingScreen.StartingScreenRegisterButtonPressed = false; 
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
            startingScreen.StartingScreenWrongDataLabel.GetObject().Visible = true;
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
        }
    }
}
