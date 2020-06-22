using System;
using System.Collections.Generic;
using System.Linq;
using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;

namespace EmployeesManagementSystem.Data
{
    public class UserDepartmentContext : DbContext
    {
        public override bool Insert(object obj)
        {
            UserDepartment userDepartment = (UserDepartment)obj;

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO UserDepartment (DepartmentID, UserID)" +
                    " VALUES(@departmentID, @userID)";

                    command.AddParameter("departmentID", userDepartment.Department.ID);
                    command.AddParameter("userID", userDepartment.User.ID);
                    return command.ExecuteNonQuery() > 0 ? true : false;

                }
            }
        }
        public UserDepartment[] GetAll()
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText =
                         @" SELECT * FROM UserDepartment as ud
                            LEFT JOIN User as u
                            ON ud.UserID = u.ID

                            LEFT JOIN Department as d
                            ON ud.DepartmentID = d.ID";

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<UserDepartment> userDepartments = new List<UserDepartment>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            UserDepartment ud = new UserDepartment();
                            MapObject(ud, reader);
                            userDepartments.Add(ud);
                        }
                        return userDepartments.ToArray();
                    }
                }
            }
        }
        public Department GetDepartmentByUser(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement it will be slow to many left joins
                    command.CommandText =
                         @" SELECT *
                            FROM UserDepartment as ud
                            LEFT JOIN Department as d
                            ON ud.DepartmentID = d.ID
                            WHERE ud.UserID = @userId;";
                    command.AddParameter("userId", id);


                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Department department = new Department();
                            department.ID = (int)reader["DepartmentID"];
                            department.Name = (string)reader["Name"];

                            return department;
                        }
                    }
                }
            }
            return null;
        }

        public User GetUserByDepartment(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement it will be slow to many left joins
                    command.CommandText =
                         @" SELECT *
                            FROM UserDepartment as ud
                            LEFT JOIN User as u
                            ON ud.UserID = u.ID
                            WHERE ud.DepartmentID = @Id;";
                    command.AddParameter("Id", id);


                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // User
                            User user = new User();

                            user.ID = (int)reader["UserID"];
                            user.FullName = (string)reader["FullName"];
                            user.Email = (string)reader["Email"];
                            user.PhoneNumber = (string)reader["PhoneNumber"];
                            user.Wage = (double)reader["Wage"];
                            user.Password = (string)reader["Password"];
                            Enum.TryParse((string)reader["Role"], out Role role);
                            user.Role = role;

                            return user;
                        }
                    }
                }
            }
            return null;
        }

        public override bool DeleteById(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM UserDepartment WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public bool DeleteByUser(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM UserDepartment WHERE UserID = @ID";
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
                    command.CommandText = @"DELETE FROM UserDepartment WHERE DepartmentID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public bool UpdateInfo(int userID, int departmentID)
        {

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE UserDepartment SET DepartmentID = @departmentID WHERE UserID = @userID";
                    command.AddParameter("userID", userID);
                    command.AddParameter("departmentID", departmentID);

                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        private UserDepartment MapObject(UserDepartment userDepartment, MySqlDataReader reader)
        {
            // User
            User user = userDepartment.User;

            user.ID = (int)reader["UserID"];
            user.FullName = (string)reader["FullName"];
            user.Email = (string)reader["Email"];
            user.PhoneNumber = (string)reader["PhoneNumber"];
            user.Wage = (double)reader["Wage"];
            user.Password = (string)reader["Password"];

            Enum.TryParse((string)reader["Role"], out Role role);
            user.Role = role;


            //Department 
            Department department = userDepartment.Department;

            department.ID = (int)reader["ID"];
            department.Name = (string)reader["Name"];

            return userDepartment;

        }
    }
}
