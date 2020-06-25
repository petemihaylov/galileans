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
    public class NotificationTests
    {
        [TestMethod()]
        public void NotificationTest()
        {
            User user = new User(-2, "test", "test@mail.com", "0123456789", "fontys123.", Role.Employee, 20);

            Notification n = new Notification("test test test test", user);

            Assert.AreEqual("test test test test", n.Message);
            Assert.AreEqual(user, n.User);
        }
    }
}