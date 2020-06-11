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


        public static List<Shift> Run(int repetitions, string dayOfWeek, User user)
        {
            DateTime currentTime = DateTime.Now;
            int year = currentTime.Year;

            List<Shift> finalresult = new List<Shift>();

            // Gets all the days for specific dayOfWeek 
            var list = new List<DateTime>();
            for (; list.Count < repetitions; currentTime = currentTime.AddMonths(1))
            {
                list.AddRange(GetDatesInMonth(dayOfWeek, currentTime.Month, year));
            }

            shifts.Sort();

            Department d = new UserDepartmentContext().GetDepartmentByUser(user.ID);
            // Checks if there is assigned shift
            for (int i = 0; i < list.Count && i < repetitions && d != null; i++)
            {
                if (ShiftExists(list[i], out ShiftType shiftType) == false)
                {
                    // Default Morning 
                    string startTime = StartTime.morning[0];
                    string endTime = EndTime.morning[0];

                    if (shiftType == ShiftType.Afternoon)
                    {
                        startTime = StartTime.afternoon[0];
                        endTime = EndTime.afternoon[0];
                    }else if( shiftType == ShiftType.Evening)
                    {
                        startTime = StartTime.evening[0];
                        endTime = EndTime.evening[0];
                    }

                    Shift createdNewShift = new Shift(user, false, d, list[i], startTime, endTime, shiftType);
                    // Adding to the list of new shifts
                    finalresult.Add(createdNewShift);
                }
            }


            return finalresult;

        }

        public static void DeleteShiftFromCurrentDate(User user)
        {
            new ShiftContext().DeleteShiftsFromDate(DateTime.Now, user.ID);
        }
        private static bool ShiftExists(DateTime date, out ShiftType shiftType)
        {
            shiftType = ShiftType.Morning; // Default value
            for (int i = 0; i < shifts.Count; i++)
            {
                if (shifts[i].ShiftDate > date) { return false; }

                if (shifts[i].ShiftDate == date)
                {

                    ShiftType type = shifts[i].Type;
                    if (type != ShiftType.Morning) { shiftType = ShiftType.Morning; return false; }
                    if (type != ShiftType.Afternoon) { shiftType = ShiftType.Afternoon; return false; }
                    if (type != ShiftType.Evening) { shiftType = ShiftType.Evening; return false; }

                    return true;
                }
            }
            return false;
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
            try
            {
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
