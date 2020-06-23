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
    public class UserTests
    {
        #region Initialize some test data
        private string fullname;
        private int id;
        private string email;
        private string phone;
        private string password;
        private double wage;
        public UserTests()
        {
            this.fullname = "test";
            this.email = "test@mail.com";
            this.password = "fontys123.";
            this.wage = 0;
            this.id = -2;
        }
        #endregion

        [TestMethod()]
        public void NewUserTest()
        {
            User user = new User(this.id, this.fullname, this.email, this.phone, this.password, Role.Employee, this.wage);

            // Assert
            Assert.AreEqual(this.id, user.ID);
            Assert.AreEqual(this.fullname, user.FullName);
            Assert.AreEqual(this.email, user.Email);
            Assert.AreEqual(this.phone, user.PhoneNumber);
            Assert.AreEqual(Role.Employee, user.Role);
            Assert.AreEqual(this.wage, user.Wage);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void UserTest1()
        {
            User user = new User(this.id,"", this.email, this.phone, this.password, Role.Employee, this.wage);
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            User user = new User(this.id, this.fullname, this.email, this.phone, this.password, Role.Employee, this.wage);
            string[] s = { this.id.ToString(), this.fullname, this.email, Role.Employee.ToString(), "" };
            CollectionAssert.AreEqual(s, user.GetInfo());
        }
    }
}