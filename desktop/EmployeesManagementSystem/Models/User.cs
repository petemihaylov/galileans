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
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User() { }
        public User(string fullName, string email, string password, string role)
        {
            this.FullName = fullName;
            this.Email = email;
            this.Role = role;
            this.Password = password;
        }
    }
}
