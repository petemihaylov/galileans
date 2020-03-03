using System;
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
        public CreateAccounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the fields are not empty
            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbHourlyRate.Text) && !string.IsNullOrEmpty(tbPhone.Text) && !string.IsNullOrEmpty(tbEmail.Text))
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
                    string query = $"INSERT into users(FirstName, LastName,	Email, Role, HourlyWage) values('{tbFirstName.Text}', '{tbLastName.Text}', '{tbEmail.Text}', 'employee', '{tbHourlyRate.Text}');";
                    
                    MySqlConnection connection = new MySqlConnection(connectionStr);
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader;
                    
                    // Make a new account and add it to the Database
                    connection.Open(); 
                    
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
