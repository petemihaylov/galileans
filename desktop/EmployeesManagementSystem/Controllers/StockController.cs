using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeesManagementSystem.Controllers
{
    public class StockController
    {
        private StockContext stockContext = new StockContext();
        public Stock[] GetStocks()
        {
            return this.stockContext.GetAllStocks();
        }
        public DataTable GetStockTable()
        {
            return this.stockContext.GetStockTable();
        }
        public Stock[] GetFilteredStocks(DataView dv)
        {
            return stockContext.GetAllFilteredStocks(dv.ToTable());
        }

        // Removes all the whitespaces from a given string
        public string RemoveWhiteSpaces(string text)
        {
            return Regex.Replace(text, @"\s+|\t|\n|\r", String.Empty);
        }
        /*
        public void ShowDataGridInfo(DataGridView dataGridView, User[] users)
        {
            dataGridView.Rows.Clear();

            foreach (User user in users)
            {
                var arr = user.GetInfo();
                var d = stockContext.GetDepartmentByUser(user.ID);

                if (d != null)
                    arr[arr.Length - 1] = d.Name;

                dataGridView.Rows.Add(arr);
            }
        }*/
    }
}
