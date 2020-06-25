using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models.Tests
{
    [TestClass()]
    public class StockTests 
    { 
        #region Initialize some test data
        private string name;
        private int amount;
        private double price;
        public StockTests()
        {
            this.name = "test";
            this.price = 10;
            this.amount = 2;
        }
        #endregion

        [TestMethod()]
        public void StockTest()
        {
            Department d = new Department("test");
            Stock stock = new Stock(this.name, this.amount, this.price, false, d);

            Assert.AreEqual(this.name, stock.Name);
            Assert.AreEqual(this.amount, stock.Amount);
            Assert.AreEqual(this.price, stock.Price);
            Assert.AreEqual(false, stock.Availability);
            Assert.AreEqual(d, stock.Department);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]

        public void StockTest1()
        {
            Department d = new Department("test");
            Stock stock = new Stock(this.name, this.amount, -20, false, d);
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            Department d = new Department("test");
            Stock stock = new Stock(this.name, this.amount, this.price, false, d);
            string[] s = { stock.ID.ToString(), stock.Name, stock.Price.ToString(), stock.Amount.ToString(), Convert.ToString(stock.Availability) };
            CollectionAssert.AreEqual(s, stock.GetInfo());
        }

        [TestMethod()]
        public void SellStockTest()
        {
            Department d = new Department("test");
            Stock stock = new Stock(this.name, this.amount, this.price, false, d);

            stock.SellStock(3);
        }
    }
}