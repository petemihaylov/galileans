using System;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class Departments : Form
    {
        // Variables 
        private User loggedUser;
        private DepartmentContext departmentContext = new DepartmentContext();
        private UserContext userContext = new UserContext();
        private User[] users;
        private Department[] departments;

        // Constructor
        public Departments(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            try
            {
                this.departments = departmentContext.GetAllDepartments();
                this.users = this.userContext.GetAllUsers();
                showInformation(this.departments);
            }
            catch (Exception)
            {
                throw new Exception("Can't display info correctly!");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int btnDelete = 2;
            int nameCol = 1;
           

            // Delete specific Department
            if (this.dataGridView.CurrentCell.ColumnIndex.Equals(btnDelete))
            {
                // Local variables
                int index = this.dataGridView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(this.dataGridView.Rows[index].Cells[0].Value);

                this.departmentContext.DeleteById(id);
                UpdateDepartments();
            }

            // Select and list Users from specific Department
            if (this.dataGridView.CurrentCell.ColumnIndex.Equals(nameCol))
            {
                // Clear all users information
                this.listUsersByDepartment.Items.Clear();

                // Local variables
                int index = this.dataGridView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(this.dataGridView.Rows[index].Cells[0].Value);

                foreach (User u in this.users)
                {
                    if (Convert.ToInt32(u.Department) == id)
                    {
                        this.listUsersByDepartment.Items.Add(u.FullName.ToString());
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
            showInformation(departments);
        }

        private void showInformation(Department[] departments)
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
            Cancellations cncl = new Cancellations(this.loggedUser);
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
            Statistic stat = new Statistic(this.loggedUser);
            stat.Closed += (s, args) => this.Close();
            stat.Show();
        }
        
        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Settings
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
        private void btnShift_MouseEnter(object sender, EventArgs e)
        {
            this.btnShift.BackColor = Color.DarkGray; ;
        }
        private void btnShift_MouseLeave(object sender, EventArgs e)
        {
            this.btnShift.BackColor = Color.LightGray; ;
        }
        private void btnCancellations_MouseEnter(object sender, EventArgs e)
        {
            btnCancellations.BackColor = Color.DarkGray;
        }
        private void btnCancellations_MouseLeave(object sender, EventArgs e)
        {
            btnCancellations.BackColor = Color.LightGray;
        }
        private void btnDepartments_MouseEnter(object sender, EventArgs e)
        {
            btnDepartments.BackColor = Color.DarkGray;
        }
        private void btnDepartments_MouseLeave(object sender, EventArgs e)
        {
            btnDepartments.BackColor = Color.LightGray;
        }
        private void btnStocks_MouseEnter(object sender, EventArgs e)
        {
            btnStocks.BackColor = Color.DarkGray;
        }
        private void btnStocks_MouseLeave(object sender, EventArgs e)
        {
            btnStocks.BackColor = Color.LightGray;
        }
        private void btnStatistics_MouseEnter(object sender, EventArgs e)
        {
            btnCancellations.BackColor = Color.DarkGray;
        }
        private void btnStatistics_MouseLeave(object sender, EventArgs e)
        {
            btnCancellations.BackColor = Color.LightGray;
        }
    }
}
