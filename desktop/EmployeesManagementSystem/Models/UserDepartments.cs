using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class UserDepartments
    {

        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentID { get; set; }
        public int UserID { get; set; }

        public UserDepartments() { }

        public UserDepartments(string depName, int depId, int userId)
        {
            this.DepartmentName = depName;
            this.DepartmentID = depId;
            this.UserID = userId;
        }
    }
}
