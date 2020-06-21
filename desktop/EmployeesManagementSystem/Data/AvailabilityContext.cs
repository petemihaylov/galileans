using System.Collections.Generic;
using MySql.Data.MySqlClient;
using EmployeesManagementSystem.Models;
using System.Linq;
using System;

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
                    command.AddParameter("days", availability.GetDays());
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
                    command.CommandText = @"SELECT * FROM Availability where UserID = @id";
                    command.AddParameter("id", id);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Availability> avs = new List<Availability>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            // Mapping the return data to the object
                            Availability a = new Availability();
                            MapObject(a, reader);
                            avs.Add(a);
                        }
                        return avs.ToArray();
                    }
                }
            }
        }

        public Availability[] GetAllAvailabilities()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Availability";

                    con.Open();
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Availability> avs = new List<Availability>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Availability a = new Availability();
                            MapObject(a, reader);
                            avs.Add(a);
                        }
                        return avs.ToArray();
                    }
                }
            }
        }

        public bool UpdateAvailabilityInfo(Availability availability)
        {

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE Availability SET State = @state, Days = @days, IsWeekly = @isWeekly, IsMonthly = @isMonthly WHERE UserID = @userID";
                   

                    command.Parameters.AddWithValue("userID", availability.User.ID);
                    command.Parameters.AddWithValue("state", availability.State.ToString());
                    command.Parameters.AddWithValue("days", availability.GetDays());
                    command.Parameters.AddWithValue("isWeekly", availability.IsWeekly);
                    command.Parameters.AddWithValue("isMonthly", availability.IsMonthly);
                    // Executing it 
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        private Availability MapObject(Availability availability, MySqlDataReader reader)
        {
            // Mapping the return data to the object
            availability.User.ID = (int)reader["UserID"];

            Enum.TryParse((string)reader["State"], out AvailabilityType state);
            availability.State = state;
        
            string text = (string)reader["Days"];

            // Converting all of the day names to DayType
            List<string> days = text.Split(',').ToList<string>();
            List<DayType> res = new List<DayType>();
            foreach (var item in days)
            {
                Enum.TryParse(item, out DayType d);
                res.Add(d);
            }

            availability.Days = res;
            availability.IsWeekly = (bool)reader["IsWeekly"];
            availability.IsMonthly = (bool)reader["IsMonthly"];

            return availability;
        }

    }
}

