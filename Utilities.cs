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
}