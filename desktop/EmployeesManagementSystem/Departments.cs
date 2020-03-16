using System;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class Departments : Form
    {
        private User loggedUser;
        public Data.DepartmentContext departmentContext = new Data.DepartmentContext();

        public Departments(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            try
            {
                Department[] departments = departmentContext.GetAllDepartments();
                showInformation(departments);
            }
            catch (Exception)
            {
                throw new Exception("Can't display info correctly!");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int btnDelete = 2;

            int index = dataGridView.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);

            if (dataGridView.CurrentCell.ColumnIndex.Equals(btnDelete))
            {
                departmentContext.DeleteById(id);
                UpdateDepartments();
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
            dataGridView.Rows.Clear();

            foreach (Department department in departments)
            {
                this.dataGridView.Rows.Add(department.GetInfo());
            }
        }

        // buttons to other forms
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
    }
}
