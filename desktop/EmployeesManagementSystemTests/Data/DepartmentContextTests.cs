using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeesManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Data.Tests
{
    [TestClass()]
    public class DepartmentContextTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            DepartmentContext departmentContext = new DepartmentContext();
            Department department = new Department("NewDepartment");

            Assert.IsTrue(departmentContext.Insert(department));
        }

    }
}