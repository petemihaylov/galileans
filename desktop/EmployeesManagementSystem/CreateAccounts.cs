using System;
using System.Net.Mail;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using System.Text.RegularExpressions;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class CreateAccounts : Form
    {

        // Variables
        private Dashboard dashboard;
        private UserContext userContext = new UserContext();
        private DepartmentContext departmentContext = new DepartmentContext();
        private UserDepartmentContext userDepartmentContext = new UserDepartmentContext();
        private Department[] departments;

        // Default Constructor
        public CreateAccounts()
        {

        }

        // Constructor
        public CreateAccounts(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        private void CreateAccounts_Load(object sender, EventArgs e)
        {
            departments = departmentContext.GetAllDepartments();
            if (departments.Length > 0)
            {
                foreach (Department d in departments)
                {
                    cbDepartments.Items.Add(d.Name);
                }
            }
            
        }

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

                    Enum.TryParse(cbRole.Text, out Role role);
                    int department = 1;
                 
                    if (cbDepartments.SelectedIndex  != -1)
                    {
                         department = departments[cbDepartments.SelectedIndex].ID;
                        
                    }

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

                                // Create new User
                                User user = new User(0,fullName, email, phoneNumber, generatedPassword, role, hourlyRate);
                                this.userContext.Insert(user);
                                // Insert in UserDepartment Table
                                UserDepartment ud = new UserDepartment();

                                ud.Department.ID = department;
                                ud.User = userContext.GetUserByEmail(email);
                                this.userDepartmentContext.Insert(ud);

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ifEmptyOrNull(string fullName, string hourlyRate, string phone, string email, string password, string confirmationpassword)
        {

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(fullName)))
            {
                MessageBox.Show("Change the Name field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(hourlyRate)))
            {
                MessageBox.Show("Change the Hourly Rate field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(phone)))
            {
                MessageBox.Show("Change the Phone Number field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(email)))
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
        
        // Validation removeWhiteSpaces
        private string removeWhiteSpaces(string text)
        {
            return Regex.Replace(text, @"\s+|\t|\n|\r", String.Empty);
        }

        // Check the email if exists
        private bool ifNotExists(string email)
        {
            if (userContext.GetUserByEmail(email) != null)
            {
                MessageBox.Show("The Email inserted is not unique!");
                return false;
            }

            return true;
        }

        // Email validation
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

        // Correction of the password
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
                MessageBox.Show("The Name is invalid! Only \"A-Z\" \"a-z\" characters, at least one uppercase letter");
                return false;
            }

            return true;
        }

        // Validate the wage
        private bool isWageValid(float hourlyRate)
        {
            if (hourlyRate <= 0.0)
            {
                MessageBox.Show("The Wage is invalid! The wage inserted needs to be greater than 0)");
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
