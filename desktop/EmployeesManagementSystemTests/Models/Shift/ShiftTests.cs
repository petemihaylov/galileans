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
    public class ShiftTests
    {
        #region Initialize some test data
        private string name;
        private DateTime shiftDateTest;
        private string startTimeTest;
        private string endTimeTest;
        public ShiftTests()
        {
            this.name = "test";
            this.shiftDateTest = DateTime.Now.AddDays(2);
            this.startTimeTest = "16:00";
            this.endTimeTest = "17:00";

        }
        #endregion
        [TestMethod()]
        public void ShiftTest()
        {
            Department d = new Department("testDep");
            User assignedUser = new User(-2, "test", "test@mail.com", "0123456789", "fontys123.", Role.Employee, 20);
            Shift s = new Shift(assignedUser, true, d, shiftDateTest, startTimeTest, endTimeTest, ShiftType.Evening);

            Assert.AreEqual(assignedUser, s.AssignedUser);
            Assert.AreEqual(true, s.Availability);
            Assert.AreEqual(d, s.Department);
            Assert.AreEqual(endTimeTest, s.EndTime);
            Assert.AreEqual(shiftDateTest, s.ShiftDate);
            Assert.AreEqual(startTimeTest, s.StartTime);
            Assert.AreEqual(ShiftType.Evening, s.Type);
        }

        [TestMethod()]
        public void ShiftTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CompareToTest()
        {
            throw new NotImplementedException();
        }
    }
}