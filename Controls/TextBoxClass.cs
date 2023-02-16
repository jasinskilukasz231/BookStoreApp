using System.Windows.Forms;

public class TextBoxClass
{
    private TextBox tb;

    public TextBox GetObject()
    {
        return tb;
    }

    public TextBoxClass(int pos_x, int pos_y, int width)
    {
        tb = new TextBox();
        tb.Left = pos_x - width / 2;
        tb.Top = pos_y;
        tb.Visible = true;
        tb.Text = "";
        tb.Width=width;
    }
}