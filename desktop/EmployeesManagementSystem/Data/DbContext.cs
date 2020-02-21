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
    class DataClass
    {
        private MySqlConnection connection;

        public DataClass()
        {
            // change the connection string in the App.config file

            var connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            this.connection = new MySqlConnection(connectionString);
            this.connection.Open();

            // Seeder or to create tables if they not exist
        }
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
                        user.FirstName = (string)reader["FirstName"];
                        user.LastName = (string)reader["LastName"];
                        user.Email = (string)reader["Email"];
                        user.Password = (string)reader["Password"];
                        user.Role = (string)reader["Role"];
                    }

                    // getting the actual user
                    return user;
                }

            }
        }
        public void InsertUser(User user)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Users (FirstName, LastName, Email, Role, Password) VALUES(@firstName, @lastName, @email, @role, @password)";

                command.AddParameter("firstName", user.FirstName);
                command.AddParameter("lastName", user.LastName);
                command.AddParameter("email", user.Email);
                command.AddParameter("role", user.Role);
                command.AddParameter("password", user.Password);
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
