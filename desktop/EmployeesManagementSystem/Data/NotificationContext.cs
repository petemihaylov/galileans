using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;
using System;

namespace EmployeesManagementSystem.Data
{
    public class NotificationContext : DbContext
    {
        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(object obj)
        {
            Notification notification = (Notification)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                using (var command = con.CreateCommand())
                {
                    con.Open();

                    command.CommandText = @"INSERT INTO Notification (Message, UserID) VALUES(@message, @userId);";

                    command.AddParameter("message", notification.Message);
                    command.AddParameter("userId", notification.User.ID);
 
                    return command.ExecuteNonQuery() > 0 ? true : false;

                }
            }
        }
    }
}
