using System;
using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace EmployeesManagementSystem
{
    class DbContext
    {
        private MySqlConnection connection;

        public DbContext()
        {
            // change the connection string in the App.config file
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            this.connection = new MySqlConnection(connectionString);
            this.connection.Open();
        }

        // Closing the existing DB connections
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    MySqlConnection.ClearPool(connection);
                    this.connection.Close();
                    this.connection.Dispose();
                }
            }
        }

        //Get all cancellation announcements
        public Cancellations[] GetAnnouncements()
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM shiftcancellation";

                // Executing it 
                using (var reader = command.ExecuteReader())
                {
                    List<Cancellations> cancels = new List<Cancellations>();
                    while (reader.Read())
                    {
                        // Mapping the return data to the object
                        Cancellations cancel = new Cancellations();
                        cancel.ID = (int)reader["ID"];
                        cancel.Date = (string)reader["Date"];
                        cancel.Employee = (string)reader["Employee"];
                        cancel.Subject = (string)reader["Subject"];
                        cancel.Description = (string)reader["Description"];
                        cancels.Add(cancel);    
                    }
                    return cancels.ToArray();
                }
            }
        }

        public List<Shift> GetAllShifts()
        {

                var command = new MySqlCommand("SELECT * FROM shifts", connection);
               
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


                        shift.AssingedEmployeeID = (int)reader["AssingedEmployeeID"];
                        shift.Availability = (bool)reader["Availability"];
                        shift.StartTime= Convert.ToDateTime (((TimeSpan)reader["StartTime"]).ToString());
                        shift.EndTime = Convert.ToDateTime(((TimeSpan)reader["EndTime"]).ToString());
                        shift.Type = getShiftTypeByString((string)reader["ShiftType"]);

                        shifts.Add(shift);
                    }
                    return shifts;
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

        //get all users
        public User[] GetAllUsers()
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM users";

                // Executing it 
                using (var reader = command.ExecuteReader())
                {
                    List<User> users = new List<User>();
                    while(reader.Read())
                    {
                        // Mapping the return data to the object
                        User user = new User();
                        user.ID = (int)reader["ID"];
                        user.FullName = (string)reader["FullName"];
                        user.Email = (string)reader["Email"];
                        user.Password = (string)reader["Password"];
                        user.Role = (string)reader["Role"];
                        users.Add(user);
                    }

                    return users.ToArray();
                }
            }
        }

        // Create new user
        // User
        public User GetUserByID(int ID)
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM Users WHERE ID = @userId";
                command.AddParameter("userId", ID);

                // Ececuting it 
                using (var reader = command.ExecuteReader())
                {
                    User user = new User();
                    if (reader.Read())
                    {
                        // Mapping the return data to the object
                        user.ID = (int)reader["ID"];
                        user.FullName = (string)reader["FullName"];
                        user.Email = (string)reader["Email"];
                        user.PhoneNumber = (string)reader["PhoneNumber"];
                        user.HourlyRate = (float)reader["HourlyRate"];
                        user.Password = (string)reader["Password"];
                        user.Role = (string)reader["Role"];
                    }else
                    {
                        return null;
                    }

                    // getting the actual user
                    return user;
                }
            }
        }

        // Create new user
        public void InsertUser(User user)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Users (FullName, Email, PhoneNumber, Password, Role, HourlyRate) VALUES(@fullName, @email, @phoneNumber, @password, @role, @hourlyRate)";

                command.AddParameter("fullName", user.FullName);
                command.AddParameter("email", user.Email);
                command.AddParameter("phoneNumber", user.PhoneNumber);
                command.AddParameter("role", user.Role);
                command.AddParameter("password", user.Password);
                command.AddParameter("hourlyRate", user.HourlyRate);
                command.ExecuteNonQuery();
            }
        }

        // Delete user by id
        public void DeleteUser(int id)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Users WHERE ID = @ID";             
                command.AddParameter("ID", id);
                command.ExecuteNonQuery();
            }
        }

        // Delete shift by user id
        public void DeleteShiftOfUser(int id)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Shifts WHERE AssingedEmployeeID = @ID";
                command.AddParameter("ID", id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUsersWithEmail(string email)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Users WHERE Email = @email";
                command.AddParameter("email", email);
                command.ExecuteNonQuery(); // check if you have deleted the shifts of this user!
            }
        }

        //Delete announcements by email
        public void DeleteAnnouncement(int id)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"DELETE FROM shiftcancellation WHERE ID = @ID";
                command.AddParameter("ID", id);
                command.ExecuteNonQuery();
            }
        }

        // Get user by email
        public User GetUserByEmail(string email)
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM Users WHERE Email = @email";
                command.AddParameter("email", email);

                // Executing it 
                using (var reader = command.ExecuteReader())
                {
                    User user = new User();
                    if (reader.Read())
                    {
                        // Mapping the return data to the object
                        user.ID = (int)reader["ID"];
                        user.FullName = (string)reader["FullName"];
                        user.Email = (string)reader["Email"];
                        user.Password = (string)reader["Password"];
                        user.HourlyRate = (float)reader["HourlyRate"];
                        user.PhoneNumber = (string)reader["PhoneNumber"];
                        user.Role = (string)reader["Role"];
                    }
                    else
                    {
                        return null;
                    }

                    // getting the actual user
                    return user;
                }
            }
        }
        //Update the user details.
        public void UpdateUserInfo(int id, string fullName, string email, string password, string phoneNumber, string role)
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"UPDATE users SET FullName = @fullname, Email = @email, PhoneNumber = @phonenumber, Password = @password, Role = @role WHERE ID = @ID";
                command.AddParameter("ID", id);
                // Executing it 
                command.Parameters.AddWithValue("@fullname", fullName);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phonenumber", phoneNumber);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);
                command.ExecuteNonQuery();
            }
        }
    }

    public static class CommandExtensions
    {
        /// <summary>
        ///     This method is not part of a IDbCommand interface.  
        /// </summary>
        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");

            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value ?? DBNull.Value;
            command.Parameters.Add(p);
        }
    }
}
