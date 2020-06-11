using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem
{
    /*
     * Possible options: When we start the program the manager will 
     * check all the available shifts and will set the automatic ones.
     * 
     * It can get the current date and it can set all the shift for only two week ahead. 
     * It would be great if there is a property, which we can change.
     */
    public class ShiftAutomationManager
    {
        private static List<Shift> shifts = new ShiftContext().GetAllShifts();

        public static List<DateTime> Run(int repetitions, string dayOfWeek)
        {
            DateTime currentTime = DateTime.Now;
            int year = currentTime.Year;

            List<DateTime> finalresult = new List<DateTime>();

            var list = new List<DateTime>();
            for (; list.Count < repetitions; currentTime = currentTime.AddMonths(1))
            {
                list.AddRange(GetDatesInMonth(dayOfWeek, currentTime.Month, year));
            }


            return list;
            
        }

        public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }

        private static List<DateTime> GetDatesInMonth(string dayOfWeek, int month, int year)
        {
            try { 
                 Enum.TryParse(dayOfWeek, out DayOfWeek d);
                DateTime dateTime = DateTime.Now;
                 return AllDatesInMonth(year, month).Where(i => i.DayOfWeek == d && i >= dateTime).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
