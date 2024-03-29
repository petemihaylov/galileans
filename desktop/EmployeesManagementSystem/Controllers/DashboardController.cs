﻿using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EmployeesManagementSystem.Controllers
{
    public class DashboardController
    {
        private UserContext userContext = new UserContext();
        private UserDepartmentContext userDepartmentContext = new UserDepartmentContext();

        public User[] GetUsers()
        {
            return this.userContext.GetAllUsers();
        }
        public DataTable GetUsersTable()
        {
            return this.userContext.GetUsersTable();
        }
        public User[] GetFilteredUsers(DataView dv)
        {
            return userContext.GetAllFilteredUsers(dv.ToTable());
        }

        // Removes all the whitespaces from a given string
        public string RemoveWhiteSpaces(string text)
        {
            return Regex.Replace(text, @"\s+|\t|\n|\r", String.Empty);
        }
        public void ShowDataGridInfo(DataGridView dataGridView, User[] users)
        {
            dataGridView.Rows.Clear();

            foreach (User user in users)
            {
                var arr = user.GetInfo();
                var d = userDepartmentContext.GetDepartmentByUser(user.ID);

                if (d != null)
                    arr[arr.Length - 1] = d.Name;

                dataGridView.Rows.Add(arr);
            }
        }
    }
}
