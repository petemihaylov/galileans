using EmployeesManagementSystem.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace EmployeesManagementSystem.Data
{
    class UserContext : DbContext
    {
        public override void Insert(object obj)
        {
            User user = (User)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Users (FullName, Email, PhoneNumber, Password, Role, HourlyRate, DepartmentID) VALUES(@fullName, @email, @phoneNumber, @password, @role, @hourlyRate, @department)";

                    command.AddParameter("fullName", user.FullName);
                    command.AddParameter("email", user.Email);
                    command.AddParameter("phoneNumber", user.PhoneNumber);
                    command.AddParameter("role", user.Role);
                    command.AddParameter("password", user.Password);
                    command.AddParameter("hourlyRate", user.HourlyRate);
                    command.AddParameter("department", user.Department);
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
                    command.CommandText = @"DELETE FROM Users WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUserInfo(User user)
        {

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE Users SET FullName = @fullname, Email = @email, PhoneNumber = @phonenumber, Role = @role, DepartmentID = @department WHERE ID = @ID";
                    command.AddParameter("ID", user.ID);
                    // Executing it 
                    command.Parameters.AddWithValue("@fullname", user.FullName);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@phonenumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("@role", user.Role);
                    command.Parameters.AddWithValue("@department", user.Department);


                    command.ExecuteNonQuery();
                }
            }
        }

        public User[] GetAllUsers()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Users";

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<User> users = new List<User>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            User user = new User();
                            user.ID = (int)reader["ID"];
                            user.FullName = (string)reader["FullName"];
                            user.Email = (string)reader["Email"];
                            user.Password = (string)reader["Password"];
                            user.Role = (string)reader["Role"];
                            user.Department = (int)reader["DepartmentID"];
                            users.Add(user);
                        }

                        return users.ToArray();
                    }
                }
            }
        }
        public DataTable GetUsersTable()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // select statement
                    command.CommandText = @"select * from Users";

                    // executing it 
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
        }
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
                user.Department = (int)row["DepartmentID"];
                users.Add(user);
            }

            return users.ToArray();
        }
        public User GetUserByID(int ID)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
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
                            user.Department = (int)reader["DepartmentID"];

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
        public User GetUserByName(string name)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Users WHERE FullName = @name";
                    command.AddParameter("name", name);

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
                            user.Department = (int)reader["DepartmentID"];

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
        public User GetUserByEmail(string email)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
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
                            user.Department = (int)reader["DepartmentID"];
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
        public void DeleteUsersWithEmail(string email)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Users WHERE Email = @email";
                    command.AddParameter("email", email);
                    command.ExecuteNonQuery(); // check if you have deleted the shifts of this user!
                }
            }
        }    
        public void ResetPassword(int userId, string password)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE Users SET Password = @password WHERE ID = @ID";
                    command.AddParameter("ID", userId);
                    // Executing it 
                    command.Parameters.AddWithValue("@password", Hashing.HashPassword(password));
                    command.ExecuteNonQuery();
                }
            }
        }
        public int GetDepIDByUserId(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT DepartmentID FROM Users WHERE ID = @id";
                    command.AddParameter("id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        int depID = 0;
                        while (reader.Read())
                        {
                            depID = (int)reader["DepartmentID"];
                        }
                        return depID;
                    }
                }
            }
        }

    }
}
