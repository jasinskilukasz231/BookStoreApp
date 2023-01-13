using System.Windows.Forms;

public class ButtonClass
{
    int x, y, w, h;
    string t;
    Button button = new Button();

    public Button CreateButton()
    {
        button.Left = x;
        button.Top = y;
        button.Width = w;
        button.Height = h;
        button.Text = t;
        button.Visible = true;
        return button;
    }
    public ButtonClass(int pos_x, int pos_y, int width, int height, string text) 
    {
        x = pos_x - width / 2;
        y = pos_y - height / 2;
        w=width;
        h=height;
        t=text;
    }
}