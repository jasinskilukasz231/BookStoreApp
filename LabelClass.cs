using System.Windows.Forms;

public class LabelClass
{
    Label label;

    public Label GetObject()
    {
        return label;
    }

    public LabelClass(int pos_x, int pos_y, string text, int width, int height)
    {
        label = new Label();
        label.Left = pos_x - width / 2;
        label.Top = pos_y - height / 2;
        label.Visible = true;
        label.Text = text;
        label.Width = width;
    }
}