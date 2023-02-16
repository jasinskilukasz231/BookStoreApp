using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Screens
{
    internal class RegisterInfoScreen
    {
        private LabelClass infoLabel;

        public RegisterInfoScreen(int win_x, int win_y)
        {
            infoLabel = new LabelClass(win_x / 2, win_y / 2, "Account registered", 250, 250);
            infoLabel.GetObject().Font = UtilitiesClass.arial12Bold;
            infoLabel.GetObject().Visible = false;
        }
        public void SetVisible(bool value)
        {
            infoLabel.GetObject().Visible = value;
        }
        public LabelClass getLabel()
        {
            return infoLabel;
        }
    }
}
