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
    public class CancellationTests
    {
        #region Initialize some test data
        private string subject;
        private int id;
        private string message;
        private DateTime date;
        public CancellationTests()
        {
            this.subject = "test";
            this.message = "testetstetetetstette";
            this.id = -2;
            this.date = DateTime.Now.AddDays(2);

        }
        #endregion
        [TestMethod()]
        public void CancellationTest()
        {
            User user = new User(-2, "test", "test@mail.com", "0123456789", "fontys123.", Role.Employee, 20);
            Cancellation c = new Cancellation(this.id, this.date, this.subject, this.message, user, CState.Approved);
            Assert.AreEqual(this.id, c.ID);
            Assert.AreEqual(this.date, c.Date);
            Assert.AreEqual(this.subject, c.Subject);
            Assert.AreEqual(this.message, c.Message);
            Assert.AreEqual(user, c.Employee);
            Assert.AreEqual(CState.Approved, c.State);
        }

        [TestMethod()]
        public void CancellationTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            User user = new User(-2, "test", "test@mail.com", "0123456789", "fontys123.", Role.Employee, 20);
            Cancellation c = new Cancellation(this.id, this.date, this.subject, this.message, user, CState.Approved);
            string[] s = { this.id.ToString(), this.date.ToString(), "Name", this.subject, this.message, CState.Approved.ToString(), "Delete" };

            CollectionAssert.AreEqual(s,c.GetInfo());

        }
    }
}