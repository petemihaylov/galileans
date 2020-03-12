using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Stock
    {
        public int  ID { get; set; }
        public string Name { get; set; }
        public int Amount { get;  set; }
        public double Price { get; set; }
        public bool Availability { get; set; }

        public Stock(string name, int amount, double price, bool availability)
        {
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.Availability = availability;

        }
        public Stock() { }

        public string[] GetInfo()
        {
            string[] s = { Convert.ToString(this.ID), this.Name, Convert.ToString(this.Price), Convert.ToString(this.Amount), Convert.ToString(Availability), "Reload"};
            return s;
        }
        public bool SellStock(int amount)
        {
            if (this.Amount < amount)
            {
                return false;
            }
            this.Amount = this.Amount - amount;
            return true;
        }
    }
}
