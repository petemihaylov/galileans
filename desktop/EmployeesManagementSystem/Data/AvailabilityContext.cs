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
        public override bool Insert(object obj)
        {
            Availability availability = (Availability)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Availability (UserID, Date, Available) VALUES( @userID, @date, @available)";

                    command.AddParameter("userID", availability.User.ID);
                    command.AddParameter("date", availability.Date);
                    command.AddParameter("available", availability.Available);
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
                    command.CommandText = @"DELETE FROM Availability WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true: false;
                }
            }
        }
        public bool DeleteByUser(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Availability WHERE UserID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
       
        public Availability[] GetAllAvailabilitiesByID(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Availability where UserID = @id ORDER BY Date ASC";
                    command.AddParameter("id", id);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Availability> availabilities = new List<Availability>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Availability availability = new Availability();
                            availability.User.ID = (int)reader["UserID"];
                            availability.Date = (DateTime)reader["Date"];
                            availability.Available = (bool)reader["Available"];
                            availabilities.Add(availability);
                        }

                        return availabilities.ToArray();
                    }
                }
            }
        }

        private Availability MapObject(Availability availability, MySqlDataReader reader)
        {
            
            return availability;
        }

    }
}
