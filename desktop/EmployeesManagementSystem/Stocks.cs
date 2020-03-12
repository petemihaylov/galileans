using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesManagementSystem
{
    public partial class Stocks : Form
    {
        private DbContext databaseContext = new DbContext();

        public Stocks()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        private void btnCancellations_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Hide();
            // Show Dashboard
            Cancellations cncl = new Cancellations();
            cncl.Closed += (s, args) => this.Close();
            cncl.Show();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Hide();
            // Show Dashboard
            Departments dep = new Departments();
            dep.Closed += (s, args) => this.Close();
            dep.Show();

        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Hide();
            // Show Dashboard
            Stocks stock = new Stocks();
            stock.Closed += (s, args) => this.Close();
            stock.Show();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Hide();
            // Show Dashboard
            Shifts shifts = new Shifts();
            shifts.Closed += (s, args) => this.Close();
            shifts.Show();
        }
    }
}
