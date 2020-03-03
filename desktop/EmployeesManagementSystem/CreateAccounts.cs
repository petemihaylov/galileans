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


namespace EmployeesManagementSystem
{
    public partial class CreateAccounts : Form
    {
        private DbContext databaseContext = new DbContext();

        public CreateAccounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the fields are not empty
            if (!string.IsNullOrEmpty(tbFullName.Text) && !string.IsNullOrEmpty(tbHourlyRate.Text) && !string.IsNullOrEmpty(tbPhone.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            {
                MessageBox.Show("Please fill in everything");
            }
            else
            {

                try
                {
                    // Connection string 
                    // TO-DO # Use Data/DbContext for any Database requests
                    string connectionStr = "Server=studmysql01.fhict.local;Uid=dbi391065;Database=dbi391065;Pwd=Galileans;";
                    
                    // Query request to the Database
                    string query = $"INSERT into users(FullName,Email, PhoneNumber, Role, HourlyWage) values('{tbFullName.Text}', '{tbEmail.Text}', '{tbPhone.Text}', 'Employee', '{tbHourlyRate.Text}');";

                    MySqlConnection connection = new MySqlConnection(connectionStr);
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader;
                    
                    // Make a new account and add it to the Database
                    connection.Open();

                    string fullName = this.tbFullName.Text;
                    float hourlyRate = float.Parse(this.tbHourlyRate.Text);
                    string email = this.tbEmail.Text;
                    int phoneNumber = Convert.ToInt32(this.tbPhone.Text);
                    string generatedPassword = Hashing.HashPassword("mypassword123");

                    User user = new User(fullName, email, phoneNumber, generatedPassword, Role.Employee.ToString(), hourlyRate);
                    databaseContext.InsertUser(user);

                    reader = cmd.ExecuteReader();
                    Hide();
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TO-DO
        }

        private void CreateAccounts_Load(object sender, EventArgs e)
        {
            // TO-DO
        }
    }
}
