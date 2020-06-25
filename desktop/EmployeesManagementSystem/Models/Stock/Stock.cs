using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class Stock : IStock
    {
        public int ID { get; set; }
        public string Name { get; set; }
        private double price;
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    Console.WriteLine(ErrorMessage.NegativePrice());
                }
            }
        }
        private int amount;
        public int Amount { get { return this.amount; } set { this.amount = value; } }
        public bool Availability { get; set; } = false;
        private Department department = new Department();
        public Department Department { get { return this.department; } set { this.department = value; } }

        public Stock(string name, int amount, double price, bool availability, Department department)
        {
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.Availability = availability;
            this.Department = department;

        }
        public Stock() { }
        public string[] GetInfo()
        {
            string[] s = { this.ID.ToString(), this.Name, this.Price.ToString(), this.Amount.ToString(), Convert.ToString(Availability)};
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
