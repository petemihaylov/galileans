using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User() { }
        public User(string firstName, string lastName, string email, string password, string role)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Role = role;
            this.Password = password;
        }
    }
}
