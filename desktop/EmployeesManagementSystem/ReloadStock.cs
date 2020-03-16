using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System.Windows.Forms;
using System;

namespace EmployeesManagementSystem
{
    public partial class ReloadStock : Form
    {
        private StockContext stockContext = new StockContext();
        private Stocks stocksForm;
        private int stockID;

        public ReloadStock(int stockID, Stocks stocks)
        {
            InitializeComponent();
            this.stockID = stockID;
            this.stocksForm = stocks;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReaload_Click(object sender, EventArgs e)
        {
            Stock stock = stockContext.GetStockByID(stockID);

            
            if (getValidAmount() == -1) return; // checking for error

            stock.Amount += getValidAmount();

            stockContext.UpdateStockByID(stock.ID, stock.Name, stock.Price, stock.Amount, true);
            stocksForm.UpdateStocks();

            this.Close();
        }
        private int getValidAmount()
        {

            if (string.IsNullOrWhiteSpace(cbAmount.Text))
            {
                MessageBox.Show("Please enter an amount!");
                return -1;
            }

            int result = -1;
            try
            {
                result = int.Parse(cbAmount.Text);
            }
            catch (FormatException f)
            {
                MessageBox.Show(f.Message);
                return -1;
            }

            if(result <= 0)
            {
                MessageBox.Show("Could not reload 0 items!");
                return -1;
            }

            return result;

        }
    }
}
