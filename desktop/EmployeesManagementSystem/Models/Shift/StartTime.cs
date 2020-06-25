using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public static class StartTime
    {
        public static List<string> morning = new List<string>()
        {
            "09:00",
            "10:00",
            "11:00"
        };

        public static List<string> afternoon = new List<string>()
        {
            "14:00",
            "15:00",
            "16:00"
        };
        
        public static List<string> evening = new List<string>()
        {
            "20:00",
            "21:00",
            "22:00"
        };
    }
    public static class EndTime
    {
        public static List<string> morning = new List<string>()
        {
            "10:00",
            "11:00",
            "12:00"
        };

        public static List<string> afternoon = new List<string>()
        {
            "15:00",
            "16:00",
            "17:00"
        };

        public static List<string> evening = new List<string>()
        {
            "21:00",
            "22:00",
            "23:00"
        };
    }
}
