﻿using System;
using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace EmployeesManagementSystem.Data
{
    public class ShiftContext : DbContext
    {

        public override bool Insert(object obj)
        {
            Shift shift = (Shift)obj;

            using (var con = new MySqlConnection(ConnectionString))
            {
                using (var command = con.CreateCommand())
                {

                    con.Open();

                    command.CommandText = @"INSERT INTO Shift (AssignedUserID, DepartmentID, Availability, ShiftDate, StartTime, EndTime, ShiftType , Attended, Cancelled)" +
                    " VALUES(@userId, @departmentId, @availability, @shiftDate, @startTime, @endTime,  @shiftType, @attended, @cancelled)";


                    command.AddParameter("userId", shift.AssignedUser.ID);
                    command.AddParameter("departmentId", shift.Department.ID);
                    command.AddParameter("availability", shift.Availability);
                    command.AddParameter("shiftDate", shift.ShiftDate);
                    command.AddParameter("startTime", shift.StartTime);
                    command.AddParameter("endTime", shift.EndTime);
                    command.AddParameter("shiftType", shift.Type.ToString());
                    command.AddParameter("attended", shift.Attended);
                    command.AddParameter("cancelled", shift.Cancelled);

                    return command.ExecuteNonQuery() > 0 ? true : false;

                }
            }
        }

        public override bool DeleteById(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Shift WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public bool DeleteByDepartment(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Shift WHERE DepartmentID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public bool DeleteShiftsByUser(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {

                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Shift WHERE AssignedUserID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public  bool DeleteShiftsFromDate(DateTime dateTime, int userID)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Shift WHERE AssignedUserID = @userID and ShiftDate >= @shiftDate";
                    command.AddParameter("userID", userID);
                    command.AddParameter("shiftDate", dateTime);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public bool UpdateShift(Shift shift)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"UPDATE Shift SET AssignedUserID = @userId, DepartmentID = @departmentId, Availability =  @availability,
                    ShiftDate =  @date, StartTime =  @startTime, EndTime = @endTime, ShiftType =  @shiftType, Attended = @attended, Cancelled = @cancelled
                      WHERE ID = @shiftId;";

                    command.AddParameter("shiftId", shift.ID);
                    command.AddParameter("userId", shift.AssignedUser.ID);
                    command.AddParameter("departmentId", shift.Department.ID);
                    command.AddParameter("availability", shift.Availability);
                    command.AddParameter("date", shift.ShiftDate);
                    command.AddParameter("startTime", shift.StartTime);
                    command.AddParameter("endTime", shift.EndTime);
                    command.AddParameter("shiftType", shift.Type.ToString());
                    command.AddParameter("attended", shift.Attended);
                    command.AddParameter("cancelled", shift.Cancelled);

                    return command.ExecuteNonQuery() > 0 ? true : false;

                }
            }


        }
        private Shift MapObject(Shift shift, MySqlDataReader reader)
        {
            shift.ID = (int)reader["ID"];
            shift.ShiftDate = (DateTime)reader["ShiftDate"];

            shift.AssignedUser.ID = (int)reader["AssignedUserID"];
            shift.Department.ID = (int)reader["DepartmentID"];

            shift.Availability = (bool)reader["Availability"];

            shift.StartTime = (string)reader["StartTime"];
            shift.EndTime = (string)reader["EndTime"];

            Enum.TryParse((string)reader["ShiftType"], out ShiftType shiftType);
            shift.Type = shiftType;
            shift.Attended = (bool)reader["Attended"];
            shift.Cancelled = (bool)reader["Cancelled"];

            return shift;
        }


        public List<Shift> GetAllShifts()
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = new MySqlCommand("SELECT * FROM Shift", con))
                {

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Shift shift = new Shift();
                            MapObject(shift, reader);
                            shifts.Add(shift);
                        }
                        return shifts;
                    }
                }
            }

        }
       
        public List<Shift> GetShiftsByUserId(int userId)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE AssignedUserID = @ID";
                    command.AddParameter("ID", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object

                            Shift shift = new Shift();
                            MapObject(shift, reader);
                            shifts.Add(shift);
                        }

                        return shifts;
                    }
                }

            }
        }
        public List<Shift> GetShiftsByDepartment(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE DepartmentID = @ID";
                    command.AddParameter("ID", id);

                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Shift shift = new Shift();
                            MapObject(shift, reader);
                            shifts.Add(shift);
                        }

                        return shifts;
                    }
                }

            }
        }

        public List<Shift> GetShiftsByDateAndDepartment(DateTime date, int id)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE  (ShiftDate >= @monthStart and ShiftDate <= @monthEnd) AND DepartmentID = @ID";
                    command.AddParameter("monthStart", firstDayOfMonth);
                    command.AddParameter("monthEnd", lastDayOfMonth);
                    command.AddParameter("ID", id);


                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Shift shift = new Shift();
                            MapObject(shift, reader);
                            shifts.Add(shift);
                        }
                        return shifts;
                    }
                }

            }
        }
        public List<Shift> GetShiftsByDateAndUser(DateTime date, int id)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE  (ShiftDate >= @monthStart and ShiftDate <= @monthEnd) AND  AssignedUserID = @ID";
                    command.AddParameter("monthStart", firstDayOfMonth);
                    command.AddParameter("monthEnd", lastDayOfMonth);
                    command.AddParameter("ID", id);


                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Shift shift = new Shift();
                            MapObject(shift, reader);
                            shifts.Add(shift);
                        }
                        return shifts;
                    }
                }

            }
        }

        public List<Shift> GetCancelledShiftsByDateAndUser(DateTime date, int id)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE  (ShiftDate >= @monthStart and ShiftDate <= @monthEnd) AND  AssignedUserID = @ID AND Cancelled = TRUE";
                    command.AddParameter("monthStart", firstDayOfMonth);
                    command.AddParameter("monthEnd", lastDayOfMonth);
                    command.AddParameter("ID", id);


                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Shift shift = new Shift();
                            MapObject(shift, reader);
                            shifts.Add(shift);
                        }
                        return shifts;
                    }
                }

            }
        }

        public Shift GetShiftByDate(DateTime date, User user)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE  ShiftDate = @shiftDate and AssignedUserID = @userID and Attended = false";
                    command.AddParameter("shiftDate", date.ToString("yyyy-MM-dd"));
                    command.AddParameter("userID", user.ID);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        Shift shift = new Shift();
                        if (reader.Read())
                        {
                            MapObject(shift, reader);
                        }
                        else { return null; }

                        return shift;
                    }
                }

            }
        }
        public Shift GetShiftByDate(DateTime date, string startTime)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE  ShiftDate = @shiftDate and StartTime = @startTime";
                    command.AddParameter("shiftDate", date);
                    command.AddParameter("startTime", startTime);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        Shift shift = new Shift();
                        if (reader.Read())
                        {
                            MapObject(shift, reader);
                        }
                        else { return null; }

                        return shift;
                    }
                }

            }
        }
        public Shift GetShiftByUser(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE AssignedUserID = @ID";
                    command.AddParameter("ID", id);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        Shift shift = new Shift();
                        if (reader.Read())
                        {
                            MapObject(shift, reader);

                        }
                        else { return null; }

                        return shift;
                    }
                }

            }
        }
        public Shift GetShiftByID(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shift WHERE ID = @id";
                    command.AddParameter("id", id);
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        Shift shift = new Shift();
                        if (reader.Read())
                        {
                            MapObject(shift, reader);
                        }
                        else { return null; }

                        return shift;
                    }
                }

            }
        }
        public Shift[] GetShifts()
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = new MySqlCommand("SELECT * FROM Shift", con))
                {

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Shift shift = new Shift();
                            MapObject(shift, reader);
                            shifts.Add(shift);
                        }
                        return shifts.ToArray();
                    }
                }
            }

        }

    }
}
