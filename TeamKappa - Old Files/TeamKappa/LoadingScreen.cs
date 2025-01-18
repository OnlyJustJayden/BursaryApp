using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TeamKappa
{
    public partial class LoadingScreen : Form
    {
        private bool passvis=false; //Boolean variable to enable or disable password visibility
        public LoadingScreen()
        {
            InitializeComponent();
        }

       

        private void passwordeye_Click(object sender, EventArgs e)
        {
            if (passvis)
            {
                passwordeye.Image = Properties.Resources.eye;  // The open eye indicates to switch to a visible password
                txtPassword.UseSystemPasswordChar = true;
                passvis = false;
            }
            else
            {
                passwordeye.Image = Properties.Resources.closeeye_icon; //The closed eye indicatws to switch to a hidden password
                txtPassword.UseSystemPasswordChar = false;
                passvis = true;
            }
        }

        private void LoadingScreen_MouseMove(object sender, MouseEventArgs e) // Used to create the illusion of the application loading
        {
            pnlLoadScreen.Visible = false;
            pnlLoadScreen.Enabled = false;
            pnlLogin.Width = 382;
            pnlLogin.Height = 326;
            pnlLogin.Visible = true;
            pnlLogin.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?","Exit Application Confirmation",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Close();
            }
           // else, nothing will occur
            
        }

        private void btnLogin_Click(object sender, EventArgs e)  
        {
            new Home().Show(); // Navigate to the home page
            this.Hide();
        }
    }
}
