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
    int x, y, width, height;
    string t;
    Button button = new Button();

    button.Left=x;
    button.Top=y;
    button.Width=widht;
    button.Height=height;
    button.Text=t;
    Controls.Add(button);

    ButtonClass(int pos_x, int pos_y, int width, int height, string text) 
    {
        x=pos_x;
        y=pos_y;
        width=width;
        height=height;
        t=text;
    }
}