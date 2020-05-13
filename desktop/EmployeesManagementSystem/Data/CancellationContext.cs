using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Data
{
    class CancellationContext : DbContext
    {

        // No required functionality
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
                            cancel.Date = (DateTime)reader["Date"];
                            cancel.EmployeeName = (string)reader["EmployeeName"];
                            cancel.Email = (string)reader["Email"];
                            cancel.Subject = (string)reader["Subject"];
                            cancel.Message = (string)reader["Message"];
                            cancel.EmployeeID = (int)reader["EmployeeID"];
                            cancel.ShiftID = (int)reader["ShiftID"];
                            cancels.Add(cancel);
                        }
                        return cancels.ToArray();
                    }
                }
            }
        }
        public Models.Cancellations GetCancellationByID(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Cancellations WHERE ID = @id";
                    command.AddParameter("id", id);

                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        Models.Cancellations cancel = new Models.Cancellations();
                        if (reader.Read())
                        {
                            // Mapping the return data to the object
                            cancel.ID = (int)reader["ID"];
                            cancel.Date = (DateTime)reader["Date"];
                            cancel.EmployeeName = (string)reader["EmployeeName"];
                            cancel.Email = (string)reader["Email"];
                            cancel.Subject = (string)reader["Subject"];
                            cancel.Message = (string)reader["Message"];
                            cancel.EmployeeID = (int)reader["EmployeeID"];
                            cancel.ShiftID = (int)reader["ShiftID"];

                        }
                        else
                        {
                            return null;
                        }

                        // getting the actual user
                        return cancel;
                    }
                }
            }
        }
    }
}
