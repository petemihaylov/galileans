using System;
using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace EmployeesManagementSystem.Data
{
    class ShiftContext : DbContext
    {
        public List<Shift> GetAllShifts()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = new MySqlCommand("SELECT * FROM Shifts", con))
                {

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object

                            Shift shift = new Shift();
                            shift.ID = (int)reader["ID"];
                            shift.ShiftDate = (DateTime)reader["ShiftDate"];
                            shift.AssignedEmployeeID = (int)reader["AssignedEmployeeID"];
                            shift.DepartmentID = (int)reader["DepartmentID"];
                            shift.Availability = (bool)reader["Availability"];
                            shift.StartTime = Convert.ToDateTime(((TimeSpan)reader["StartTime"]).ToString());
                            shift.EndTime = Convert.ToDateTime(((TimeSpan)reader["EndTime"]).ToString());
                            shift.Attended = (bool)reader["Attended"];
                            shift.Type = getShiftTypeByString((string)reader["ShiftType"]);

                            shifts.Add(shift);
                        }
                        return shifts;
                    }
                }
            }

        }
        public List<Shift> GetShiftsByUserId(int userId)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shifts WHERE AssignedEmployeeID = @ID";
                    command.AddParameter("ID", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object

                            Shift shift = new Shift();
                            shift.ID = (int)reader["ID"];
                            shift.ShiftDate = (DateTime)reader["ShiftDate"];
                            shift.AssignedEmployeeID = (int)reader["AssignedEmployeeID"];
                            shift.DepartmentID = (int)reader["DepartmentID"];
                            shift.Availability = (bool)reader["Availability"];
                            shift.StartTime = Convert.ToDateTime(((TimeSpan)reader["StartTime"]).ToString());
                            shift.EndTime = Convert.ToDateTime(((TimeSpan)reader["EndTime"]).ToString());
                            shift.Type = getShiftTypeByString((string)reader["ShiftType"]);
                            shift.Attended = (bool)reader["Attended"];

                            shifts.Add(shift);
                        }

                        return shifts;
                    }
                }

            }
        }


        public List<Shift> GetShiftsByDepId(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shifts WHERE DepartmentID = @ID";
                    command.AddParameter("ID", id);

                    using (var reader = command.ExecuteReader())
                    {
                        List<Shift> shifts = new List<Shift>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object

                            Shift shift = new Shift();
                            shift.ID = (int)reader["ID"];
                            shift.ShiftDate = (DateTime)reader["ShiftDate"];


                            shift.AssignedEmployeeID = (int)reader["AssignedEmployeeID"];
                            shift.Availability = (bool)reader["Availability"];
                            shift.DepartmentID = (int)reader["DepartmentID"];
                            shift.StartTime = Convert.ToDateTime(((TimeSpan)reader["StartTime"]).ToString());
                            shift.EndTime = Convert.ToDateTime(((TimeSpan)reader["EndTime"]).ToString());
                            shift.Type = getShiftTypeByString((string)reader["ShiftType"]);
                            shift.Attended = (bool)reader["Attended"];

                            shifts.Add(shift);
                        }

                        return shifts;
                    }
                }

            }
        }
        public Shift GetShiftByDate(DateTime date, DateTime startTime)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Shifts WHERE  ShiftDate = @shiftDate and StartTime = @startTime";
                    command.AddParameter("shiftDate", date);
                    command.AddParameter("startTime", startTime);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        Shift shift = new Shift();
                        if (reader.Read())
                        {
                            // Mapping the return data to the object
                            shift.ID = (int)reader["ID"];
                            shift.AssignedEmployeeID = (int)reader["AssignedEmployeeID"];
                            shift.DepartmentID = (int)reader["DepartmentID"];
                            shift.Availability = (bool)reader["Availability"];
                            shift.ShiftDate = (DateTime)reader["ShiftDate"];
                            shift.StartTime = Convert.ToDateTime(((TimeSpan)reader["StartTime"]).ToString());
                            shift.EndTime = Convert.ToDateTime(((TimeSpan)reader["EndTime"]).ToString());
                            shift.Attended = (bool)reader["Attended"];
                            shift.Type = getShiftTypeByString((string)reader["ShiftType"]);

                        }
                        else
                        {
                            return null;
                        }

                        return shift;
                    }
                }

            }
        }
        public void DeleteShiftByUserId(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {

                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Shifts WHERE AssignedEmployeeID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }


        private ShiftType getShiftTypeByString(string type)
        {
            switch (type.ToUpper())
            {
                case "MORNING": return ShiftType.MORNING;
                case "AFTERNOON": return ShiftType.AFTERNOON;
                case "EVENING": return ShiftType.EVENING;
                default: break;
            }
            return ShiftType.OTHER;
        }


    
        public override void Insert(object obj)
        {
            Shift shift = (Shift)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Shifts (AssignedEmployeeID, DepartmentID, Availability, ShiftDate, StartTime, EndTime, Attended, ShiftType)" +
                    " VALUES(@userId, @departmentId, @availability, @date, @startTime, @endTime, @attended, @shiftType)";


                    command.AddParameter("userId", shift.AssignedEmployeeID);
                    command.AddParameter("departmentId", shift.DepartmentID);
                    command.AddParameter("availability", shift.Availability);
                    command.AddParameter("date", shift.ShiftDate);
                    command.AddParameter("startTime", shift.StartTime);
                    command.AddParameter("endTime", shift.EndTime);
                    command.AddParameter("attended", shift.Attended);
                    command.AddParameter("shiftType", shift.Type.ToString());
                    string st = command.ToString();

                    con.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
        public override void DeleteById(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Shifts WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
