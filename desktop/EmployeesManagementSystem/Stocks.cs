using EmployeesManagementSystem.Models;
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
        private Stock[] stocks;

        public Stocks()
        {
            InitializeComponent();
        }


        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void showInformation(Stock[] stocks)
        {
            // Clean the dataGrid

            stockDataGrid.Rows.Clear();

            foreach (Stock stock in stocks)
            {
                this.stockDataGrid.Rows.Add(stock.GetInfo());
            }
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

        private void Stocks_Load(object sender, EventArgs e)
        {
            try
            {
                this.stocks = databaseContext.GetAllStocks();

                showInformation(this.stocks);
            }
            catch (Exception)
            {
                throw new Exception("Can't display info correctly!");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Close();

            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.LightGray;
            this.exit.BackColor = color;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.White;
            this.exit.BackColor = color;
        }

        private void btnCreate_MouseEnter(object sender, EventArgs e)
        {

            Color color = Color.DarkGray;
            this.btnCreate.BackColor = color;
        }

        private void btnCreate_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.LightGray;
            this.btnCreate.BackColor = color;
        }
    }
}
