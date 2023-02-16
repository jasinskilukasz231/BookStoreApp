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

namespace BookStoreApp
{
    public static class UtilitiesClass
    {
        private static FontFamily fontFamily = new FontFamily("Arial");
        public static Font arial12Regular = new Font(fontFamily, 12, FontStyle.Regular);
        public static Font arial12Bold = new Font(fontFamily, 12, FontStyle.Bold);
        public static Font arial24Bold = new Font(fontFamily, 24, FontStyle.Bold);

        private static string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        private static string imagesDir = projectDir + "/Images";
        public static string booksImagesDir = projectDir + "/BooksImages/";
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
        public static string RemoveSameNumbers(string[] s)
        {
            string result = "";
            for (int j = 0; j < s.Count(); j++)
            {
                bool unique = true;
                string single = s[j];
                for (int i = j + 1; i < s.Count(); i++)
                {
                    if (single == s[i])//the same numbers
                    {
                        unique = false;
                    }
                }
                if (unique == true)
                {
                    result += single + ",";
                }
            }

            if (result.Length > 1)
            {
                return result.Remove(result.Length - 1);
            }
            else
            {
                return result;
            }
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
}