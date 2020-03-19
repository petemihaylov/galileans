using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Data
{
    class AvailabilityContext: DbContext
    {
        public override void Insert(object obj)
        {
            Models.Availability availability = (Models.Availability)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO availability (EmployeeID, Date, Available) VALUES( @employeeID, @date, @available)";

                    command.AddParameter("employeeID", availability.EmployeeID);
                    command.AddParameter("date", availability.Date);
                    command.AddParameter("available", availability.Available);
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
                    command.CommandText = @"DELETE FROM Availability WHERE EmployeeID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Availability[] GetAllAvailabilitiesByID(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Availability where EmployeeID = @id ORDER BY Date ASC";
                    command.AddParameter("id", id);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Availability> availabilities = new List<Availability>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Availability availability = new Availability();
                            availability.EmployeeID = (int)reader["EmployeeID"];
                            availability.Date = (DateTime)reader["Date"];
                            availability.Available = (bool)reader["Available"];
                            availabilities.Add(availability);
                        }

                        return availabilities.ToArray();
                    }
                }
            }
        }
    }
}
