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

        private bool ifExists(string email)
        {
            if (databaseContext.GetUserByEmail(email) != null) return true;
            else return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TO-DO
        }

        private void CreateAccounts_Load(object sender, EventArgs e)
        {
            // TO-DO
        }

        private void exit_Click(object sender, EventArgs e)
        {
            dashboard.Opacity = 1;
            databaseContext.Dispose(true);
            this.Close();
        }
    }
}
