using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class UserDepartment
    {
        private User user = new User();
        private Department department = new Department();
        public User User { get { return this.user; } set { this.user = value; } }
        public Department Department { get { return this.department; } set { this.department = value; } }
    }
}
