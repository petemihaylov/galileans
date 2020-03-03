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
            if (tbFirstName.Text == "" || tbLastName.Text == "" || tbHourlyRate.Text == "" || tbPhone.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("Please fill in everything");
            }
            else
            {
                try
                {
                    string connectionStr = "Server=studmysql01.fhict.local;Uid=dbi391065;Database=dbi391065;Pwd=Galileans   ;";
                    string query = $"INSERT into users(FirstName, LastName,	Email, Role, HourlyWage) values('{tbFirstName.Text}', '{tbLastName.Text}', '{tbEmail.Text}', 'employee', '{tbHourlyRate.Text}');";
                    MySqlConnection connection = new MySqlConnection(connectionStr);
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader;
                    connection.Open(); // make a new account and add it to the database
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

        }

        private void CreateAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}
