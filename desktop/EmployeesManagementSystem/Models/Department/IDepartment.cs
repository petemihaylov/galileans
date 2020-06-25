using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    interface IDepartment
    {
        int ID { get; set; }
        string Name { get; set; }
    }
}
