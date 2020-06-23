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

    public class AvailabilityTests
    {
        #region Initialize some test data
        
        public AvailabilityTests()
        {
        }
        #endregion

        [TestMethod()]
        public void AvailabilityTest()
        {
            List<DayType> days = new List<DayType>();
            days.Add(DayType.Fri);
            User user = new User(-2, "test", "test@mail.com", "0123456789", "fontys123.", Role.Employee, 20);
            Availability a = new Availability(user, AvailabilityType.Approved, days, false, true);

            Assert.AreEqual(AvailabilityType.Approved, a.State);
            Assert.AreEqual(days,a.Days);
            Assert.AreEqual(false, a.IsWeekly);
            Assert.AreEqual(true, a.IsMonthly);
            Assert.AreEqual(user, a.User);
        }

        [TestMethod()]
        public void AvailabilityTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetDaysTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetFormatedDaysTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            List<DayType> days = new List<DayType>();
            days.Add(DayType.Fri);
            User user = new User(-2, "test", "test@mail.com", "0123456789", "fontys123.", Role.Employee, 20);
            Availability a = new Availability(user, AvailabilityType.Approved, days, false, true);

            Assert.AreEqual(AvailabilityType.Approved, a.State);
            Assert.AreEqual(days, a.Days);
            Assert.AreEqual(false, a.IsWeekly);
            Assert.AreEqual(true, a.IsMonthly);
            Assert.AreEqual(user, a.User);
            string s;
            if (a.IsWeekly)
                s = a.GetDays() + "  -  Weekly";
            else if (a.IsMonthly)
                s = a.GetDays() + "  -  Monthly";
            else s = a.GetDays() + ", once";

            Assert.AreEqual(s, a.GetInfo());
        }
    }
}