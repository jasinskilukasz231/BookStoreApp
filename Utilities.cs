using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

static class UtilitiesClass
{
    private static FontFamily fontFamily = new FontFamily("Arial");
    public static Font arial12Regular = new Font(fontFamily, 12, FontStyle.Regular);
    public static Font arial12Bold = new Font(fontFamily, 12, FontStyle.Bold);

    private static string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
    private static string imagesDir = projectDir + "/Images";
    private static Bitmap cartImage, logOutImage, searchImage, settingsImage;
    public static Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>();

    public static char quoteSign = Convert.ToChar(34); //quote sign for sql queries
    public static void LoadImages()
    {
        //importing images from file
        cartImage = new Bitmap(Image.FromFile(imagesDir + "/cart.png"), new Size(44, 44));
        logOutImage = new Bitmap(Image.FromFile(imagesDir + "/logOut.png"), new Size(44, 44));
        searchImage = new Bitmap(Image.FromFile(imagesDir + "/search.png"), new Size(44, 44));
        settingsImage = new Bitmap(Image.FromFile(imagesDir + "/settings.png"), new Size(45, 45));
        images.Add("cart", cartImage);
        images.Add("logout", logOutImage);
        images.Add("search", searchImage);    
        images.Add("settings", settingsImage);
    }

    //ussefull methods
    public static string RemoveSameNumbers(string s)
    {
        for (int i = 0; i < s.Length; i++)//all chars in string
        {
            for (int j = i + 1; j < s.Length; j++)//set begining at the current pos, to the end
            {
                if (s[j] == s[i])//if any sign is the same, delete it
                {
                    s = s.Remove(j);
                }
            }
        }
        return s;
    }
    public static string ClearString(string s)
    {
        //isolating key words from the string:
        //adding + as a seperator
        //lowering all signs
        //removing not letters and not numbers

        string new_s = "";
        string stringReady = "";
        foreach (char i in s)
        {
            if (i == ' ') new_s += "+";
            else new_s += Char.ToLower(i);
        }
        for (int i = 0; i < new_s.Length; i++)
        {
            if (new_s[i] != '+')
            {
                if (Char.IsLetterOrDigit(new_s[i]))
                {
                    stringReady += new_s[i];
                }
            }
            else
            {
                stringReady += "+";
            }
        }

        return stringReady;
    }

}