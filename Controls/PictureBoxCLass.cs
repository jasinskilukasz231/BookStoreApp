using System.Windows.Forms;


public class PictureBoxCLass
{
    private PictureBox box;
    public PictureBoxCLass(int pos_x, int pos_y, int width, int height)
    {
        box = new PictureBox();
        box.Left = pos_x + width / 2;
        box.Top = pos_y + height / 2;
        box.Width = width;
        box.Height = height;
    }
    public PictureBox GetObject()
    {
        return box;
    }

}

