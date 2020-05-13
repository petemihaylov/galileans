using EmployeesManagementSystem.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace EmployeesManagementSystem.Data
{
    class UserContext : DbContext
    {
        public override bool Insert(object obj)
        {
            User user = (User)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO User (FullName, Email, Password, PhoneNumber, Role, Wage)
                                                      VALUES (@fullName, @email, @password , @phoneNumber, @role, @wage)";

                    command.AddParameter("fullName", user.FullName);
                    command.AddParameter("email", user.Email);
                    command.AddParameter("password", user.Password);
                    command.AddParameter("phoneNumber", user.PhoneNumber);
                    command.AddParameter("role", user.Role);
                    command.AddParameter("wage", user.Wage);
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
                    command.CommandText = @"DELETE FROM User WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public bool DeleteUserByEmail(string email)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM User WHERE Email = @email";
                    command.AddParameter("email", email);

                    // Check if you have deleted the shifts of this user!
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }

        public bool UpdateUserInfo(User user)
        {

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE User SET FullName = @fullname, Email = @email, Password = @password, PhoneNumber = @phonenumber, Role = @role, Wage = @wage WHERE ID = @ID";
                    command.AddParameter("ID", user.ID);
                    // Executing it 
                    command.Parameters.AddWithValue("fullname", user.FullName);
                    command.Parameters.AddWithValue("email", user.Email);
                    command.Parameters.AddWithValue("password", user.Password);
                    command.Parameters.AddWithValue("phonenumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("role", user.Role);
                    command.Parameters.AddWithValue("wage", user.Wage);


                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public bool UpdatePassword(int userId, string password)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE User SET Password = @password WHERE ID = @ID";
                    command.AddParameter("ID", userId);
                    // Executing it 
                    command.Parameters.AddWithValue("@password", Hashing.HashPassword(password));
                    return command.ExecuteNonQuery() > 0 ? true : false;
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
                    command.CommandText = @"SELECT * FROM User";

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<User> users = new List<User>();
                        while (reader.Read())
                        {
                            User user = new User();
                            MapObject(user, reader);

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
                    command.CommandText = @"SELECT * FROM User";

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
                user.Role = (Role)row["Role"];
                user.Wage = (decimal)row["Wage"];

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
                    command.CommandText = @"SELECT * FROM User WHERE ID = @ID";
                    command.AddParameter("ID", ID);

                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        User user = new User();

                        if (reader.Read())
                        {
                            MapObject(user, reader);
                        }
                        else { return null; }

                        // getting the actual user
                        return user;
                    }
                }
            }
        }
        public User GetUserByFullName(string fullname)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Users WHERE FullName = @fullname";
                    command.AddParameter("fullname", fullname);


                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        User user = new User();

                        if (reader.Read())
                        {
                            MapObject(user, reader);
                        }
                        else { return null; }

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
                    command.CommandText = @"SELECT * FROM User WHERE Email = @email";
                    command.AddParameter("email", email);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        User user = new User();
                        if (reader.Read())
                        {
                            MapObject(user, reader);
                        }
                        else { return null; }

                        // getting the actual user
                        return user;
                    }
                }


            }
        }
        private User MapObject(User user, MySqlDataReader reader)
        {
            user.ID = (int)reader["ID"];
            user.FullName = (string)reader["FullName"];
            user.Email = (string)reader["Email"];
            user.PhoneNumber = (string)reader["PhoneNumber"];
            user.Wage = (decimal)reader["Wage"];
            user.Password = (string)reader["Password"];
            user.Role = (Role)reader["Role"];

            return user;

        }

    }
}
