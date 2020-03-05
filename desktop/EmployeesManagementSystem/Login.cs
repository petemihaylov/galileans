using System;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;
using System.Text.RegularExpressions;

namespace EmployeesManagementSystem
{
    public partial class Login : Form
    {
        private DbContext databaseContext = new DbContext();
        
        public Login()
        {
            InitializeComponent();
            clearColor();

            //insert data so you can actually login
            databaseContext.DeleteUsersWithEmail("admin@gmail.com");
            databaseContext.InsertUser(new User("admin", "admin@gmail.com", "+31 6430 2303",Hashing.HashPassword("admin"),Role.Administrator.ToString(), -100));
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            clearColor();
            string email = this.tbEmail.Text;
            string password = this.tbPassword.Text;

            // Validation with isNullOrEmpty you can pass with a single \t or space the WhiteSpace is securer
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                warningColors();
                return;
            }
            else
            {
                if (!IsEmailValid(email))
                {
                    // Indicates only the email
                    this.labelEmail.Text = "Email *";
                    this.labelEmail.ForeColor = Color.PaleVioletRed;

                    return;
                }

                /*
                // Validate the password
                if (!IsPasswordValid(password))
                {
                    MessageBox.Show("Password must be at least 6 characters long and " +
                               "contain at least one number and one special character.");

                    // Indicates only the password
                    this.labelPassword.Text = "Password *";
                    this.labelPassword.ForeColor = Color.PaleVioletRed;

                    return;
                }
                */
            }


            if (ifExists(email))
            {
                User user = databaseContext.GetUserByEmail(email);

                if(Hashing.ValidatePassword(password, user.Password)) 
                {
                    // Checking the role of the user
                    if(user.Role == Role.Administrator.ToString())
                    {
                        databaseContext.Dispose(true);
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
                // Indicates that the email is not existing
                this.labelEmail.Text = "Email *";
                this.labelEmail.ForeColor = Color.PaleVioletRed;
            }
            clearFields();
        }

        // Validate the emails
        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format?redirectedfrom=MSDN
        private bool IsEmailValid(string emailaddress)
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
        private bool IsPasswordValid(string password)
        {
            Regex rx = new Regex(@"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})");
            return rx.IsMatch(password);
        }
        private bool ifExists(string email)
        {
            if (databaseContext.GetUserByEmail(email) != null) return true;
            else return false;
        }
        private void clearFields()
        {
            this.tbEmail.Text = "";
            this.tbPassword.Text = "";
        }
        private void warningColors()
        {
            this.labelEmail.Text = "Email *";
            this.labelPassword.Text = "Password *";
            this.labelEmail.ForeColor = Color.PaleVioletRed;
            this.labelPassword.ForeColor = Color.PaleVioletRed;
        }
        private void clearColor()
        {

            this.labelEmail.Text = "Email";
            this.labelPassword.Text = "Password";
            this.labelEmail.ForeColor = Color.FromArgb(105, 105, 105);
            this.labelPassword.ForeColor = Color.FromArgb(105, 105, 105);
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.White;
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.Transparent;
        }
    }
}
