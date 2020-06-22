using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models.Concellation
{
    interface ICancellation
    {
        int ID { get; set; }
        DateTime Date { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
        User Employee { get; set; }
    }
}
