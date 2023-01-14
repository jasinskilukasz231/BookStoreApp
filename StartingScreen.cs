using System;
using System.Drawing;

public class StartingScreen
{
    public bool StartingScreenRegisterButtonPressed = false;
    public bool StartingScreenLoginButtonPressed = false;
    public bool StartingScreenStafLoginButtonPressed = false;
    public ButtonClass StartingScreenRegisterButton { get; set; }
    public ButtonClass StartingScreenStafLoginButton { get; set; }
    public ButtonClass StartingScreenLoginButton { get; set; }
    public TextBoxClass StartingScreenTextBoxLogin { get; set; }
    public TextBoxClass StartingScreenTextBoxPassword { get; set; }
    public LabelClass StartingScreenLoginLabel { get; set; }
    public LabelClass StartingScreenPasswordLabel { get; set; }
    public LabelClass StartingScreenWrongDataLabel { get; set; }


    public void CreateStartingScreen(int win_x, int win_y)
    {
        StartingScreenRegisterButton = new ButtonClass(win_x / 2, win_y / 2 + 250, 150, 50, "Register");
        StartingScreenRegisterButton.GetObject().Click += new EventHandler(StartingScreenRegisterButtonClick);
        StartingScreenRegisterButton.GetObject().Visible = false;

        StartingScreenStafLoginButton = new ButtonClass(win_x / 2, win_y / 2 + 310, 150, 50, "Staf Login");
        StartingScreenStafLoginButton.GetObject().Click += new EventHandler(StartingScreenStafLoginButtonClick);
        StartingScreenStafLoginButton.GetObject().Visible = false;

        StartingScreenLoginButton = new ButtonClass(win_x / 2, win_y / 2 + 170, 150, 50, "Login");
        StartingScreenLoginButton.GetObject().Click += new EventHandler(StartingScreenLoginButtonClick);
        StartingScreenLoginButton.GetObject().Visible = false;

        StartingScreenTextBoxLogin = new TextBoxClass(win_x / 2, win_y / 2, 200);
        StartingScreenTextBoxLogin.GetObject().Font = UtilitiesClass.arial12Regular;
        StartingScreenTextBoxLogin.GetObject().Visible = false;

        StartingScreenTextBoxPassword = new TextBoxClass(win_x / 2, win_y / 2 + 70, 200);
        StartingScreenTextBoxPassword.GetObject().Font = UtilitiesClass.arial12Regular;
        StartingScreenTextBoxPassword.GetObject().Visible = false;

        StartingScreenLoginLabel = new LabelClass(win_x / 2 - 160, win_y / 2 + 30, "Login", 150, 50);
        StartingScreenLoginLabel.GetObject().Font = UtilitiesClass.arial12Bold;
        StartingScreenLoginLabel.GetObject().Visible = false;

        StartingScreenPasswordLabel = new LabelClass(win_x / 2 - 160, win_y / 2 + 100, "Password", 150, 50);
        StartingScreenPasswordLabel.GetObject().Font = UtilitiesClass.arial12Bold;
        StartingScreenPasswordLabel.GetObject().Visible = false;

        StartingScreenWrongDataLabel = new LabelClass(win_x / 2 + 20, win_y / 2 + 120, "Wrong login or password", 150, 30);
        StartingScreenWrongDataLabel.GetObject().ForeColor = Color.Red;
        StartingScreenWrongDataLabel.GetObject().Visible = false;

    }
    public void StartingScreenRegisterButtonClick(object sender, EventArgs e)
    {
        StartingScreenRegisterButtonPressed = true;
    }
    public void StartingScreenLoginButtonClick(object sender, EventArgs e)
    {
        StartingScreenLoginButtonPressed = true;
    }
    private void StartingScreenStafLoginButtonClick(object sender, EventArgs e)
    {
        StartingScreenStafLoginButtonPressed = true;
    }

}