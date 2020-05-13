using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Data.Tests
{
    [TestClass()]
    public class UserContextTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            // Arrange
            UserContext userContext = new UserContext();
            User user = new User(0, "Test", "test@gmail.com", "+31 635 928 796", "password", Role.Employee, 12.50);

            // Act
            bool result = userContext.Insert(user);
            
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DeleteByIdTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void DeleteUserByEmailTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void UpdateUserInfoTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void UpdatePasswordTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void GetUsersTableTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void GetAllFilteredUsersTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void GetUserByIDTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void GetUserByFullNameTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void GetUserByEmailTest()
        {
            Assert.IsTrue(false);
        }
    }
}