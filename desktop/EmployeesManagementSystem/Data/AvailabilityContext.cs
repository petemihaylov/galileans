using System.Collections.Generic;
using MySql.Data.MySqlClient;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Data
{
    public class AvailabilityContext: DbContext
    {
        public override bool Insert(object obj)
        {
            Availability availability = (Availability)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Availability (UserID, State, Days, IsWeekly, IsMonthly) VALUES( @userID, @state, @days, @isWeekly, @isMonthly)";

                    command.AddParameter("userID", availability.User.ID);
                    command.AddParameter("state", availability.State);
                    command.AddParameter("days", availability.Days);
                    command.AddParameter("isWeekly", availability.IsWeekly);
                    command.AddParameter("isMonthly", availability.IsMonthly);

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
                            availability.State = (AvailabilityType)reader["State"];
                            availability.Days = (DayType) reader["Days"];
                            availability.IsWeekly = (bool) reader["IsWeekly"];
                            availability.IsMonthly = (bool) reader["IsMonthly"];
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
