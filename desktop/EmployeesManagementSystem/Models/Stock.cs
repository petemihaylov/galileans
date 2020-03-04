using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Stock
    {
        public string name { get; private set; }
        public int amount { get; private set; }
        public double price { get; private set; }

        public Stock(string name, int amount, double price)
        {
            this.name = name;
            this.amount = amount;
            this.price = price;
        }

        public bool SellStock(int amount)
        {
            if (this.amount < amount)
            {
                return false;
            }
            this.amount = this.amount - amount;
            return true;
        }
    }
}
