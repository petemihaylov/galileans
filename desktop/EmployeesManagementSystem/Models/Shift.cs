using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Shift
    {
        protected List<User> assignedEmployees;
        protected bool availability;
        protected DateTime date;
        
        public Shift()
        {
            this.availability = true;
            this.assignedEmployees = new List<User>();
        }

    }
}
