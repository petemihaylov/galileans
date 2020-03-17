using System;
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
                this.dataGridView.Rows.Add(department.GetInfo());
            }
        }

        // Buttons
        private void btnShift_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Shifts shifts = new Shifts(this.loggedUser);
            shifts.Closed += (s, args) => this.Close();
            shifts.Show();
        }
        private void btnCancellations_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Cancellations cncl = new Cancellations(this.loggedUser);
            cncl.Closed += (s, args) => this.Close();
            cncl.Show();
        }
        private void btnStocks_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Stocks stock = new Stocks(this.loggedUser);
            stock.Closed += (s, args) => this.Close();
            stock.Show();
        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard(this.loggedUser);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
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

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.Color.DarkGray;
            this.exit.BackColor = color;
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.Color.White;
            this.exit.BackColor = color;
        }
    }
}
