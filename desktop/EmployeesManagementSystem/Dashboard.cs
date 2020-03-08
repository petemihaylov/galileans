using System;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class Dashboard : Form
    {
        private DbContext databaseContext = new DbContext();

        public Dashboard()
        {
            InitializeComponent();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                User[] users = databaseContext.GetAllUsers();
                foreach(User user in users)
                {
                    dataGridView.Rows.Add(user.GetInfo());
                }
            }
            catch (Exception)
            {
                throw new Exception("Can't display info correctly");
            }
        }
        public void UpdateDashboard()
        {
                this.dataGridView.Rows.Clear();
                User[] users = databaseContext.GetAllUsers();
                foreach (User user in users)
                {
                    this.dataGridView.Rows.Add(user.GetInfo());
                }
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Details = 4;
            int Delete = 5;
            if (dataGridView.CurrentCell.ColumnIndex.Equals(Details))
            {
                int index = dataGridView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                Details details = new Details(id);
                details.Show();
                this.Hide();
            }

            if (dataGridView.CurrentCell.ColumnIndex.Equals(Delete))
            {
                //ask if you want to delete and proccess
                int index = dataGridView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                Delete delete = new Delete(id, this);
                delete.Show();

             }

        }


        // Buttons
        private void exit_Click(object sender, EventArgs e)
        {
            // Closing the db connection 
            databaseContext.Dispose(true);
            this.Close();

            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }

        }
        private void btn4_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Hide();
            // Show Dashboard
            Shifts shifts = new Shifts();
            shifts.Closed += (s, args) => this.Close();
            shifts.Show();
        }
        private void createPanel_MouseClick(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.6;
            CreateAccounts createAccounts = new CreateAccounts(this);
            createAccounts.Show();
        }
        private void lbCreate_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.6;
            CreateAccounts createAccounts = new CreateAccounts(this);
            createAccounts.Show();
        }

        // Hovering
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.LightGray;
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.White;
        }
        private void btn1_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.btn1.BackColor = color;
        }
        private void btn1_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.LightGray;
            this.btn1.BackColor = color;
        }
        private void btn2_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.btn2.BackColor = color;
        }
        private void btn2_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.LightGray;
            this.btn2.BackColor = color;
        }      
        private void btn3_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;

            this.btn3.BackColor = color;
        }
        private void btn3_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.LightGray;

            this.btn3.BackColor = color;
        }      
        private void btn4_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.btn4.BackColor = color;
        }
        private void btn4_MouseLeave(object sender, EventArgs e)
        {
            Color color = Color.LightGray;
            this.btn4.BackColor = color;
        }
        private void createPanel_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.createPanel.BackColor = color;
        }
        private void createPanel_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.LightGray;
            this.createPanel.BackColor = color;
        }
    }
}
