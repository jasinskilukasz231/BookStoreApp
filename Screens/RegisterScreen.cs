using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookStoreApp.Screens
{
    public class RegisterScreen
    {
        public bool registered = false;

        private ButtonClass registerButton;
        private TextBoxClass nameTextBox;
        private TextBoxClass lastNameTextBox;
        private TextBoxClass emailTextBox;
        private TextBoxClass phoneTextBox;
        private TextBoxClass addressTextBox;
        private TextBoxClass loginTextBox;
        private TextBoxClass passwordTextBox;
        private LabelClass nameLabel;
        private LabelClass lastNameLabel;
        private LabelClass emailLabel;
        private LabelClass phoneLabel;
        private LabelClass addressLabel;
        private LabelClass sexLabel;
        private LabelClass loginLabel;
        private LabelClass passwordLabel;
        private LabelClass otherLabel;
        private LabelClass manLabel;
        private LabelClass womanLabel;
        private CheckBoxClass manCheckBox;
        private CheckBoxClass womanCheckBox;
        private CheckBoxClass otherCheckBox;

        private List<ButtonClass> buttonList;
        private List<TextBoxClass> textBoxList;
        private List<LabelClass> labelList;
        private List<CheckBoxClass> checkBoxList;

        public RegisterScreen(int win_x, int win_y)
        {
            buttonList = new List<ButtonClass>();
            textBoxList = new List<TextBoxClass>();
            labelList = new List<LabelClass>();
            checkBoxList = new List<CheckBoxClass>();

            registerButton = new ButtonClass(win_x / 2, win_y / 2 + 250, 150, 50, "Register");
            registerButton.GetObject().Click += new EventHandler(RegisterScreenRegisterButtonClick);
            registerButton.GetObject().Visible = false;
            buttonList.Add(registerButton);

            nameTextBox = new TextBoxClass(win_x / 2, 60, 200);
            nameTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            nameTextBox.GetObject().Visible = false;
            textBoxList.Add(nameTextBox);

            lastNameTextBox = new TextBoxClass(win_x / 2, 120, 200);
            lastNameTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            lastNameTextBox.GetObject().Visible = false;
            textBoxList.Add(lastNameTextBox);

            emailTextBox = new TextBoxClass(win_x / 2, 180, 200);
            emailTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            emailTextBox.GetObject().Visible = false;
            textBoxList.Add(emailTextBox);

            phoneTextBox = new TextBoxClass(win_x / 2, 240, 200);
            phoneTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            phoneTextBox.GetObject().Visible = false;
            textBoxList.Add(phoneTextBox);

            addressTextBox = new TextBoxClass(win_x / 2, 300, 200);
            addressTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            addressTextBox.GetObject().Visible = false;
            textBoxList.Add(addressTextBox);

            manCheckBox = new CheckBoxClass(win_x / 2 - 45, 375, 30, 30);
            manCheckBox.GetObject().Visible = false;
            manCheckBox.GetObject().Click += new EventHandler(RegisterScreenManCheckBoxClick);
            checkBoxList.Add(manCheckBox);

            womanCheckBox = new CheckBoxClass(win_x / 2 + 60, 375, 30, 30);
            womanCheckBox.GetObject().Visible = false;
            womanCheckBox.GetObject().Click += new EventHandler(RegisterScreenWomanCheckBoxClick);
            checkBoxList.Add(womanCheckBox);

            otherCheckBox = new CheckBoxClass(win_x / 2 + 150, 375, 30, 30);
            otherCheckBox.GetObject().Visible = false;
            otherCheckBox.GetObject().Click += new EventHandler(RegisterScreenDiffCheckBoxClick);
            checkBoxList.Add(otherCheckBox);

            loginTextBox = new TextBoxClass(win_x / 2, 420, 200);
            loginTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            loginTextBox.GetObject().Visible = false;
            textBoxList.Add(loginTextBox);

            passwordTextBox = new TextBoxClass(win_x / 2, 480, 200);
            passwordTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
            passwordTextBox.GetObject().Visible = false;
            textBoxList.Add(passwordTextBox);

            nameLabel = new LabelClass(win_x / 2 - 160, 90, "Name", 150, 50);
            nameLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            nameLabel.GetObject().Visible = false;
            labelList.Add(nameLabel);

            lastNameLabel = new LabelClass(win_x / 2 - 160, 150, "Last name", 150, 50);
            lastNameLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            lastNameLabel.GetObject().Visible = false;
            labelList.Add(lastNameLabel);

            emailLabel = new LabelClass(win_x / 2 - 160, 210, "E-mail", 150, 50);
            emailLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            emailLabel.GetObject().Visible = false;
            labelList.Add(emailLabel);

            phoneLabel = new LabelClass(win_x / 2 - 160, 270, "Phone", 150, 50);
            phoneLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            phoneLabel.GetObject().Visible = false;
            labelList.Add(phoneLabel);

            addressLabel = new LabelClass(win_x / 2 - 160, 330, "Address", 150, 50);
            addressLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            addressLabel.GetObject().Visible = false;
            labelList.Add(addressLabel);

            sexLabel = new LabelClass(win_x / 2 - 203, 390, "Sex", 70, 50);
            sexLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            sexLabel.GetObject().Visible = false;
            labelList.Add(sexLabel);

            loginLabel = new LabelClass(win_x / 2 - 160, 450, "Login", 150, 50);
            loginLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            loginLabel.GetObject().Visible = false;
            labelList.Add(loginLabel);

            passwordLabel = new LabelClass(win_x / 2 - 160, 510, "Password", 150, 50);
            passwordLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            passwordLabel.GetObject().Visible = false;
            labelList.Add(passwordLabel);

            manLabel = new LabelClass(win_x / 2 - 85, 390, "Man", 50, 50);
            manLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            manLabel.GetObject().Visible = false;
            labelList.Add(manLabel);

            womanLabel = new LabelClass(win_x / 2, 390, "Woman", 70, 50);
            womanLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            womanLabel.GetObject().Visible = false;
            labelList.Add(womanLabel);

            otherLabel = new LabelClass(win_x / 2 + 100, 390, "Other", 60, 50);
            otherLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            otherLabel.GetObject().Visible = false;
            labelList.Add(otherLabel);
        }
        public void SetVisible(bool value)
        {
            if (value == true)
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
                foreach (var i in checkBoxList)
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
                foreach (var i in checkBoxList)
                {
                    i.GetObject().Visible = false;
                }
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
        public List<CheckBoxClass> GetCheckBoxList()
        {
            return checkBoxList;
        }
        private void RegisterScreenRegisterButtonClick(object sender, EventArgs e)
        {
            Register();
        }
        private void RegisterScreenManCheckBoxClick(object sender, EventArgs e)
        {
            if (otherCheckBox.GetObject().Enabled == true && womanCheckBox.GetObject().Enabled == true)
            {
                otherCheckBox.GetObject().Enabled = false;
                womanCheckBox.GetObject().Enabled = false;
            }
            else
            {
                otherCheckBox.GetObject().Enabled = true;
                womanCheckBox.GetObject().Enabled = true;
            }
        }
        private void RegisterScreenWomanCheckBoxClick(object sender, EventArgs e)
        {
            if (otherCheckBox.GetObject().Enabled == true && manCheckBox.GetObject().Enabled == true)
            {
                otherCheckBox.GetObject().Enabled = false;
                manCheckBox.GetObject().Enabled = false;
            }
            else
            {
                otherCheckBox.GetObject().Enabled = true;
                manCheckBox.GetObject().Enabled = true;
            }
        }
        private void RegisterScreenDiffCheckBoxClick(object sender, EventArgs e)
        {
            if (manCheckBox.GetObject().Enabled == true && womanCheckBox.GetObject().Enabled == true)
            {
                manCheckBox.GetObject().Enabled = false;
                womanCheckBox.GetObject().Enabled = false;
            }
            else
            {
                manCheckBox.GetObject().Enabled = true;
                womanCheckBox.GetObject().Enabled = true;
            }
        }
        public void Register()
        {
            bool data_ok = true;
            bool loginPassword_ok = true;
            bool loginTaken = false;
            foreach (var i in textBoxList) //checking if all data entered
            {
                if (i.GetObject().Text.Length < 2) data_ok = false;
            }

            if (manCheckBox.GetObject().Checked == false &&
                womanCheckBox.GetObject().Checked == false &&
                otherCheckBox.GetObject().Checked == false)
            {
                data_ok = false;
            }

            //checking login and password lenght
            if (passwordTextBox.GetObject().Text.Length < 5 ||
                passwordTextBox.GetObject().Text.Length > 20 ||
                loginTextBox.GetObject().Text.Length < 5 ||
                loginTextBox.GetObject().Text.Length > 20)
            {
                loginPassword_ok = false;
            }

            string query = "SELECT id FROM customers_data WHERE login=" + UtilitiesClass.quoteSign + loginTextBox.GetObject().Text
                + UtilitiesClass.quoteSign;

            if (Database.FindOneThing(query) != null)
            {
                loginTaken = true;
            }

            if (data_ok == false)
            {
                MessageBox.Show("Please enter all required data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (loginPassword_ok == false)
                {
                    MessageBox.Show("Password or login is too long or too short", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (loginTaken == true)
                    {
                        MessageBox.Show("Your login is taken", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string id = "NULL";
                        string name = UtilitiesClass.quoteSign + nameTextBox.GetObject().Text + UtilitiesClass.quoteSign;
                        string lastName = UtilitiesClass.quoteSign + lastNameTextBox.GetObject().Text + UtilitiesClass.quoteSign;
                        string email = UtilitiesClass.quoteSign + emailTextBox.GetObject().Text + UtilitiesClass.quoteSign;
                        string phone = UtilitiesClass.quoteSign + phoneTextBox.GetObject().Text + UtilitiesClass.quoteSign;
                        string address = UtilitiesClass.quoteSign + addressTextBox.GetObject().Text + UtilitiesClass.quoteSign;
                        string sex = "";
                        if (manCheckBox.GetObject().Checked == true)
                        {
                            sex = UtilitiesClass.quoteSign + "Man" + UtilitiesClass.quoteSign;
                        }
                        else if (womanCheckBox.GetObject().Checked == true)
                        {
                            sex = UtilitiesClass.quoteSign + "Woman" + UtilitiesClass.quoteSign;
                        }
                        else if (otherCheckBox.GetObject().Checked == true)
                        {
                            sex = UtilitiesClass.quoteSign + "Other" + UtilitiesClass.quoteSign;
                        }

                        string login = UtilitiesClass.quoteSign + loginTextBox.GetObject().Text + UtilitiesClass.quoteSign;
                        string password = UtilitiesClass.quoteSign + passwordTextBox.GetObject().Text + UtilitiesClass.quoteSign;

                        string query1 = "INSERT INTO customers_data VALUES(" + id + ", " + name + ", " + lastName + ", " + email + ", " + phone + ", " +
                            address + ", " + sex + ", " + login + ", " + password + ")";
                        Database.InsertInto(query1);

                        registered = true;
                    }
                }
            }
        }
    }
}