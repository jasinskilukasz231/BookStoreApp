using System;

namespace BookStoreApp.Screens
{
    public class RegisterScreen
    {
        public bool registerScreenRegisterButtonPressed = false;
        public bool registerScreenShortTextWarning = false;
        public bool registerScreenWrongPasswordWarning = false;
        public bool registerScreenLoginTaken = false;
        public ButtonClass RegisterScreenRegisterButton { get; set; }
        public TextBoxClass RegisterScreenNameTextBox { get; set; }
        public TextBoxClass RegisterScreenLastNameTextBox { get; set; }
        public TextBoxClass RegisterScreenEmailTextBox { get; set; }
        public TextBoxClass RegisterScreenPhoneTextBox { get; set; }
        public TextBoxClass RegisterScreenAddressTextBox { get; set; }
        public TextBoxClass RegisterScreenLoginTextBox { get; set; }
        public TextBoxClass RegisterScreenPasswordTextBox { get; set; }
        public LabelClass RegisterScreenNameLabel { get; set; }
        public LabelClass RegisterScreenLastNameLabel { get; set; }
        public LabelClass RegisterScreenEmailLabel { get; set; }
        public LabelClass RegisterScreenPhoneLabel { get; set; }
        public LabelClass RegisterScreenAddressLabel { get; set; }
        public LabelClass RegisterScreenSexLabel { get; set; }
        public LabelClass RegisterScreenLoginLabel { get; set; }
        public LabelClass RegisterScreenPasswordLabel { get; set; }
        public LabelClass RegisterScreenOtherLabel { get; set; }
        public LabelClass RegisterScreenManLabel { get; set; }
        public LabelClass RegisterScreenWomanLabel { get; set; }

        public CheckBoxClass registerScreenManCheckBox { get; set; }
        public CheckBoxClass registerScreenWomanCheckBox { get; set; }
        public CheckBoxClass registerScreenOtherCheckBox { get; set; }

        public void CreateRegisterScreen(int win_x, int win_y)
        {
            RegisterScreenRegisterButton = new ButtonClass(win_x / 2, win_y / 2 + 250, 150, 50, "Register");
            RegisterScreenRegisterButton.GetObject().Click += new EventHandler(RegisterScreenRegisterButtonClick);
            RegisterScreenRegisterButton.GetObject().Visible = false;

            RegisterScreenNameTextBox = new TextBoxClass(win_x / 2, 60, 200);
            RegisterScreenNameTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            RegisterScreenNameTextBox.GetObject().Visible = false;

            RegisterScreenLastNameTextBox = new TextBoxClass(win_x / 2, 120, 200);
            RegisterScreenLastNameTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            RegisterScreenLastNameTextBox.GetObject().Visible = false;

            RegisterScreenEmailTextBox = new TextBoxClass(win_x / 2, 180, 200);
            RegisterScreenEmailTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            RegisterScreenEmailTextBox.GetObject().Visible = false;

            RegisterScreenPhoneTextBox = new TextBoxClass(win_x / 2, 240, 200);
            RegisterScreenPhoneTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            RegisterScreenPhoneTextBox.GetObject().Visible = false;

            RegisterScreenAddressTextBox = new TextBoxClass(win_x / 2, 300, 200);
            RegisterScreenAddressTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            RegisterScreenAddressTextBox.GetObject().Visible = false;

            registerScreenManCheckBox = new CheckBoxClass(win_x / 2 - 45, 375, 30, 30);
            registerScreenManCheckBox.GetObject().Visible = false;
            registerScreenManCheckBox.GetObject().Click += new EventHandler(RegisterScreenManCheckBoxClick);

            registerScreenWomanCheckBox = new CheckBoxClass(win_x / 2 + 60, 375, 30, 30);
            registerScreenWomanCheckBox.GetObject().Visible = false;
            registerScreenWomanCheckBox.GetObject().Click += new EventHandler(RegisterScreenWomanCheckBoxClick);

            registerScreenOtherCheckBox = new CheckBoxClass(win_x / 2 + 150, 375, 30, 30);
            registerScreenOtherCheckBox.GetObject().Visible = false;
            registerScreenOtherCheckBox.GetObject().Click += new EventHandler(RegisterScreenDiffCheckBoxClick);

            RegisterScreenLoginTextBox = new TextBoxClass(win_x / 2, 420, 200);
            RegisterScreenLoginTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            RegisterScreenLoginTextBox.GetObject().Visible = false;

            RegisterScreenPasswordTextBox = new TextBoxClass(win_x / 2, 480, 200);
            RegisterScreenPasswordTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            RegisterScreenPasswordTextBox.GetObject().Visible = false;


            RegisterScreenNameLabel = new LabelClass(win_x / 2 - 160, 90, "Name", 150, 50);
            RegisterScreenNameLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenNameLabel.GetObject().Visible = false;

            RegisterScreenLastNameLabel = new LabelClass(win_x / 2 - 160, 150, "Last name", 150, 50);
            RegisterScreenLastNameLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenLastNameLabel.GetObject().Visible = false;

            RegisterScreenEmailLabel = new LabelClass(win_x / 2 - 160, 210, "E-mail", 150, 50);
            RegisterScreenEmailLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenEmailLabel.GetObject().Visible = false;

            RegisterScreenPhoneLabel = new LabelClass(win_x / 2 - 160, 270, "Phone", 150, 50);
            RegisterScreenPhoneLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenPhoneLabel.GetObject().Visible = false;

            RegisterScreenAddressLabel = new LabelClass(win_x / 2 - 160, 330, "Address", 150, 50);
            RegisterScreenAddressLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenAddressLabel.GetObject().Visible = false;

            RegisterScreenSexLabel = new LabelClass(win_x / 2 - 203, 390, "Sex", 70, 50);
            RegisterScreenSexLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenSexLabel.GetObject().Visible = false;

            RegisterScreenLoginLabel = new LabelClass(win_x / 2 - 160, 450, "Login", 150, 50);
            RegisterScreenLoginLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenLoginLabel.GetObject().Visible = false;

            RegisterScreenPasswordLabel = new LabelClass(win_x / 2 - 160, 510, "Password", 150, 50);
            RegisterScreenPasswordLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenPasswordLabel.GetObject().Visible = false;

            RegisterScreenManLabel = new LabelClass(win_x / 2 - 85, 390, "Man", 50, 50);
            RegisterScreenManLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenManLabel.GetObject().Visible = false;

            RegisterScreenWomanLabel = new LabelClass(win_x / 2, 390, "Woman", 70, 50);
            RegisterScreenWomanLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenWomanLabel.GetObject().Visible = false;

            RegisterScreenOtherLabel = new LabelClass(win_x / 2 + 100, 390, "Other", 60, 50);
            RegisterScreenOtherLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            RegisterScreenOtherLabel.GetObject().Visible = false;
        }
        private void RegisterScreenRegisterButtonClick(object sender, EventArgs e)
        {
            //jezeli za nie ma tekstu wyswietl 1
            //jezeli tekst ok nie wyswietlaj 1 wyswietl 2
            bool text_ok = false;
            bool password_login_length = false;
            bool login_taken = false;
            if (RegisterScreenNameTextBox.GetObject().Text.Length > 2 &&
                RegisterScreenLastNameTextBox.GetObject().Text.Length > 2 &&
                RegisterScreenEmailTextBox.GetObject().Text.Length > 2 &&
                RegisterScreenPhoneTextBox.GetObject().Text.Length > 2 &&
                RegisterScreenAddressTextBox.GetObject().Text.Length > 2 &&
                RegisterScreenLoginTextBox.GetObject().Text.Length > 2 &&
                RegisterScreenPasswordTextBox.GetObject().Text.Length > 2 &&
                (registerScreenManCheckBox.GetObject().Checked == true ||
                registerScreenWomanCheckBox.GetObject().Checked == true ||
                registerScreenOtherCheckBox.GetObject().Checked == true))
            {
                text_ok = true;
            }
            else registerScreenShortTextWarning = true;

            if (RegisterScreenPasswordTextBox.GetObject().Text.Length > 5 &&
                RegisterScreenPasswordTextBox.GetObject().Text.Length < 20 &&
                RegisterScreenLoginTextBox.GetObject().Text.Length > 5 &&
                RegisterScreenLoginTextBox.GetObject().Text.Length < 20)
            {
                password_login_length = true;
            }
            else
            {
                registerScreenWrongPasswordWarning = true;
                registerScreenShortTextWarning = false;
            }

            //if ()login_taken = true;
            //else login_taken = false;

            if (text_ok == true && password_login_length == true && login_taken == false) //text length/
            {
                registerScreenRegisterButtonPressed = true;
            }
        }
        private void RegisterScreenManCheckBoxClick(object sender, EventArgs e)
        {
            if (registerScreenOtherCheckBox.GetObject().Enabled == true && registerScreenWomanCheckBox.GetObject().Enabled == true)
            {
                registerScreenOtherCheckBox.GetObject().Enabled = false;
                registerScreenWomanCheckBox.GetObject().Enabled = false;
            }
            else
            {
                registerScreenOtherCheckBox.GetObject().Enabled = true;
                registerScreenWomanCheckBox.GetObject().Enabled = true;
            }
        }
        private void RegisterScreenWomanCheckBoxClick(object sender, EventArgs e)
        {
            if (registerScreenOtherCheckBox.GetObject().Enabled == true && registerScreenManCheckBox.GetObject().Enabled == true)
            {
                registerScreenOtherCheckBox.GetObject().Enabled = false;
                registerScreenManCheckBox.GetObject().Enabled = false;
            }
            else
            {
                registerScreenOtherCheckBox.GetObject().Enabled = true;
                registerScreenManCheckBox.GetObject().Enabled = true;
            }
        }
        private void RegisterScreenDiffCheckBoxClick(object sender, EventArgs e)
        {
            if (registerScreenManCheckBox.GetObject().Enabled == true && registerScreenWomanCheckBox.GetObject().Enabled == true)
            {
                registerScreenManCheckBox.GetObject().Enabled = false;
                registerScreenWomanCheckBox.GetObject().Enabled = false;
            }
            else
            {
                registerScreenManCheckBox.GetObject().Enabled = true;
                registerScreenWomanCheckBox.GetObject().Enabled = true;
            }
        }
    }
}