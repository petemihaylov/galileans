﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Data
{
    public class CancellationContext : DbContext
    {

        // Not required method
        public override bool Insert(object obj)
        {
            Cancellation cancel = (Cancellation)obj;

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Cancellation (Date, State, Subject, Message, UserID) VALUES( @date, @state, @subject, @message, @userId)";

                    command.AddParameter("date", cancel.Date);
                    command.AddParameter("state", cancel.State.ToString());
                    command.AddParameter("subject", cancel.Subject);
                    command.AddParameter("message", cancel.Message);
                    command.AddParameter("userId", cancel.Employee.ID);

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
                    command.CommandText = @"DELETE FROM Cancellation WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }

        public bool UpdateCancellation(Cancellation cancellation)
        {

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE Cancellation SET Date = @date, State = @state, Subject = @subject, Message = @message, UserID = @userId WHERE ID = @ID";
                    command.AddParameter("ID", cancellation.ID);
                    // Executing it 
                    command.Parameters.AddWithValue("date", cancellation.Date);
                    command.Parameters.AddWithValue("state", cancellation.State.ToString());
                    command.Parameters.AddWithValue("subject", cancellation.Subject);
                    command.Parameters.AddWithValue("message", cancellation.Message);
                    command.Parameters.AddWithValue("userId", cancellation.Employee.ID);

                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public Cancellation[] GetCancellations()
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Cancellation";

                    con.Open();
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Cancellation> cancellations = new List<Cancellation>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Cancellation c = new Cancellation();
                            MapObject(c, reader);
                            cancellations.Add(c);
                        }
                        return cancellations.ToArray();
                    }
                }
            }
        }
        public Cancellation GetCancellationByID(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Cancellation WHERE ID = @id";
                    command.AddParameter("id", id);

                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        Cancellation cancellation = new Cancellation();
                        if (reader.Read())
                        {
                            MapObject(cancellation, reader);
                        }
                        else { return null; }

                        return cancellation;
                    }
                }
            }
        }
        private Cancellation MapObject(Cancellation cancellation, MySqlDataReader reader)
        {
            cancellation.ID = (int)reader["ID"];
            cancellation.Date = (DateTime)reader["Date"];
            cancellation.Employee.ID = (int)reader["UserID"];

            Enum.TryParse((string)reader["State"], out CState cState);
            cancellation.State = cState;

            cancellation.Subject = (string)reader["Subject"];
            cancellation.Message = (string)reader["Message"];
            return cancellation;
        }
    }
}
