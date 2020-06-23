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
    public class DepartmentTests
    {
        #region Initialize some test data
        private string name;
        public DepartmentTests()
        {
            this.name = "test";
        }
        #endregion
        [TestMethod()]
        public void DepartmentTest()
        {
            Department d = new Department(this.name);
            Assert.AreEqual(this.name, d.Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DepartmentTest1()
        {
            Department dep = new Department("");
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            Department d = new Department(this.name);
            string[] output = { d.ID.ToString(), this.name };
            CollectionAssert.AreEqual(output, d.GetInfo());

        }
    }
}