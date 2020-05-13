using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;

namespace EmployeesManagementSystem.Data
{
    class UserDepartmentsContext: DbContext
    {
        public override void Insert(object obj)
        {
            UserDepartments deps = (UserDepartments)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO UserDepartments (DepartmentName, DepartmentID, UserID)" +
                    " VALUES(@depName, @depId, @userId)";

                    command.AddParameter("depName", deps.DepartmentName);
                    command.AddParameter("depId", deps.DepartmentID);
                    command.AddParameter("userId", deps.UserID);
                    command.ExecuteNonQuery();

                }
            }
        }
        public UserDepartments[] GetAllDepartmentsByUser(int ID)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM UserDepartments WHERE ID = @userId";
                    command.AddParameter("userId", ID);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<UserDepartments> depByUser = new List<UserDepartments>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            UserDepartments dep = new UserDepartments();

                            dep.ID = (int)reader["ID"];
                            dep.DepartmentID = (int)reader["DepartmentID"];
                            dep.DepartmentName = (string)reader["DepartmentName"];
                            dep.UserID = (int)reader["UserID"];

                            depByUser.Add(dep);
                        }

                        return depByUser.ToArray();
                    }
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
                    command.CommandText = @"DELETE FROM UserDepartments WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
