using System.Windows.Forms;

public class ButtonClass
{
    Button button;
    
    public Button GetObject()
    {
        return button;
    }

    public ButtonClass(int pos_x, int pos_y, int width, int height, string text) 
    {
        button = new Button();
        button.Left = pos_x - width / 2;
        button.Top = pos_y - height / 2;
        button.Width=width;
        button.Height=height;
        button.Text=text;
    }
}