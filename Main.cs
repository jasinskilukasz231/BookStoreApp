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
        public WindowFrame()
        {
            InitializeComponent();
            CreateStartingScreen();
        }

        private void CreateStartingScreen()
        {
            ButtonClass StartingScreenRegisterButton = new ButtonClass(win_x / 2, win_y / 2 + 250, 150, 50, "Register");
            Controls.Add(StartingScreenRegisterButton.GetObject());
            StartingScreenRegisterButton.GetObject().Click += new EventHandler(StartingScreenRegisterButtonClick);

            ButtonClass StartingScreenStafLoginButton = new ButtonClass(win_x / 2, win_y / 2 + 310, 150, 50, "Staf Login");
            Controls.Add(StartingScreenStafLoginButton.GetObject());
            StartingScreenStafLoginButton.GetObject().Click += new EventHandler(StartingScreenStafLoginButtonClick);

            ButtonClass StartingScreenLoginButton = new ButtonClass(win_x / 2, win_y / 2 + 170, 150, 50, "Login");
            Controls.Add(StartingScreenLoginButton.GetObject());
            StartingScreenLoginButton.GetObject().Click += new EventHandler(StartingScreenLoginButtonClick);

            TextBoxClass StartingScreenTextBoxLogin = new TextBoxClass(win_x / 2, win_y / 2, 200);
            Controls.Add(StartingScreenTextBoxLogin.GetObject());
            StartingScreenTextBoxLogin.GetObject().Font = UtilitiesClass.arial12Regular;

            TextBoxClass StartingScreenTextBoxPassword = new TextBoxClass(win_x / 2, win_y / 2 + 70, 200);
            Controls.Add(StartingScreenTextBoxPassword.GetObject());
            StartingScreenTextBoxPassword.GetObject().Font = UtilitiesClass.arial12Regular;

            LabelClass StartingScreenLoginLabel = new LabelClass(win_x / 2 - 160, win_y / 2 + 30, "Login", 150, 50);
            Controls.Add(StartingScreenLoginLabel.GetObject());
            StartingScreenLoginLabel.GetObject().Font = UtilitiesClass.arial12Bold;

            LabelClass StartingScreenPasswordLabel = new LabelClass(win_x / 2 - 160, win_y / 2 + 100, "Password", 150, 50);
            Controls.Add(StartingScreenPasswordLabel.GetObject());
            StartingScreenPasswordLabel.GetObject().Font = UtilitiesClass.arial12Bold;

            LabelClass StartingScreenWrongDataLabel = new LabelClass(win_x / 2 + 20, win_y / 2 + 120, "Wrong login or password", 150, 30);
            Controls.Add(StartingScreenWrongDataLabel.GetObject());
            StartingScreenWrongDataLabel.GetObject().ForeColor = Color.Red;
            StartingScreenWrongDataLabel.GetObject().Visible = false;

        }
        private void StartingScreenRegisterButtonClick(object sender, EventArgs e)
        {

        }
        private void StartingScreenLoginButtonClick(object sender, EventArgs e)
        {

        }
        private void StartingScreenStafLoginButtonClick(object sender, EventArgs e)
        {

        }
    }
}
