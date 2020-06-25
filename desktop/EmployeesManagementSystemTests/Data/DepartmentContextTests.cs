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

        [TestMethod()]
        public void DeleteByIdTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetDepartmentTableTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllFilteredDepartmentsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllDepartmentsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetDepartmentByNameTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetDepartmentByIdTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateDepartmentInfoTest()
        {
            throw new NotImplementedException();
        }
    }
}