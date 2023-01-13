using System.Windows.Form;

public class TextBoxClass
{
    TextBox tb;

    public TextBox GetObject()
    {
        return tb;
    }

    public TextBoxClass(int pos_x, int pos_y, Font font)
    {
        tb = new TextBox();
        tb.Left = pos_x;
        tb.Top = pos_y;
        tb.Visible = true;
        tb.Text = "";
        tb.Font = font;
        return tb;
    }
}