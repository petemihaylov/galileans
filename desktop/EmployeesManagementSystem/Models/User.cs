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
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public float HourlyRate { get; set; }
        public User() { }
        public User(string fullName, string email, int phoneNumber, string password, string role, float hourlyRate)
        {
            this.FullName = fullName;
            this.Email = email;
            this.Role = role;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            this.HourlyRate = hourlyRate;
        }

        public string[] GetInfo()
        {
            string[] s = { Convert.ToString(this.ID), this.FullName, this.Email, this.Role};
            return s;
        }
    }
}
