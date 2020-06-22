using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    interface IStock
    {
        int ID { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        int Amount { get; set; }
        bool Availability { get; set; }
        Department Department { get; set; }
    }
}
