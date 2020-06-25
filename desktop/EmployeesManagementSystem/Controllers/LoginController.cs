using System;
using System.Net.Mail;
using EmployeesManagementSystem.Data;
using System.Text.RegularExpressions;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Controllers
{
    public class LoginController
    {
        private UserContext userContext = new UserContext();
        private ShiftContext shiftContext = new ShiftContext();
        private ImageContext imageContext = new ImageContext();
        private CancellationContext cancellationContext = new CancellationContext();
        private UserDepartmentContext userDepartmentContext = new UserDepartmentContext();


        // Inserts data so you can actually login
        public void PrepareData()
        {
            var user = userContext.GetUserByEmail("admin@mail.com");
            if (user != null)
            {
                int adminID = user.ID;
                shiftContext.DeleteShiftsByUser(adminID);
                imageContext.DeleteImgByUserId(adminID);
                userDepartmentContext.DeleteByUser(adminID);
                
                userContext.DeleteUserByEmail("admin@mail.com");

            }
            userContext.Insert(new Administrator(-1, "admin", "admin@mail.com", "+31 6430 2303", Hashing.HashPassword("admin"), 0));


        }

        // Returns false if input is not valid
        public bool InputValidation(string email, string password)
        {
            return !(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password));
        }

        // Checks if user exists
        public User FindUser(string email)
        {
            User user = userContext.GetUserByEmail(email);
            if (isEmailValid(email) && user != null)
            {
                return user;
            }

            return null;
        }

        // Checks password 
        public bool isPasswordValid(string password, User user)
        {
            return Hashing.ValidatePassword(password, user.Password);
        }

        // Checks user role
        public bool isRoleValid(User user)
        {
            return (user.Role == Role.Administrator || user.Role == Role.Manager);
        }
        // Validates the emails
        private bool isEmailValid(string email)
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format?redirectedfrom=MSDN
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // Validates the password
        private bool isPasswordValid(string password)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.web.security.validatepasswordeventargs?view=netframework-4.8
            Regex rx = new Regex(@"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})");
            return rx.IsMatch(password);
        }

    }
}
