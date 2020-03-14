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
    public partial class ReloadStock : Form
    {

        private DbContext databaseContext = new DbContext();
        private int stockID;
        private Stocks stocksForm;
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
            Stock stock = databaseContext.GetStockByID(stockID);

            
            if (getValidAmount() == -1) return; // checking for error

            stock.Amount += getValidAmount();

            databaseContext.UpdateStockByID(stock.ID, stock.Name, stock.Price, stock.Amount, true);
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
