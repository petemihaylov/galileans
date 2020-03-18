using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Availability
    {
        private Data.DepartmentContext departmentContext = new Data.DepartmentContext();
        private Data.UserContext userContext = new Data.UserContext();

        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public bool Available{ get; set; }
        public Availability(){}

        public Availability(int employeeID, DateTime date, bool available)
        {
            EmployeeID = employeeID;
            Date = date;
            Available = available;
        }

    }
}
