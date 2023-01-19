using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Screens
{
    internal class RegisterInfoScreen
    {
        public LabelClass infoLabel { get; set; }

        public void createInfoScreen(int win_x, int win_y)
        {
            infoLabel = new LabelClass(200, 200, "Account registered", 250, 250);
            infoLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            infoLabel.GetObject().Visible = true;
        }
    }
}
