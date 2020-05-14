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
            userContext.DeleteUserByEmail("test@test.com");
            User user = new User(0, "TestFullName", "test@test.com", "+31 635 928 796", "password", Role.Employee, 12);

            // Act
            bool result = userContext.Insert(user);
            
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DeleteByIdTest()
        {
            // Arrange
            UserContext userContext = new UserContext();
            userContext.DeleteUserByEmail("test5@test.com");
            User user1 = new User(0, "TestFullName", "test5@test.com", "+31 635 928 796", "password", Role.Employee, 32);

            // Act
            userContext.Insert(user1);
            User userRes = userContext.GetUserByEmail("test5@test.com");

            bool result = userContext.DeleteById(userRes.ID);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DeleteUserByEmailTest()
        {
            // Arrange
            UserContext userContext = new UserContext();
            userContext.DeleteUserByEmail("test6@test.com");
            User user = new User(0, "TestFullName", "test6@test.com", "+31 635 928 796", "password", Role.Employee, 32);

            // Act
            userContext.Insert(user);
            bool result = userContext.DeleteUserByEmail("test6@test.com");

            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod()]
        public void UpdateUserInfoTest()
        {
            // Arrange
            UserContext userContext = new UserContext();
            userContext.DeleteUserByEmail("test8@test.com");
            User user = new User(0, "TestFullName", "test8@test.com", "+31 635 928 796", "password", Role.Employee, 32);


            // Act
            userContext.Insert(user);

            User userUpdate = userContext.GetUserByEmail("test8@test.com");

            userUpdate.FullName += "UpdateName";
            userUpdate.PhoneNumber = "+31 635 928 000";
            bool result = userContext.UpdateUserInfo(userUpdate);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void UpdatePasswordTest()
        {
            // Arrange
            UserContext userContext = new UserContext();
            userContext.DeleteUserByEmail("test1@test.com");
            User user = new User(0, "TestFullName", "test1@test.com", "+31 635 928 796", "password", Role.Employee, 32);


            // Act
            userContext.Insert(user);

            User userUpdatePassword = userContext.GetUserByEmail("test1@test.com");

            bool result = userContext.UpdatePassword(userUpdatePassword.ID, "newpassword");

            // Assert
            Assert.IsTrue(result);
        }

    }
}