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
        // Variables 
        private DbContext databaseContext = new DbContext();
        private Dashboard dashboard;

        // Constructor
        public CreateAccounts(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }


        // Functional Buttons

        // Create Button
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {

            if (ifEmptyOrNull(tbFullName.Text, tbHourlyRate.Text, tbPhone.Text, tbEmail.Text))
            {

                try
                {
                    string fullName = this.tbFullName.Text;
                    float hourlyRate = float.Parse(this.tbHourlyRate.Text);
                    string email = this.tbEmail.Text;
                    string phoneNumber = this.tbPhone.Text;

                    if (IsEmailValid(email)) {
                        // Validation of the email before checking if exists in the DB
                        if (ifNotExists(email))
                        {
                           
                            
                        }
                    }
                   




                   
                    string generatedPassword = Hashing.HashPassword(this.tbPassword.Text);

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
            

        }

        // Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Close();
        }


        // Additional Methods

        // Empty fields
        private bool ifEmptyOrNull(string fullName, string wage, string phone, string email )
        {

            if (string.IsNullOrWhiteSpace(RemoveWhiteSpaces(tbFullName.Text))) {
                MessageBox.Show("Change the Name field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(RemoveWhiteSpaces(tbHourlyRate.Text)))
            {
                MessageBox.Show("Change the HourlyRate field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(RemoveWhiteSpaces(tbPhone.Text)))
            {
                MessageBox.Show("Change the Phone field");
                return false;
            }
            
            if(string.IsNullOrWhiteSpace(RemoveWhiteSpaces(tbEmail.Text)))
            {
                MessageBox.Show("Change the Email field");
                return false;
            }
                
            return true;
        }

        // Remove the WhiteSpaces
        private string RemoveWhiteSpaces(string text)
        {
            return Regex.Replace(text, @"\s+|\t|\n|\r", String.Empty);
        }

        // Check if an email exists
        private bool ifNotExists(string email)
        {
            if (databaseContext.GetUserByEmail(email) != null)
            {
                MessageBox.Show("The Email is not unique!");
                return false;
            }

            return true;
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
                MessageBox.Show("The Email is unvalid!");
            }

            return false;
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
