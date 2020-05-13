using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class UserDepartment
    {
        public User User {get; set;}
        public Department Department { get; set; }
    }
}
