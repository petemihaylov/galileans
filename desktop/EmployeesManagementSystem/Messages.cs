using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using System.Text.RegularExpressions;
using EmployeesManagementSystem.Models;


namespace EmployeesManagementSystem
{
    public partial class Messages : Form
    {
        private Color Enter = Color.DarkGray;
        private Color Leave = Color.LightGray;

        private NotificationContext notificationContext = new NotificationContext();
        private CancellationContext cancellationContext = new CancellationContext();
        private User loggedUser;
        private List <Cancellation> req = new List<Cancellation>();

        public Messages(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
        }

        
        private void RoleDivision()
        {
            // Roles division
            if (this.loggedUser.Role == Models.Role.Manager)
            {
                this.btnEmployees.Enabled = true;
                this.btnCancellations.Enabled = true;
                this.btnCancellations.BackColor = Enter;
                this.btnDepartments.Enabled = true;

                this.btnStocks.Enabled = true;
                this.btnStocks.BackColor = Enter;

                this.btnStatistics.Enabled = true;
                this.btnStatistics.BackColor = Enter;

                this.btnShifts.Enabled = false;
                this.btnShifts.BackColor = Leave;

                this.btnTimetable.Enabled = true;
                this.btnTimetable.BackColor = Enter;

            }
            else if (this.loggedUser.Role == Models.Role.Administrator)
            {
                this.btnEmployees.Enabled = true;
                this.btnDepartments.Enabled = true;
                this.btnShifts.Enabled = true;

                this.btnStocks.Enabled = false;
                this.btnCancellations.Enabled = false;
                this.btnTimetable.Enabled = false;
                this.btnStatistics.Enabled = false;
            }

        }


        private void Complaint_Load(object sender, EventArgs e)
        {
            RoleDivision();

            // needs to upload as the program runs in the future
            try
            {
                Cancellation[] cancels = cancellationContext.GetCancellations();
                foreach (Cancellation cancel in cancels)
                {
                    dataGridView.Rows.Add(cancel.GetInfo());
                    req.Add(cancel);
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
            if (dataGridView.CurrentCell.ColumnIndex.Equals(4) && e.RowIndex != -1 && dataGridView.CurrentCell != null)
            {
                txDescription.Text = "Message: \n" + dataGridView.CurrentCell.Value.ToString();
            }
            else if (dataGridView.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1 && dataGridView.CurrentCell != null)
            {
                int index = dataGridView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                cancellationContext.DeleteById(id);
                dataGridView.Rows.Remove(dataGridView.Rows[index]);
            }


        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
            Cancellation c = cancellationContext.GetCancellationByID(id);
            c.State = CState.Declined;
            cancellationContext.UpdateCancellation(c);
            MessageBox.Show("The cancellation request has been denied. The employee has been notified.");
            UpdateGrid();
            Notification n = new Notification("Your cancellation request has been rejected!", c.Employee);

            notificationContext.Insert(n);

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
            Cancellation c = cancellationContext.GetCancellationByID(id);
            c.State = CState.Approved;
            cancellationContext.UpdateCancellation(c);
            MessageBox.Show("The cancellation request has been approved. The employee has been notified.");
            UpdateGrid();

            Notification n = new Notification("Your cancellation request has been accepted!", c.Employee);
            notificationContext.Insert(n);
        }
        private void UpdateGrid()
        {
            dataGridView.Rows.Clear();
            req.Clear();
            Cancellation[] cancels = cancellationContext.GetCancellations();
            foreach (Cancellation cancel in cancels)
            {
                dataGridView.Rows.Add(cancel.GetInfo());
                req.Add(cancel);
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

        private void btnEmployees_Click(object sender, EventArgs e)
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

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Statistic stat = new Statistic(loggedUser, this);
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
        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            this.btnSettings.BackColor = Color.DarkGray;
        }
        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            this.btnSettings.BackColor = Color.LightGray;
        }

        
    }
}
