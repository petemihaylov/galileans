using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManagementSystem.Controllers
{
    public class ShiftController
    {
        public ShiftContext shiftContext = new ShiftContext();
        private UserContext userContext = new UserContext();
        private DepartmentContext departmentContext = new DepartmentContext();
        private List<Shift> shifts;

        public ShiftController()
        {
            this.shifts = GetShifts();
    }


    public List<Department> GetDepartments()
        {
            return new List<Department>(departmentContext.GetAllDepartments());
        }

        public List<Shift> GetShifts()
        {
            return shiftContext.GetAllShifts();
        }

        public User GetUser(int id)
        {
            return userContext.GetUserByID(id);
        }


        public List<Shift> getMorningShiftsForDate(DateTime dateTime)
        {
            List<Shift> list = new List<Shift>();
            foreach (var item in shifts)
            {
                if (item.Type == ShiftType.Morning && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public List<Shift> getAfternoonShiftsForDate(DateTime dateTime)
        {
            List<Shift> list = new List<Shift>();
            foreach (var item in shifts)
            {
                if (item.Type == ShiftType.Afternoon && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public List<Shift> getEveningShiftsForDate(DateTime dateTime)
        {
            List<Shift> list = new List<Shift>();
            foreach (var item in shifts)
            {
                if (item.Type == ShiftType.Evening && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
                {
                    list.Add(item);
                }
            }
            return list;
        }

    }
}
