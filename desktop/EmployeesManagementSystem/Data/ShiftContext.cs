using System;
using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace EmployeesManagementSystem.Data
{
    class ShiftContext : DbContext
    {

        public override bool Insert(object obj)
        {
            Shift shift = (Shift)obj;

            using (var con = new MySqlConnection(connectionString))
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
            using (var con = new MySqlConnection(connectionString))
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
        public bool DeleteShiftsByUser(int id)
        {
            using (var con = new MySqlConnection(connectionString))
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

        public bool UpdateShift(Shift shift)
        {
            using (var con = new MySqlConnection(connectionString))
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

            shift.StartTime = Convert.ToDateTime(((TimeSpan)reader["StartTime"]).ToString());
            shift.EndTime = Convert.ToDateTime(((TimeSpan)reader["EndTime"]).ToString());

            shift.Type = (ShiftType)reader["ShiftType"];
            shift.Attended = (bool)reader["Attended"];
            shift.Cancelled = (bool)reader["Cancelled"];

            return shift;
        }


        public List<Shift> GetAllShifts()
        {
            using (var con = new MySqlConnection(connectionString))
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
            using (var con = new MySqlConnection(connectionString))
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
            using (var con = new MySqlConnection(connectionString))
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
        public Shift GetShiftByDate(DateTime date, DateTime startTime)
        {
            using (var con = new MySqlConnection(connectionString))
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
            using (var con = new MySqlConnection(connectionString))
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
            using (var con = new MySqlConnection(connectionString))
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
      
    }
}
