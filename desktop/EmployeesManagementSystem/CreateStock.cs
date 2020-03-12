using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class CreateStock : Form
    {
        private DbContext databaseContext = new DbContext();
        private Stocks stocks;

        public CreateStock(Stocks stocks)
        {
            InitializeComponent();
            this.stocks = stocks;

        }

        private void CreateStock_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateStock_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbAmount.Text) && !String.IsNullOrEmpty(tbName.Text) && !String.IsNullOrEmpty(tbPrice.Text))
            {
                string name = tbName.Text;
                int amount = Convert.ToInt32(tbAmount.Text);
                double price = Convert.ToDouble(tbPrice.Text);

                if(amountIsValid(amount) && priceIsValid(price))
                {
                    Stock stock = new Stock(name, amount, price, true);
                    this.databaseContext.InsertStock(stock);
                    this.stocks.UpdateStocks();
                    this.Close();
                }
            }
        }

        private bool amountIsValid(int amount)
        {
            if (amount <= 0)
            {
                MessageBox.Show("The amount entered is invalid!");
                return false;
            }  
            return true;
        }

        private bool priceIsValid(double price)
        {
            if (price <= 0)
            {
                MessageBox.Show("The price entered is invalid!");
                return false;
            }
            return true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Close();
        }
    }
}
