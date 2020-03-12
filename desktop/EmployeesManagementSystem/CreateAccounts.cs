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

            if (ifEmptyOrNull(tbFullName.Text, tbHourlyRate.Text, tbPhone.Text, tbEmail.Text, tbPassword.Text, tbConfirmationPassword.Text))
            {

                try
                {
                    string fullName = removeWhiteSpaces(this.tbFullName.Text);
                    float hourlyRate = float.Parse(this.tbHourlyRate.Text);
                    string email = this.tbEmail.Text;
                    string phoneNumber = this.tbPhone.Text;
                    string password = this.tbPassword.Text;
                    string confirmationPassword = this.tbConfirmationPassword.Text;

                    if (isNameValid(fullName) && isEmailValid(email) && isPhoneValid(phoneNumber) && isWageValid(hourlyRate) && isPasswordValid(password) && isPasswordValid(confirmationPassword))
                    {
                        // Validate Password and Conrimation Password
                        if (password.Equals(confirmationPassword))
                        {

                            // Validation of the email before checking if exists in the DB
                            if (ifNotExists(email))
                            {
                                // Generate the password
                                string generatedPassword = Hashing.HashPassword(password);

                                // Determine user's role
                                string role;
                                if (rbEmployee.Checked)
                                {
                                    role = Role.Employee.ToString();
                                } 
                                else if (rbManager.Checked)
                                {
                                    role = Role.Manager.ToString();
                                }
                                else
                                {
                                    role = Role.Administrator.ToString();
                                }

                                // Create new User
                                User user = new User(fullName, email, phoneNumber, generatedPassword, role, hourlyRate);
                                this.databaseContext.InsertUser(user);
                                this.dashboard.UpdateDashboard();
                                this.Close();
                            }
                        }
                        else
                        {
                            
                            MessageBox.Show("Passwords don't match!");
                            
                        }
                    }

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
        private bool ifEmptyOrNull(string fullName, string wage, string phone, string email, string password, string confirmationpassword )
        {

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(fullName))) {
                MessageBox.Show("Change the Name field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(wage)))
            {
                MessageBox.Show("Change the HourlyRate field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(phone)))
            {
                MessageBox.Show("Change the Phone field");
                return false;
            }
            
            if(string.IsNullOrWhiteSpace(removeWhiteSpaces(email)))
            {
                MessageBox.Show("Change the Email field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(password)))
            {
                MessageBox.Show("Change the Password field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(confirmationpassword)))
            {
                MessageBox.Show("Change the Confirmation field");
                return false;
            }

            return true;
        }

        // Remove the WhiteSpaces
        private string removeWhiteSpaces(string text)
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
        private bool isEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("The Email is invalid!");
            }

            return false;
        }

        // Validate the password
        // https://docs.microsoft.com/en-us/dotnet/api/system.web.security.validatepasswordeventargs?view=netframework-4.8
        private bool isPasswordValid(string password)
        {
            Regex rx = new Regex(@"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})");
            
            if (!rx.IsMatch(password))
            {
                MessageBox.Show("The Password is invalid!" + 
                    "Password must be at least 6 characters long and " +
                    "contain at least one number and one special character.");
                return false;
            }

            return true;
        }

        // Validate the name
        private bool isNameValid(string name)
        {
            Regex rx = new Regex(@"^[A-Z][a-zA-Z]*$");
            
            if (!rx.IsMatch(name))
            {
                MessageBox.Show("The Name is invalid! Only \"A-Z\" \"a-z\" characters");
                return false;
            }

            return true;
        }
        
        // Validate the wage
        private bool isWageValid(float wage)
        {
            if(wage < 0.0)
            {
                MessageBox.Show("The Wage is invalid! (wage > 0)");
                return false;
            }

            return true;
        }

        // Validate the phone number
        private bool isPhoneValid(string phone)
        {
            Regex rx = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

            if (!rx.IsMatch(phone))
            {
                MessageBox.Show("The Phone is invalid! (0123456789, 012-345-6789, (012)-345-6789)");
                return false;
            }

            return true;
        }
    }
}
