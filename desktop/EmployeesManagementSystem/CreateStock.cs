using System;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class CreateStock : Form
    {
        private Stocks stocks;
        private StockContext stockContext = new StockContext();

        private DepartmentContext departmentContext = new DepartmentContext();
        private Department[] departments;

        public CreateStock(Stocks stocks)
        {
            InitializeComponent();
            this.stocks = stocks;

            departments = departmentContext.GetAllDepartments();
            if (departments.Length > 0)
            {
                foreach (Department d in departments)
                {
                    cbDepartments.Items.Add(d.Name);
                }
                cbDepartments.SelectedIndex = 0;
            }

        }

        private void btnCreateStock_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbAmount.Text) && !String.IsNullOrEmpty(tbName.Text) && !String.IsNullOrEmpty(tbPrice.Text) && !String.IsNullOrEmpty(cbDepartments.Text))
            {
                string name = tbName.Text;
                int amount = 0;
                double price = 0;
                string depName = cbDepartments.Text;
                try { 
                 amount = Convert.ToInt32(tbAmount.Text);
                 price = Convert.ToDouble(tbPrice.Text);
                }
                catch (FormatException formatException)
                {
                    throw new FormatException("Could not convert numbers!");
                }

                if (amountIsValid(amount) && priceIsValid(price))
                {
                    Stock stock = new Stock(name, amount, price, true, departmentContext.GetIdByName(depName));
                    this.stockContext.Insert(stock);
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
            this.Close();
        }
    }
}
