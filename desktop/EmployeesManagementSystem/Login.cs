using EmployeesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesManagementSystem
{
    public partial class Login : Form
    {
        // Variables
        private DbContext databaseContext = new DbContext();
        
        // Constructor
        public Login()
        {
            InitializeComponent();
            clearColor();
        }

        /// <summary>
        /// Login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {

            clearColor();

            // Validation
            string email = this.tbEmail.Text;
            string password = this.tbPassword.Text;

            if (email.Length <= 0 || password.Length <= 0)
            {
                warningColor();
                return;
            }

            // Can choose this method 
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                warningColor();
                return;
            }
            else
            {
                // Validate the email
                if (!IsEmailValid(email))
                {
                    warningColor();
                    return;
                }

                // Validate the password
                if (!IsPasswordValid(password))
                {
                    MessageBox.Show("Password must be at least 6 characters long and " +
                               "contain at least one number and one special character.");
                    warningColor();
                    return;
                }

            }


            if (ifExists(email))
            {
               User user = databaseContext.GetUserByEmail(email);
               
                if(Hashing.ValidatePassword(password, user.Password)) 
                {
                    // Checking the role of the user
                    if(user.Role == Role.Administrator.ToString())
                    {
                        this.Hide();
                        // Show Dashboard
                        Dashboard dashboard = new Dashboard();
                        dashboard.Closed += (s, args) => this.Close();
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Role restriction!");
                    }
                }
                else
                {
                    this.labelPassword.Text = "Password *";
                    this.labelPassword.ForeColor = Color.PaleVioletRed;
                    MessageBox.Show("Password not correct");
                }
            }
            else
            {
                this.labelEmail.Text = "Email *";
                this.labelEmail.ForeColor = Color.PaleVioletRed;
            }
            clearFields();
        }

        // Validate the emails
        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format?redirectedfrom=MSDN
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // Validate the password
        // https://docs.microsoft.com/en-us/dotnet/api/system.web.security.validatepasswordeventargs?view=netframework-4.8
        public bool IsPasswordValid(string password)
        {
            Regex r = new Regex(@"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})");

            if (!r.IsMatch(password))
            {
            
                return false;
            }

            return true;
        }


        // Clear the fields
        private void clearFields()
        {
            this.tbEmail.Text = "";
            this.tbPassword.Text = "";
        }

        // Warning colors of the fields
        private void warningColor()
        {
            this.labelEmail.Text = "Email *";
            this.labelPassword.Text = "Password *";
            this.labelEmail.ForeColor = Color.PaleVioletRed;
            this.labelPassword.ForeColor = Color.PaleVioletRed;
        }

        // Clear color
        private void clearColor()
        {

            this.labelEmail.Text = "Email";
            this.labelPassword.Text = "Password";
            this.labelEmail.ForeColor = Color.FromArgb(105, 105, 105);
            this.labelPassword.ForeColor = Color.FromArgb(105, 105, 105);
        }

        // Helper method if email exists 
        private bool ifExists(string email)
        {
            if (databaseContext.GetUserByEmail(email) != null)return true;
            else return false;
        }

        // Exit button
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Back button
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.White;
        }

        // Leave button
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.Transparent;
        }
    }
}
