using System;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;
using EmployeesManagementSystem.Controllers;

namespace EmployeesManagementSystem
{
    public partial class Login : Form
    {
        private LoginController controller = new LoginController();
        public Login()
        {
            InitializeComponent();
            clearColor();

            // Insert data so you can actually login
            controller.PrepareData();
        }

        private void activeLogin()
        {
            clearColor();
            string email = this.tbEmail.Text;
            string password = this.tbPassword.Text;

            // Input validation returns false if it is not valid
            if (controller.InputValidation(email, password) == false)
            {
                warningColors();
                return;
            }
            else
            {
                // Check if user exists 
                User user = controller.FindUser(email);

                if (user != null)
                {

                    if (controller.isPasswordValid(password, user))
                    {
                        // Checking the role of the user
                        if (controller.isRoleValid(user))
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
                        // Error Massage
                        this.labelPassword.Text = "Password *";
                        this.labelPassword.ForeColor = Color.PaleVioletRed;
                        MessageBox.Show("Password not correct");
                    }

                }
                else
                {
                    // Indicates only the email
                    this.labelEmail.Text = "Email *";
                    this.labelEmail.ForeColor = Color.PaleVioletRed;
                    clearFields();
                }
            }

        }


        // On pressed Enter key
        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                activeLogin();
            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            activeLogin();
        }


        private void clearColor()
        {

            this.labelEmail.Text = "Email";
            this.labelPassword.Text = "Password";
            this.labelEmail.ForeColor = Color.FromArgb(105, 105, 105);
            this.labelPassword.ForeColor = Color.FromArgb(105, 105, 105);
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

    }
}
