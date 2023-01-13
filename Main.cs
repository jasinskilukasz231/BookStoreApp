using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class WindowFrame : Form
    {
        const int win_x = 1262, win_y = 673; //size of the window
        public WindowFrame()
        {
            InitializeComponent();
            CreateStartingScreen();
            
        }

        private void CreateStartingScreen()
        {
            ButtonClass registerButton = new ButtonClass(win_x / 2, win_y / 2, 150, 50, "Register");
            Controls.Add(registerButton.CreateButton());
            
        }
    }
}
