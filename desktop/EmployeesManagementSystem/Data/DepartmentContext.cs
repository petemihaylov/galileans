using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EmployeesManagementSystem.Models;
using System.Data;

namespace EmployeesManagementSystem.Data
{
    public class DepartmentContext : DbContext
    {
        public override bool Insert(object obj)
        {
            Department department = (Department)obj;

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Department (ID, Name) VALUES(@id, @name)";

                    command.AddParameter("id", department.ID);
                    command.AddParameter("name", department.Name);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public override bool DeleteById(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Department WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }

        public DataTable GetDepartmentTable()
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // select statement
                    command.CommandText = @"SELECT * FROM Department";

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

        public Department[] GetAllFilteredDepartments(DataTable table)
        {
            List<Department> departments= new List<Department>();

            foreach (DataRow row in table.Rows)
            {
                Department department = new Department();
                department.ID = (int) row["ID"];
                department.Name = (string) row["Name"];
                    
                departments.Add(department);
            }

            return departments.ToArray();
        }

        public Department[] GetAllDepartments()
        {
            using (var con = new MySqlConnection(ConnectionString))
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
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Department WHERE Name = @name";
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
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Department WHERE ID = @id";
                    command.AddParameter("id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var department = new Department();
                             MapObject(department, reader);
                            return department;
                        }
                        return null;
                    }
                }
            }
        }
        public bool UpdateDepartmentInfo(Department dep)
        {

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE Department SET Name = @name WHERE ID = @ID";
                    command.AddParameter("ID", dep.ID);
                    // Executing it 
                    command.Parameters.AddWithValue("name", dep.Name);

                    return command.ExecuteNonQuery() > 0 ? true : false;
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
