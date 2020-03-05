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
            //GC.SuppressFinalize(this);//Updated
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

        public void DeleteUsersWithEmail(string email)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Users WHERE Email = @email";
                command.AddParameter("email", email);
                command.ExecuteNonQuery();
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
        public User UpdateUserInfo()
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"UPDATE users SET FullName = @fullName, Email = @email, PhoneNumber = @phoneNumber, Password = @password, Role = @role WHERE ID = @ID";
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
                        user.Role = (string)reader["Role"];
                        user.HourlyRate = (float)reader["HourlyRate"];
                        user.PhoneNumber = (string)reader["PhoneNumber"];
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
