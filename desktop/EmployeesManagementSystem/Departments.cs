using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Controllers;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class Departments : Form
    {
        // Variables 
        private User loggedUser;
        private DepartmentContext departmentContext = new DepartmentContext();
        private DepartmentController controller = new DepartmentController();
        private UserDepartmentContext userDepartmentContext = new UserDepartmentContext();
        private UserContext userContext = new UserContext();
        private ShiftContext shiftContext = new ShiftContext();
        private StockContext stockContext = new StockContext();
        private List<User> employees = new List<User>();
        private Department[] departments;

        // Constructor
        public Departments(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            // Roles division
            if (this.loggedUser.Role == Role.Manager)
            {
                this.btnEmployees.Enabled = true;
                this.btnCancellations.Enabled = true;
                this.btnDepartments.Enabled = true;
                this.btnStocks.Enabled = true;
                this.btnShifts.Enabled = false;
                this.btnStatistics.Enabled = true;
            }
            else if (this.loggedUser.Role == Role.Administrator)
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
                this.departments = departmentContext.GetAllDepartments();
                showDepartmentsInformation(this.departments);
            }
            catch (Exception)
            {
                throw new Exception("Can't display info correctly!");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int btnDelete = 2;

            // Check if there are departments in the list
            if(this.dataGridView.Rows.Count > 0)
            {
                // Delete specific Department
                var btn = this.dataGridView.CurrentCell.ColumnIndex.Equals(btnDelete);
                if (btn)
                {
                    // Local variables
                    int index = this.dataGridView.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(this.dataGridView.Rows[index].Cells[0].Value);

                    this.userDepartmentContext.DeleteByDepartment(id);
                    this.shiftContext.DeleteByDepartment(id);
                    this.stockContext.DeleteByDepartment(id);

                    this.departmentContext.DeleteById(id);
                    UpdateDepartments();
                }
                else { 
                    // Clear all users information
                    this.listUsersByDepartment.Items.Clear();

                    // Local variables
                    int index = this.dataGridView.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(this.dataGridView.Rows[index].Cells[0].Value);
                    string department = Convert.ToString(this.dataGridView.Rows[index].Cells[1].Value);

                    lblDepartment.Text = "All employees in " + department;
                    employees.Clear();
                    foreach (User u in userContext.GetAllUsers())
                    {
                        var ret = userDepartmentContext.GetUserByDepartment(departmentContext.GetDepartmentByName(department).ID);
                        if (ret != null && ret.ID == u.ID)
                        {
                            employees.Add(u);
                            this.listUsersByDepartment.Items.Add("#" + u.ID + " " + u.FullName.ToString());
                        }
                    }
                }
            }
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateDepartment createDepartment = new CreateDepartment(this);
            createDepartment.Show();
        }

        public void UpdateDepartments()
        {
            this.dataGridView.Rows.Clear();

            Department[] departments = departmentContext.GetAllDepartments();
            showDepartmentsInformation(departments);
        }

        private void showDepartmentsInformation(Department[] departments)
        {
            // Clean the dataGrid
            this.dataGridView.Rows.Clear();

            foreach (Department department in departments)
            {
                if (department.ID > 0) // exclude Administration department
                {
                    this.dataGridView.Rows.Add(department.GetInfo());
                }
            }
        }

        // Shifts
        private void btnShift_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Shifts shifts = new Shifts(this.loggedUser);
            shifts.Closed += (s, args) => this.Close();
            shifts.Show();
        }

        // Cancellations
        private void btnCancellations_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Messages cncl = new Messages(this.loggedUser);
            cncl.Closed += (s, args) => this.Close();
            cncl.Show();
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

        // Employees
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard(this.loggedUser);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }
        
        // Statistics
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Statistic stat = new Statistic(loggedUser, this);
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
        }

        private void lbSettings_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
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

        private void listUsersByDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listUsersByDepartment.SelectedIndex != -1)
            {
                int id = employees[listUsersByDepartment.SelectedIndex].ID;
                this.Hide();
                Details details = new Details(id, this.loggedUser, this);
                details.Show();
            }
        }

        // Search functionality
        private void searchField_KeyPress(object sender, KeyPressEventArgs e)
        {

            DataTable table = controller.GetDepartmentTable();

            // Pressed enter
            if (e.KeyChar == (char)13)
            {

                DataView dv = table.DefaultView;

                // Filter the rows
                dv.RowFilter = string.Format("Name Like '%{0}%'", controller.RemoveWhiteSpaces(this.searchField.Text));

                if (dv.ToTable().Rows.Count > 0)
                {
                    Department[] departments = controller.GetFilteredDepartments(dv);
                    showDepartmentsInformation(departments);
                }
                else
                {
                    Department[] departments = controller.GetDepartments();
                    showDepartmentsInformation(departments);
                }

            }

        }
    }
}
