using EmployeesManagementSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeesManagementSystem
{
    public partial class Stocks : Form
    {
        private DbContext databaseContext = new DbContext();
        private Stock[] stocks;
        private User loggedUser;
        public Stocks(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
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
            Dashboard dashboard = new Dashboard(this.loggedUser);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        private void btnCancellations_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Cancellations cncl = new Cancellations(this.loggedUser);
            cncl.Closed += (s, args) => this.Close();
            cncl.Show();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Departments dep = new Departments(this.loggedUser);
            dep.Closed += (s, args) => this.Close();
            dep.Show();

        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Stocks stock = new Stocks(this.loggedUser);
            stock.Closed += (s, args) => this.Close();
            stock.Show();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Shifts shifts = new Shifts(this.loggedUser);
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateStock createStocks = new CreateStock(this);
            createStocks.Show();
        }
        public void UpdateStocks()
        {
            this.stockDataGrid.Rows.Clear();

            Stock[] stock = databaseContext.GetAllStocks();
            stockDataGrid.Rows.Clear();
            showInformation(stock);
        }

        private void stockDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int btnReload = 5;
            int btnDelete = 6;

            int index = stockDataGrid.CurrentCell.RowIndex;
            int stockId = Convert.ToInt32(stockDataGrid.Rows[index].Cells[0].Value);

            if (stockDataGrid.CurrentCell.ColumnIndex.Equals(btnReload))
            {
                ReloadStock reloadStock = new ReloadStock(stockId, this);
                reloadStock.Show();
            }
            else if (stockDataGrid.CurrentCell.ColumnIndex.Equals(btnDelete))
            {
                databaseContext.DeleteStockByID(stockId);
                UpdateStocks();
            }
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
