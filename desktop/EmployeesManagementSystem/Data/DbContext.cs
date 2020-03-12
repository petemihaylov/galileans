﻿using System;
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


/// 
/// Announcements
/// 


        // Get all cancellation announcements
        public Models.Cancellations[] GetAnnouncements()
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM shiftcancellation";

                // Executing it 
                using (var reader = command.ExecuteReader())
                {
                    List<Models.Cancellations> cancels = new List<Models.Cancellations>();
                    while (reader.Read())
                    {
                        // Mapping the return data to the object
                        Models.Cancellations cancel = new Models.Cancellations();
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


/// 
/// SHIFTS
/// 


        // Create new Shift
        public void InsertShift(Shift shift)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Shifts (AssignedEmployeeID, Availability, ShiftDate, StartTime, EndTime, Attended, ShiftType)" +
                " VALUES(@userId, @availability, @date, @startTime, @endTime, @attended, @shiftType)";


                command.AddParameter("userId", shift.AssignedEmployeeID);
                command.AddParameter("availability", shift.Availability);
                command.AddParameter("date", shift.ShiftDate);
                command.AddParameter("startTime", shift.StartTime);
                command.AddParameter("endTime", shift.EndTime);
                command.AddParameter("attended", shift.Attended);
                command.AddParameter("shiftType", shift.Type.ToString());
                string st = command.ToString();
                command.ExecuteNonQuery();
            }
        }

        // Get all shifts
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
                        shift.AssignedEmployeeID = (int)reader["AssignedEmployeeID"];
                        shift.Availability = (bool)reader["Availability"];
                        shift.StartTime= Convert.ToDateTime (((TimeSpan)reader["StartTime"]).ToString());
                        shift.EndTime = Convert.ToDateTime(((TimeSpan)reader["EndTime"]).ToString());
                        shift.Attended = (bool)reader["Attended"];
                        shift.Type = getShiftTypeByString((string)reader["ShiftType"]);

                        shifts.Add(shift);
                    }
                    return shifts;
                }
    
        }

        // Delete shift by user id
        public void DeleteShiftOfUser(int id)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Shifts WHERE AssignedEmployeeID = @ID";
                command.AddParameter("ID", id);
                command.ExecuteNonQuery();
            }
        }

        // Get shift type by string
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

        public void DeleteShiftByID(int id)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Shifts WHERE ID = @ID";
                command.AddParameter("ID", id);
                command.ExecuteNonQuery();
            }
        }
        public Shift GetShiftByDate(DateTime date, DateTime startTime)
        {
            using (var command = connection.CreateCommand())
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
        public List<Shift> GetShiftsByID(int ID)
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM Shifts WHERE AssignedEmployeeID = @ID";
                command.AddParameter("ID", ID);

                // Ececuting it 
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
                        shift.StartTime = Convert.ToDateTime(((TimeSpan)reader["StartTime"]).ToString());
                        shift.EndTime = Convert.ToDateTime(((TimeSpan)reader["EndTime"]).ToString());
                        shift.Type = getShiftTypeByString((string)reader["ShiftType"]);
                        shift.Attended = (bool)reader["Attended"];

                        shifts.Add(shift);
                    }

                    // getting the actual user
                    return shifts;
                }
            }
        }



        /// 
        /// USERS
        /// 


        // Get all users
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

        // Get user table
        public DataTable GetUsers()
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM users";

                // Executing it 
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();

                    if (reader.Read())
                    {
                        table.Load(reader);
                    }

                    return table;
                }
            }
        }

        // Get filtered Users
        public User[] GetAllFilteredUsers(DataTable table)
        {
            List<User> users = new List<User>();
            foreach (DataRow row in table.Rows)
            {
                User user = new User();
                user.ID = (int)row["ID"];
                user.FullName = (string)row["FullName"];
                user.Email = (string)row["Email"];
                user.Password = (string)row["Password"];
                user.Role = (string)row["Role"];
                users.Add(user);
            }

            return users.ToArray();
        }

        // Get a User by id
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

        // Update the user details.
        public void UpdateUserInfo(int id, string fullName, string email, string phoneNumber, string role)
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"UPDATE users SET FullName = @fullname, Email = @email, PhoneNumber = @phonenumber, Role = @role WHERE ID = @ID";
                command.AddParameter("ID", id);
                // Executing it 
                command.Parameters.AddWithValue("@fullname", fullName);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phonenumber", phoneNumber);
                command.Parameters.AddWithValue("@role", role);
                command.ExecuteNonQuery();
            }
        }


        // Reset the user's password
        public void ResetPassword(int id)
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"UPDATE users SET Password = @password WHERE ID = @ID";
                command.AddParameter("ID", id);
                // Executing it 
                command.Parameters.AddWithValue("@password", Hashing.HashPassword("WelcomeToMediaBazaar"));
                command.ExecuteNonQuery();
            }
        }

        // Stocks

        public Stock[] GetAllStocks()
        {
            var command = new MySqlCommand("SELECT * FROM stocks", connection);
            // Executing it 
            using (var reader = command.ExecuteReader())
            {
                List<Stock> stocks = new List<Stock>();
                while (reader.Read())
                {
                    // Mapping the return data to the object
                    Stock stock = new Stock();

                    stock.ID = (int)reader["ID"];
                    stock.Name = (string)reader["Name"];
                    stock.Price = (double)reader["Price"];
                    stock.Amount = (int)reader["Amount"];
                    stock.Availability = (bool)reader["Availability"];
                    stocks.Add(stock);
                }
                return stocks.ToArray();
            }
        }

        // create stock
        public void InsertStock(Stock stock)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO stocks (Name, Amount, Price, Availability)" +
                " VALUES(@name, @price, @amount, @availability)";

                command.AddParameter("name", stock.Name);
                command.AddParameter("price", stock.Price);
                command.AddParameter("amount", stock.Amount);
                command.AddParameter("availability", stock.Availability);
                command.ExecuteNonQuery();
            }
        }
        public void UpdateStockByID(int ID, string name, double price, int amount, bool availability)
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"UPDATE stocks SET Name = @name, Price = @price, Amount = @amount, Availability = @availability WHERE ID = @ID";
                command.AddParameter("ID", ID);
                // Executing it 
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@availability", availability);
                command.ExecuteNonQuery();
            }
        }
        public Stock GetStockByID(int ID)
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM Stocks WHERE ID = @stockId";
                command.AddParameter("stockId", ID);

                // Ececuting it 
                using (var reader = command.ExecuteReader())
                {
                    Stock stock = new Stock();
                    if (reader.Read())
                    {
                        // Mapping the return data to the object
                        stock.ID = (int)reader["ID"];
                        stock.Name = (string)reader["Name"];
                        stock.Amount = (int)reader["Amount"];
                        stock.Price = (double)reader["Price"];
                        stock.Availability = (bool)reader["Availability"];
                    }
                    else
                    {
                        return null;
                    }

                    return stock;
                }
            }
            
        }
        
    }

    // Helper Class / Method
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
