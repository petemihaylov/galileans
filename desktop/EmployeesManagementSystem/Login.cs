using EmployeesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesManagementSystem
{
    public partial class Login : Form
    {

        private DbContext databaseContext = new DbContext();
        public Login()
        {
            InitializeComponent();
            clearColor();
        }
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

        private void clearFields()
        {
            this.tbEmail.Text = "";
            this.tbPassword.Text = "";
        }
        private void warningColor()
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
        private bool ifExists(string email)
        {
            if (databaseContext.GetUserByEmail(email) != null)return true;
            else return false;
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
