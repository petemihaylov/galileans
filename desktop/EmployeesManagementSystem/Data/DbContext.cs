using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Cancellations GetAnnouncements()
        {
            using (var command = connection.CreateCommand())
            {
                // Select statement
                command.CommandText = @"SELECT * FROM shiftcancellation";

                // Executing it 
                using (var reader = command.ExecuteReader())
                {
                    Cancellations cancel = new Cancellations();
                    if (reader.Read())
                    {
                        // Mapping the return data to the object
                        cancel.ID = (int)reader["UserID"];
                        cancel.Date = (string)reader["Date"];
                        cancel.Subject = (string)reader["Subject"];
                        cancel.Description = (string)reader["Description"];
                    }
                    else
                    {
                        return null;
                    }
                    return cancel;
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

        // Delete user by email
        public void DeleteUser(User user)
        {
            using (var command = connection.CreateCommand())
            {
                
                command.CommandText = @"DELETE FROM Users WHERE email = @email";        
                
                command.AddParameter("email", user.Email);
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
                        user.Password = (string)reader["Password"];
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
