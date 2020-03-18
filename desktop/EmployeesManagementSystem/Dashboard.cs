using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class Dashboard : Form
    {
        // Variables
        private User[] users;
        private DataTable table;
        private User loggedUser;
        private UserContext userContext = new UserContext();

        // Default constructor
        public Dashboard()
        {

        }

        // Constructor
        public Dashboard(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Roles division
            if(this.loggedUser.Role == Models.Role.Manager.ToString())
            {
                this.btnEmployees.Enabled = true;
                this.btnCancellations.Enabled = true;
                this.btnDepartments.Enabled = true;
                this.btnStocks.Enabled = true;
                this.btnShifts.Enabled = false;
                this.btnStatistics.Enabled = true;
                this.btnCreate.Enabled = false;
            }
            else if(this.loggedUser.Role == Models.Role.Administrator.ToString())
            {
                this.btnEmployees.Enabled = true;
                this.btnCancellations.Enabled = false;
                this.btnDepartments.Enabled = true;
                this.btnStocks.Enabled = false;
                this.btnShifts.Enabled = true;
                this.btnStatistics.Enabled = false;
            }
            
            try
            {
                this.users = this.userContext.GetAllUsers();
                this.table = this.userContext.GetUsersTable();

                showInformation(this.users);
            }
            catch (Exception)
            {
                throw new Exception("Can't display info correctly!");
            }
        }

        public void UpdateDashboard()
        {
            this.dataGridView.Rows.Clear();
            this.table = this.userContext.GetUsersTable();

            User[] users = userContext.GetAllUsers();
            showInformation(users);
        }

        // Search functionality
        private void searchField_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Pressed enter
            if (e.KeyChar == (char)13)
            {

                DataView dv = this.table.DefaultView;

                // Filter the rows
                dv.RowFilter = string.Format("FullName Like '%{0}%'", RemoveWhiteSpaces(this.searchField.Text));
                
                if (dv.ToTable().Rows.Count > 0)
                {
                    User[] users = userContext.GetAllFilteredUsers(dv.ToTable());
                    showInformation(users);
                }
                else
                {
                    User[] users = userContext.GetAllUsers();
                    showInformation(users);
                }

            }

        }

        // Remove the WhiteSpaces
        private string RemoveWhiteSpaces(string text)
        {
            return Regex.Replace(text, @"\s+|\t|\n|\r", String.Empty);
        }


        // Update information method
        private void showInformation(User[] users)
        {
            // Clean the dataGrid
            this.dataGridView.Rows.Clear();

            foreach (User user in users)
            {
                this.dataGridView.Rows.Add(user.GetInfo());
            }
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
                details.Show();

            }

            if (dataGridView.CurrentCell.ColumnIndex.Equals(Delete))
            {
                
                // Ask if you want to delete and proccess
                int index = dataGridView.CurrentCell.RowIndex;

                // Find the role
                if (this.loggedUser.Role != Models.Role.Manager.ToString())
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

            this.Hide();

            Shifts shifts = new Shifts(this.loggedUser);
            shifts.Closed += (s, args) => this.Close();
            shifts.Show();
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

        // Cancellations
        private void btnCancellations_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Cancellations cncl = new Cancellations(this.loggedUser);
            cncl.Closed += (s, args) => this.Close();
            cncl.Show();
        }

        // Departments
        private void btnDepartments_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Departments dep = new Departments(this.loggedUser);
            dep.Closed += (s, args) => this.Close();
            dep.Show();

        }

        // Stocks
        private void btnStocks_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Stocks stock = new Stocks(this.loggedUser);
            stock.Closed += (s, args) => this.Close();
            stock.Show();
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


        // Hovering onn the the images
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
        private void btnCreate_MouseEnter(object sender, EventArgs e)
        {
            this.btnCreate.BackColor = Color.DarkGray;
        }
        private void btnCreate_MouseLeave(object sender, EventArgs e)
        {
            this.btnCreate.BackColor = Color.LightGray;
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
