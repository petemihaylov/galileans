using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EmployeesManagementSystem.Data
{
    class CancellationContext : DbContext
    {

        // Should be implemented
        public override void Insert(object obj)
        {
            throw new NotImplementedException();
        }
        public override void DeleteById(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Cancellations WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Cancellations[] GetAnnouncements()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Cancellations";

                    con.Open();
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Models.Cancellations> cancels = new List<Models.Cancellations>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Models.Cancellations cancel = new Models.Cancellations();
                            cancel.ID = (int)reader["ID"];
                            cancel.Date = Convert.ToDateTime(((TimeSpan)reader["Date"]).ToString());
                            cancel.Employee = (string)reader["Employee"];
                            cancel.Subject = (string)reader["Subject"];
                            cancel.Description = (string)reader["Description"];
                            cancels.Add(cancel);
                        }
                        return cancels.ToArray();
                    }
                }
            }
        }
    }
}
