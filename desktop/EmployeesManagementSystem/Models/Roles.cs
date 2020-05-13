using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Roles
    {
        public int ID { get; set; }
        public string Role { get; set; }
        public int UserID { get; set; }

        public Roles() { }

        public Roles(string role, int userId)
        {
            this.Role = role;
            this.UserID = userId;
        }

    }
}
