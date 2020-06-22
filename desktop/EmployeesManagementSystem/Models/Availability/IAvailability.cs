using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    interface IAvailability
    {
        int ID { get; set; }
        User User { get; set; }
        AvailabilityType State { get; set; }
        List<DayType> Days { get; set; }
        bool IsWeekly { get; set; }
        bool IsMonthly { get; set; }
    }
}
