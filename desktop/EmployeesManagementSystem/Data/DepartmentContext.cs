using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Data
{
    public class DepartmentContext : DbContext
    {
        public override bool Insert(object obj)
        {
            Models.Department department = (Models.Department)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Department (ID, Name) VALUES(@id, @name)";

                    command.AddParameter("ID", department.ID);
                    command.AddParameter("name", department.Name);
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
                    command.CommandText = @"DELETE FROM Departments WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public Department[] GetAllDepartments()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = new MySqlCommand("SELECT * FROM Department", con))
                {
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Department> departments = new List<Department>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Department department = new Department();
                            MapObject(department, reader);
                            departments.Add(department);
                        }
                        return departments.ToArray();
                    }
                }
            }
        }
        public Department GetDepartmentByName(string name)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT ID FROM Department WHERE Name = @name";
                    command.AddParameter("name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return MapObject(new Department(), reader);
                        }
                        return null;
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
                    command.CommandText = @"SELECT Name FROM Department WHERE ID = @id";
                    command.AddParameter("id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return MapObject(new Department(), reader);
                        }
                        return null;
                    }
                }
            }
        }


        private Department MapObject(Department department, MySqlDataReader reader)
        {
            department.ID = (int)reader["ID"];
            department.Name = (string)reader["Name"];
            return department;

        }
    }
}
