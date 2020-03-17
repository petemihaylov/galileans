using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Data
{
    public class DepartmentContext : DbContext
    {
        // Should be implemented
        public override void Insert(object obj)
        {
            Models.Department department = (Models.Department)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Departments (ID, Name) VALUES(@id, @name)";

                    command.AddParameter("ID", department.ID);
                    command.AddParameter("name", department.Name);
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
                    command.CommandText = @"DELETE FROM Departments WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Department[] GetAllDepartments()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();


                using (var command = new MySqlCommand("SELECT * FROM Departments", con))
                {
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Models.Department> departments = new List<Models.Department>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Models.Department department = new Models.Department();

                            department.ID = (int)reader["ID"];
                            department.Name = (string)reader["Name"];
                            departments.Add(department);
                        }
                        return departments.ToArray();
                    }
                }
            }
        }

        public int GetIdByName(string name)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT ID FROM Departments WHERE Name = @name";
                    command.AddParameter("name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        int id = -1;
                        while (reader.Read())
                        {
                            id = (int)reader["ID"];
                        }
                        return id;
                    }
                }
            }
        }

        public string GetNameById(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT Name FROM Departments WHERE ID = @id";
                    command.AddParameter("id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        string name = "";
                        while (reader.Read())
                        {
                            name = (string)reader["Name"];
                        }
                        return name;
                    }
                }
            }
        }

        public Department GetDepartmentById(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT Name FROM Departments WHERE ID = @id";
                    command.AddParameter("id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        Department dep = new Department();
                        while (reader.Read())
                        {
                            dep.Name = (string)reader["Name"];
                        }
                        return dep;
                    }
                }
            }
        }
    }
}
