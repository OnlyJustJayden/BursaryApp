using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamKappa
{
    public partial class NewAccount : Form
    {
        private bool passvis = false;
        public NewAccount()
        {
            InitializeComponent();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (!IsAllLetters(txtName.Text))
            {
                MessageBox.Show("Error, Your Name cannot consist of numbers or other characters.Please include letters only in the name field", "Data Notification");
                txtName.Focus();
                return;
            }
            if (!IsAllLetters(txtSurname.Text))
            {
                MessageBox.Show("Error, Your Surname cannot consist of numbers or other characters.Please include letters only in the name field", "Data Notification");
                txtSurname.Focus();
                return;
            }
            if (!IsEmailValid(txtEmail.Text)) // checks if the email is valid
            {
                MessageBox.Show("Error, Your email address is invalid. Please retype a correct email address.", "Data Notification");
                txtSurname.Focus();
                return;
            }
            if (!IsEmailVerified(txtEmail.Text))   // The email is not verified.
                return;

            if (txtName.Text == "" || txtSurname.Text == "" || txtPassword.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Error, Please complete all fields before submitting your account application.", "Warning");
            }
            else // Password Validation cases:
            {
                if (txtPassword.TextLength < 8)  // 8 character password
                {
                    MessageBox.Show("Error, Your password is too short.Please have an 8 or more character password.", "Data Notification");
                    txtPassword.Focus();
                    return;
                }

                bool letters = IsAllLetters(txtPassword.Text);
                bool numbers = IsAllNumbers(txtPassword.Text);
                bool specialchar = IsOnlyLettersAndNumbers(txtPassword.Text);

                if (letters)
                {
                    txtPassword.Focus(); // Sets the password text box to being highlighted/ focused on 
                    MessageBox.Show("Error, Your password does not contain numbers. Please include letters,numbers and special characters(@,#,$,%) within your password.", "Data Notification");
                    return;
                }
                else
                    if (numbers)
                {
                    MessageBox.Show("Error, Your password does not contain letters. Please use a password with numbers, special characters(@,#,$,%) as well as letters.", "Data Notification");
                    txtPassword.Focus();
                    return;
                }
                else
                if (specialchar)
                {
                    MessageBox.Show("Error, Your password does not contain special characters. Please use a password with numbers,special characters(@,#,$,%) as well as letters.", "Data Notification");
                    txtPassword.Focus();
                    return;
                }


            }
        
        }
       
           
        public static bool IsAllLetters(string password)
        {
            foreach (char c in password)   // Checks if the password is only letters 
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsAllNumbers(string password)  // Checks if the password is only numbers
        {
            foreach (char c in password)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsOnlyLettersAndNumbers(string password)  // Checks if the password has only letters and numbers, no special characters (@,#,$,%)
        {
            foreach (char c in password)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsEmailValid(string email)  // Checks if the email has only letters and numbers, as well as @ or .
        {
            foreach (char c in email)
            {
                if (!Char.IsLetterOrDigit(c) && c != '@' && c != '.')
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsEmailVerified(string email)  // Checks if the email has only letters and numbers, as well as @ or .
        {
            int letters = 0;
            int at = 0;
            int period = 0;
            int numbers = 0;
            foreach (char c in email)
            {
                if (Char.IsLetter(c))
                {
                    ++letters;
                }
                if (c == '@')
                {
                    ++at;
                }
                if (c == '.')
                {
                    ++period;
                }
                else
                    ++numbers;
            }
            if (letters == 0) // No letters in email
            {
                MessageBox.Show("Error, Your email does not contain letters.Please retype your email correctly.", "Data Notification");
                return false;
            }
            if (at != 1 || period != 1)  // No period or at, email standards conflict
            {
                MessageBox.Show("Error, Your email is not valid.Please retype your email correctly.", "Data Notification");
                return false;
            }
            return true;
        }

        private void eye_Click(object sender, EventArgs e)
        {
            if (!passvis) //enable view password feature 
            {
                txtPassword.UseSystemPasswordChar = false;
                passwordeye.Image = Properties.Resources.closeeye_icon;
                passvis = true;
            }
            else  // conceal the password 
            {
                txtPassword.UseSystemPasswordChar = true;
                passwordeye.Image = Properties.Resources.eye;
                passvis = false;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLocalTime().ToShortTimeString(); // Changes the time label to current system time
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
    }
}

