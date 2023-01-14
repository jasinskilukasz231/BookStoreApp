using System;
using System.Drawing;

public class RegisterScreen
{
    bool registerScreenRegisterButtonPressed = false;
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

        RegisterScreenLoginTextBox = new TextBoxClass(win_x / 2, 360, 200);
        RegisterScreenLoginTextBox.GetObject().Font = UtilitiesClass.arial12Regular;
        RegisterScreenLoginTextBox.GetObject().Visible = false;

        RegisterScreenPasswordTextBox = new TextBoxClass(win_x / 2, 420, 200);
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

        RegisterScreenSexLabel = new LabelClass(win_x / 2 - 160, 390, "Sex", 150, 50);
        RegisterScreenSexLabel.GetObject().Font = UtilitiesClass.arial12Bold;
        RegisterScreenSexLabel.GetObject().Visible = false;

        RegisterScreenLoginLabel = new LabelClass(win_x / 2 - 160, 480, "Login", 150, 50);
        RegisterScreenLoginLabel.GetObject().Font = UtilitiesClass.arial12Bold;
        RegisterScreenLoginLabel.GetObject().Visible = false;

        RegisterScreenPasswordLabel = new LabelClass(win_x / 2 - 160, 570, "Password", 150, 50);
        RegisterScreenPasswordLabel.GetObject().Font = UtilitiesClass.arial12Bold;
        RegisterScreenPasswordLabel.GetObject().Visible = false;
    }

    private void RegisterScreenRegisterButtonClick(object sender, EventArgs e)
    {
        registerScreenRegisterButtonPressed = true;
    }
}