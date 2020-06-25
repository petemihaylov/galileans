using System;

namespace EmployeesManagementSystem.Models
{
    interface IShift
    {
        int ID { get; set; }
        bool Availability { get; set; }
        DateTime ShiftDate { get; set; }
        string StartTime { get; set; }
        string EndTime { get; set; }
        ShiftType Type { get; set; }
        bool Attended { get; set; }
        bool Cancelled { get; set; }


        User AssignedUser { get; set; }
        Department Department { get; set; }
    }
}
