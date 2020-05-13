using System;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using System.Text.RegularExpressions;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class Login : Form
    {
        private UserContext userContext = new UserContext();
        private ShiftContext shiftContext = new ShiftContext();
        private ImageContext imageContext = new ImageContext();
        private UserDepartmentContext userDepartmentContext = new UserDepartmentContext();
        
        public Login()
        {
            InitializeComponent();
            clearColor();

            //insert data so you can actually login
            var user = userContext.GetUserByEmail("admin@mail.com");
            if (user != null)
            {
                int adminID = user.ID;
                shiftContext.DeleteShiftsByUser(adminID);
                imageContext.DeleteImgByUserId(adminID);
                userDepartmentContext.DeleteByUser(adminID);
                userContext.DeleteUserByEmail("admin@mail.com");
            }
            userContext.Insert(new Administrator(-1, "admin", "admin@mail.com", "+31 6430 2303", Hashing.HashPassword("admin"), 0));
        }

        private void activeLogin()
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
                User user = userContext.GetUserByEmail(email);
                if (!IsEmailValid(email) && user == null)
                {
                    // Indicates only the email
                    this.labelEmail.Text = "Email *";
                    this.labelEmail.ForeColor = Color.PaleVioletRed;

                    return;
                }


            }


            if (ifExists(email))
            {
                User user = userContext.GetUserByEmail(email);

                if (Hashing.ValidatePassword(password, user.Password))
                {
                    // Checking the role of the user
                    if (user.Role == Role.Administrator)
                    {
                        this.Hide();
                        // Show Dashboard
                        Dashboard dashboard = new Dashboard(user);
                        dashboard.Closed += (s, args) => this.Close();
                        dashboard.Show();
                    }
                    else if (user.Role == Role.Manager)
                    {
                        this.Hide();
                        // Show Dashboard
                        Dashboard dashboard = new Dashboard(user);
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            activeLogin();            
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
            if (userContext.GetUserByEmail(email) != null) return true;
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
            // Closing the db connection 
            this.Close();

            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.DarkGray;
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.Transparent;
        }

        // Enter in during the login form
        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                activeLogin();
            }

        }
    }
}
