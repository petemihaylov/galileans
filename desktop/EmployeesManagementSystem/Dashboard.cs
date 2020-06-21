using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EmployeesManagementSystem.Controllers;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class Dashboard : Form
    {
        // Keeps track of the current logged user
        private User loggedUser;
        private DashboardController controller = new DashboardController();

        // Constructors
        public Dashboard()
        {}
        public Dashboard(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
        }



        private void Dashboard_Load(object sender, EventArgs e)
        {
            RoleDivision();
  
            try
            {
                User[] users = controller.GetUsers();
                showUsersInformation(users);
            }
            catch (Exception)
            {
                throw new Exception("Can't display info correctly!");
            }
        }


        private void RoleDivision()
        {
            // Roles division
            if (this.loggedUser.Role == Models.Role.Manager)
            {
                this.lbTitle.Text = "MANAGEMENT";
                this.btnEmployees.Enabled = true;
                this.btnCancellations.Enabled = true;
                this.btnCancellations.BackColor = Leave;
                this.btnDepartments.Enabled = true;
                
                this.btnStocks.Enabled = true;
                this.btnStocks.BackColor = Leave;

                this.btnStatistics.Enabled = true;
                this.btnStatistics.BackColor = Leave;

                this.btnShifts.Enabled = false;
                this.btnShifts.BackColor = Color.White;

                this.btnTimetable.Enabled = false;
                this.btnTimetable.BackColor = Color.White;

                this.btnCreate.Enabled = false;
                this.btnCreate.Visible = false;
            }
            else if (this.loggedUser.Role == Models.Role.Administrator)
            {
                this.lbTitle.Text = "ADMINISTRATION";
                this.btnEmployees.Enabled = true;
                this.btnDepartments.Enabled = true;
                this.btnShifts.Enabled = true;
                this.btnTimetable.Enabled = true;

                this.btnStocks.Enabled = false;
                this.btnCancellations.Enabled = false;
                this.btnStatistics.Enabled = false;
            }

        }
        public void UpdateDashboard()
        {
            this.dataGridView.Rows.Clear();
            DataTable table = controller.GetUsersTable();
            User[] users = controller.GetUsers();
            showUsersInformation(users);
        }


        // Search functionality
        private void searchField_KeyPress(object sender, KeyPressEventArgs e)
        {

           DataTable table = controller.GetUsersTable();

            // Pressed enter
            if (e.KeyChar == (char)13)
            {

                DataView dv = table.DefaultView;

                // Filter the rows
                dv.RowFilter = string.Format("FullName Like '%{0}%'", controller.RemoveWhiteSpaces(this.searchField.Text));
                this.searchField.Text = "";
                if (dv.ToTable().Rows.Count > 0)
                {
                    User[] users = controller.GetFilteredUsers(dv);
                    showUsersInformation(users);
                }
                else
                {
                    User[] users = controller.GetUsers();
                    showUsersInformation(users);
                }

            }

        }


        // Update information method
        private void showUsersInformation(User[] users)
        {
            // Clean the dataGrid
            controller.ShowDataGridInfo(this.dataGridView, users);
            this.searchField.Text = String.Empty;
        }


        // Data Grid event handling
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Details = 5;
            int Delete = 6;

            if (dataGridView.CurrentCell.ColumnIndex.Equals(Details))
            {
                int index = dataGridView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);

                this.Hide();
                Details details = new Details(id, this.loggedUser, this);
                details.DashoboardUpdate(this);
                details.Show();
            }

            if (dataGridView.CurrentCell.ColumnIndex.Equals(Delete))
            {
                
                // Ask if you want to delete and proccess
                int index = dataGridView.CurrentCell.RowIndex;

                // Find the role
                if (this.loggedUser.Role != Models.Role.Manager)
                {
                    if (!Convert.ToString(dataGridView.Rows[index].Cells[2].Value).Contains("admin"))
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);

                        Delete delete = new Delete(id, this);
                        delete.Show();
                    }
                    else
                    {
                        Warning warning = new Warning(this);
                        warning.Show();
                    }
                }
                else
                {
                    Warning warning = new Warning(this);
                    warning.Show();
                }

            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }

        }


        // Shifts
        private void btnShift_Click(object sender, EventArgs e)
        {
            ShowForm(new Shifts(this.loggedUser));   
        }

        // Create Accounts
        private void btnCreate_MouseClick(object sender, MouseEventArgs e)
        {
            CreateAccounts createAccounts = new CreateAccounts(this);
            createAccounts.Show();
        }
        private void lbCreate_Click(object sender, EventArgs e)
        {
            CreateAccounts createAccounts = new CreateAccounts(this);
            createAccounts.Show();
        }


        // Settings
        private void Settings_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
        }
        private void editAccount_Click(object sender, EventArgs e)
        {
            ShowForm( new AdminDetails(this.loggedUser, this));   
        }
        private void LogOut_Click(object sender, EventArgs e)
        {
            // Show Log In
            ShowForm(new Login());
        }
        private void btnTimetable_Click(object sender, EventArgs e)
        {
            ShowForm(new TimeTable(this.loggedUser, this));
        }

        // Cancellations
        private void btnCancellations_Click(object sender, EventArgs e)
        {
            ShowForm(new Messages(this.loggedUser));
        }


        // Departments
        private void btnDepartments_Click(object sender, EventArgs e)
        {
            ShowForm(new Departments(this.loggedUser));
        }


        // Stocks
        private void btnStocks_Click(object sender, EventArgs e)
        {
            ShowForm(new Stocks(this.loggedUser));
        }


        // Statistics
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            // Show Dashboard
            this.Hide();
            ShowForm(new Statistic(loggedUser, this));
        }

        private void ShowForm(Form form)
        {
            this.Hide();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private Color Enter = Color.DarkGray;
        private Color Leave = Color.LightGray;


        // Hovering onn the the images
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            this.btnExit.BackColor = Enter;
        }
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            this.btnExit.BackColor = Color.White;
        }

        private void btnEmployees_MouseEnter(object sender, EventArgs e)
        {
            this.btnEmployees.BackColor = Enter;
        }
        private void btnEmployees_MouseLeave(object sender, EventArgs e)
        {
            this.btnEmployees.BackColor = Leave;
        }
        private void btnShifts_MouseEnter(object sender, EventArgs e)
        {
            this.btnShifts.BackColor = Enter;
        }
        private void btnShifts_MouseLeave(object sender, EventArgs e)
        {
            this.btnShifts.BackColor = Leave;
        }
        private void btnCancellations_MouseEnter(object sender, EventArgs e)
        {
            this.btnCancellations.BackColor = Enter;
        }
        private void btnCancellations_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancellations.BackColor = Leave;
        }
        private void btnDepartments_MouseEnter(object sender, EventArgs e)
        {
            this.btnDepartments.BackColor = Enter;
        }
        private void btnDepartments_MouseLeave(object sender, EventArgs e)
        {
            this.btnDepartments.BackColor = Leave;
        }
        private void btnStocks_MouseEnter(object sender, EventArgs e)
        {
            this.btnStocks.BackColor = Enter;
        }
        private void btnStocks_MouseLeave(object sender, EventArgs e)
        {
            this.btnStocks.BackColor = Leave;
        }
        private void btnStatistics_MouseEnter(object sender, EventArgs e)
        {
            this.btnStatistics.BackColor = Enter;
        }
        private void btnStatistics_MouseLeave(object sender, EventArgs e)
        {
            this.btnStatistics.BackColor = Leave;
        }
        private void btnCreate_MouseEnter(object sender, EventArgs e)
        {
            this.btnCreate.BackColor = Enter;
        }
        private void btnCreate_MouseLeave(object sender, EventArgs e)
        {
            this.btnCreate.BackColor = Leave;
        }
        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            this.btnSettings.BackColor = Enter;
        }
        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            this.btnSettings.BackColor = Leave;
        }

        private void btnTimetable_MouseEnter(object sender, EventArgs e)
        {
            this.btnTimetable.BackColor = Enter;
        }

        private void btnTimetable_MouseLeave(object sender, EventArgs e)
        {
            this.btnTimetable.BackColor = Leave;
        }
    }
}
