using System.Windows.Forms;

public class CheckBoxClass
{
    private CheckBox cb;

    public CheckBox GetObject()
    {
        return cb;
    }

    public CheckBoxClass(int pos_x, int pos_y, int width, int height)
    {
        cb = new CheckBox();
        cb.Left = pos_x - width / 2;
        cb.Top = pos_y - height / 2;
        cb.Width = width;
        cb.Height = height;
    }
}