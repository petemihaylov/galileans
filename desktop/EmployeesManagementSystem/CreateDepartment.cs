using System;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class CreateDepartment : Form
    {
        private Departments departments;
        private DepartmentContext departmentContext = new DepartmentContext();

        public CreateDepartment(Departments form)
        {
            InitializeComponent();
            this.departments = form;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbName.Text))
            {
                string name = tbName.Text;
                Department department = new Department(name);
                departmentContext.Insert(department);
                this.departments.UpdateDepartments();
                this.Close();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
