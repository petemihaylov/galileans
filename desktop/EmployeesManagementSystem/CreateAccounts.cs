using System;
using EmployeesManagementSystem.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EmployeesManagementSystem
{
    public partial class CreateAccounts : Form
    {
        private DbContext databaseContext = new DbContext();
        private Dashboard dashboard;
        public CreateAccounts(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the fields are not empty IsNullOrWhiteSpace is securer in the NullorEmpty you can pass the check by inputing space \t or \n
            if (string.IsNullOrWhiteSpace(tbFullName.Text) || string.IsNullOrWhiteSpace(tbHourlyRate.Text) || string.IsNullOrWhiteSpace(tbPhone.Text) || string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Please fill in everything");
            }
            else
            {

                try
                {
                    string fullName = this.tbFullName.Text;
                   
                    float hourlyRate = float.Parse(this.tbHourlyRate.Text); //tbHourlyRate can be -123
                    
                    string email = this.tbEmail.Text;
                    string phoneNumber = this.tbPhone.Text;

                    
                    if (ifExists(email))
                    {
                        MessageBox.Show("The Email is an unique key! Could not create account with this email!");
                        return;
                    }
                    // There should be a validation for every field




                    //string generatedPassword = Hashing.HashPassword("mypassword123"); hah XD
                    string generatedPassword = Hashing.HashPassword(this.txtPassword.Text);

                    User user = new User(fullName, email, phoneNumber, generatedPassword, Role.Employee.ToString(), hourlyRate);
                    databaseContext.InsertUser(user);
                    dashboard.Opacity = 1;
                    dashboard.UpdateDashboard();
                    Hide();
                }
                catch (Exception ex) //catch(FormatException) 
                {
                    //throw new FormatException("the message should be here");
                    MessageBox.Show(ex.Message);

                }
            }

            databaseContext.Dispose(true);
            this.Close();
        }

        // Check if an email exists
        private bool ifExists(string email)
        {
            if (databaseContext.GetUserByEmail(email) != null) return true;
            else return false;
        }

        // Exit button
        private void exit_Click(object sender, EventArgs e)
        {
            dashboard.Opacity = 1;
            databaseContext.Dispose(true);
            this.Close();
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
    }
}
