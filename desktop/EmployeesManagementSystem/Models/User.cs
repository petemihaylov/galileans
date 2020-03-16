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
        private Data.DepartmentContext departmentContext = new Data.DepartmentContext();
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string Password { get; set; }
        public string Role { get; set; }
        public float HourlyRate { get; set; }
        public int Department { get; set; }


        public User() { }
        public User(string fullName, string email, string phoneNumber, string password, string role, float hourlyRate, int department)
        {
            this.FullName = fullName;
            this.Email = email;
            this.Role = role;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            this.HourlyRate = hourlyRate;
            this.Department = department;
        }


        public string[] GetInfo()
        {
            string[] s = {this.ID.ToString(), this.FullName, this.Email, this.Role, departmentContext.GetNameById(this.Department)};
            return s;
        }
    }
}
