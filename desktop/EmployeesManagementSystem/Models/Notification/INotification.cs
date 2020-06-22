using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    interface INotification
    {
        int ID { get; set; }
        string Message { get; set; }
        User User { get; set; }
    }
}
