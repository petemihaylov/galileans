using System;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;


namespace EmployeesManagementSystem
{
    public partial class Cancellations : Form
    {


        private CancellationContext cancellationContext = new CancellationContext();
        private User loggedUser;
       

        public Cancellations(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
        }

        private void Complaint_Load(object sender, EventArgs e)
        {
            //needs to upload as the program runs in the future
            try
            {
                Models.Cancellations[] cancels = cancellationContext.GetAnnouncements();
                foreach (Models.Cancellations cancel in cancels)
                {
                    dataGridView.Rows.Add(cancel.GetInfo());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();

            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }


        // datagrid cell click needs a refactoring
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell.ColumnIndex.Equals(4) && e.RowIndex != -1 && dataGridView.CurrentCell != null)
            {
                // open another message box with the whole description
                MessageBox.Show("Description:" + dataGridView.CurrentCell.Value.ToString());
            }
            else if (dataGridView.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1 && dataGridView.CurrentCell != null)
            {
                int index = dataGridView.CurrentCell.RowIndex;
                //MessageBox.Show(Convert.ToString(dataGridView.Rows[index].Cells[0].Value));
                int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                cancellationContext.DeleteById(id);
                dataGridView.Rows.Remove(dataGridView.Rows[index]);

            }


        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Shifts shifts = new Shifts(this.loggedUser);
            shifts.Closed += (s, args) => this.Close();
            shifts.Show();
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.BackColor = Color.DarkGray;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackColor = Color.LightGray;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard(this.loggedUser);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {

            this.Hide();
            // Show Dashboard
            Departments departments = new Departments(this.loggedUser);
            departments.Closed += (s, args) => this.Close();
            departments.Show();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {

            this.Hide();
            // Show Dashboard
            Stocks stocks = new Stocks(this.loggedUser);
            stocks.Closed += (s, args) => this.Close();
            stocks.Show();
        }

        private void editAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            AdminDetails adminDetails = new AdminDetails(this.loggedUser);
            adminDetails.Closed += (s, args) => this.Close();
            adminDetails.Show();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Log In
            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Statistic stat = new Statistic(this.loggedUser);
            stat.Closed += (s, args) => this.Close();
            stat.Show();
        }
    }
}
