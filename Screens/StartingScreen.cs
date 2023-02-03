using System;
using System.Collections.Generic;
using System.Drawing;

namespace BookStoreApp.Screens
{
    public class StartingScreen
    {
        public bool startingScreenRegisterButtonPressed { get; set; }
        public bool startingScreenStafLoginButtonPressed { get; set; }
        public bool logged = false;

        private ButtonClass registerButton;
        private ButtonClass stafLoginButton;
        private ButtonClass loginButton;
        private TextBoxClass loginTextBox;
        private TextBoxClass passwordTextBox;
        private LabelClass loginLabel;
        private LabelClass passwordLabel;
        private LabelClass wrongDataLabel;

        private List<ButtonClass> buttonList;
        private List<TextBoxClass> textBoxList;
        private List<LabelClass> labelList;

        public StartingScreen(int win_x, int win_y)
        {
            buttonList = new List<ButtonClass>();
            textBoxList = new List<TextBoxClass>();
            labelList = new List<LabelClass>();

            registerButton = new ButtonClass(win_x / 2, win_y / 2 + 250, 150, 50, "Register");
            registerButton.GetObject().Click += new EventHandler(StartingScreenRegisterButtonClick);
            buttonList.Add(registerButton);

            stafLoginButton = new ButtonClass(win_x / 2, win_y / 2 + 310, 150, 50, "Staf Login");
            stafLoginButton.GetObject().Click += new EventHandler(StartingScreenStafLoginButtonClick);
            buttonList.Add(stafLoginButton);

            loginButton = new ButtonClass(win_x / 2, win_y / 2 + 170, 150, 50, "Login");
            loginButton.GetObject().Click += new EventHandler(StartingScreenLoginButtonClick);
            buttonList.Add(loginButton);

            loginTextBox = new TextBoxClass(win_x / 2, win_y / 2, 200);
            loginTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            textBoxList.Add(loginTextBox);

            passwordTextBox = new TextBoxClass(win_x / 2, win_y / 2 + 70, 200);
            passwordTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            textBoxList.Add(passwordTextBox);

            loginLabel = new LabelClass(win_x / 2 - 160, win_y / 2 + 30, "Login", 150, 50);
            loginLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            labelList.Add(loginLabel);

            passwordLabel = new LabelClass(win_x / 2 - 160, win_y / 2 + 100, "Password", 150, 50);
            passwordLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            labelList.Add(passwordLabel);

            wrongDataLabel = new LabelClass(win_x / 2 + 20, win_y / 2 + 120, "Wrong login or password", 150, 30);
            wrongDataLabel.GetObject().ForeColor = Color.Red;
            wrongDataLabel.GetObject().Visible = false;
        }
        public void SetVisible(bool value)
        {
            if(value == true)
            {
                foreach (var i in buttonList)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in textBoxList)
                {
                    i.GetObject().Visible = true;
                }
                foreach (var i in labelList)
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
                foreach (var i in textBoxList)
                {
                    i.GetObject().Visible = false;
                }
                foreach (var i in labelList)
                {
                    i.GetObject().Visible = false;
                }
                wrongDataLabel.GetObject().Visible = false;
            }
        }
        public List<ButtonClass> GetButtonList()
        {
            return buttonList;
        }
        public List<TextBoxClass> GetTextBoxList()
        {
            return textBoxList;
        }
        public List<LabelClass> GetLabelList()
        {
            return labelList;
        }
        public LabelClass GetWrongDataLabel()
        {
            return wrongDataLabel;
        }
        public void ClearTextBoxes()
        {
            foreach (var i in textBoxList)
            {
                i.GetObject().Text = "";
            }
        }
        private void StartingScreenRegisterButtonClick(object sender, EventArgs e)
        {
            startingScreenRegisterButtonPressed = true;
        }
        private void StartingScreenLoginButtonClick(object sender, EventArgs e)
        {
            string query = "SELECT id FROM customers_data WHERE login=" + UtilitiesClass.quoteSign + loginTextBox.GetObject().Text
                + UtilitiesClass.quoteSign + " AND password=" + UtilitiesClass.quoteSign + passwordTextBox.GetObject().Text + UtilitiesClass.quoteSign;

            if (Database.FindOneThing(query) != null)
            {
                logged = true;
            }
            else
            {
                wrongDataLabel.GetObject().Visible = true;
            }
        }
        private void StartingScreenStafLoginButtonClick(object sender, EventArgs e)
        {
            startingScreenStafLoginButtonPressed = true;
        }

    }
}