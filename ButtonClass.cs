using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ButtonClass
{
    Button button;
    
    public Button GetObject()
    {
        return button;
    }

    ButtonClass(int pos_x, int pos_y, int width, int height, string text) 
    {
        button = new Button();
        button.Left=pos_x;
        button.Top=pos_y;
        button.Width=widht;
        button.Height=height;
        button.Text=text;
    }
}