using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;

namespace EmployeesManagementSystem.Data
{
    class RolesContext: DbContext
    {
        public Roles GetRoleByUser(int userId)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Roles WHERE UserID = @userId";
                    command.AddParameter("userId", userId);

                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        Roles role= new Roles();
                        if (reader.Read())
                        {
                            // Mapping the return data to the object
                            role.ID = (int)reader["ID"];
                            role.Role = (string)reader["Role"];
                            role.UserID = (int)reader["UserID"];
                        }
                        else
                        {
                            return null;
                        }

                        return role;
                    }
                }
            }
        }

        public Roles[] GetAllRoles()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Roles";

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Roles> roles = new List<Roles>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Roles role = new Roles();
                            role.ID = (int)reader["ID"];
                            role.Role = (string)reader["Role"];
                            role.UserID = (int)reader["UserID"];
                        }

                        return roles.ToArray();
                    }
                }
            }
        }
        public void DeleteRoleByUserId(int userId)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Roles WHERE UserID = @userID";
                    command.AddParameter("userID", userId);
                    command.ExecuteNonQuery();
                }

            }
        }




        public override void Insert(object obj)
        {
            Roles role = (Roles)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Roles (Role, UserID)" +
                    " VALUES(@role, @userId)";

                    command.AddParameter("role", role.Role);
                    command.AddParameter("userId", role.UserID);
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
                    command.CommandText = @"DELETE FROM Roles WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
