using System;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;


namespace EmployeesManagementSystem
{
    public partial class Cancellations : Form
    {

        // Variables
        private CancellationContext cancellationContext = new CancellationContext();
        private User loggedUser;
       
        // Default constructor
        public Cancellations()
        {

        }

        // Constructor
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

        // datagrid cell click needs a refactoring
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dataGridView.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1 && dataGridView.CurrentCell != null)
            {
                // open another message box with the whole description
                txDescription.Text = "Description: " + dataGridView.CurrentCell.Value.ToString();
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

        // Employees
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard(this.loggedUser);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        // Departments
        private void btnDepartments_Click(object sender, EventArgs e)
        {

            this.Hide();
            // Show Dashboard
            Departments departments = new Departments(this.loggedUser);
            departments.Closed += (s, args) => this.Close();
            departments.Show();
        }

        // Stocks
        private void btnStocks_Click(object sender, EventArgs e)
        {

            this.Hide();
            // Show Dashboard
            Stocks stocks = new Stocks(this.loggedUser);
            stocks.Closed += (s, args) => this.Close();
            stocks.Show();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Statistic stat = new Statistic(this.loggedUser);
            stat.Closed += (s, args) => this.Close();
            stat.Show();
        }

        // Settings
        private void Settings_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
        }
        private void editAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Admin details
            AdminDetails adminDetails = new AdminDetails(this.loggedUser, this);
            adminDetails.Closed += (s, args) => this.Hide();
            adminDetails.Show();
        }
        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Log In
            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        // Statistics
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Statistic stat = new Statistic(this.loggedUser);
            stat.Closed += (s, args) => this.Close();
            stat.Show();
        }

        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }

        // Hovering
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            this.btnExit.BackColor = Color.LightGray;
        }
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            this.btnExit.BackColor = Color.White;
        }
        private void btnEmployees_MouseEnter(object sender, EventArgs e)
        {
            this.btnEmployees.BackColor = Color.DarkGray;
        }
        private void btnEmployees_MouseLeave(object sender, EventArgs e)
        {
            this.btnEmployees.BackColor = Color.LightGray;
        }
        private void btnShifts_MouseEnter(object sender, EventArgs e)
        {
            this.btnShifts.BackColor = Color.DarkGray;
        }
        private void btnShifts_MouseLeave(object sender, EventArgs e)
        {
            this.btnShifts.BackColor = Color.LightGray;
        }
        private void btnCancellations_MouseEnter(object sender, EventArgs e)
        {
            this.btnCancellations.BackColor = Color.DarkGray;
        }
        private void btnCancellations_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancellations.BackColor = Color.LightGray;
        }
        private void btnDepartments_MouseEnter(object sender, EventArgs e)
        {
            this.btnDepartments.BackColor = Color.DarkGray;
        }
        private void btnDepartments_MouseLeave(object sender, EventArgs e)
        {
            this.btnDepartments.BackColor = Color.LightGray;
        }
        private void btnStocks_MouseEnter(object sender, EventArgs e)
        {
            this.btnStocks.BackColor = Color.DarkGray;
        }
        private void btnStocks_MouseLeave(object sender, EventArgs e)
        {
            this.btnStocks.BackColor = Color.LightGray;
        }
        private void btnStatistics_MouseEnter(object sender, EventArgs e)
        {
            this.btnStatistics.BackColor = Color.DarkGray;
        }
        private void btnStatistics_MouseLeave(object sender, EventArgs e)
        {
            this.btnStatistics.BackColor = Color.LightGray;
        }
    }
}
