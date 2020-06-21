using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Data
{
    class RfidContext : DbContext
    { 
        public override bool Insert(object obj)
        {
            Rfid rfid = (Rfid)obj;
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO RfidUser (Rfid, UserID, EnteredAt, LeftAt)" +
                    " VALUES(@rfidTag, @userId, @enteredAt, @leftAt);";

                    command.AddParameter("rfidTag", rfid.RfidTag);
                    command.AddParameter("userId", rfid.UserID);
                    command.AddParameter("enteredAt", rfid.EnteredAt);
                    command.AddParameter("leftAt", rfid.LeftAt);

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
                    command.CommandText = @"DELETE FROM RfidUser WHERE id = @Id;";
                    command.AddParameter("Id", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public bool DeleteById(string id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM RfidUser WHERE Rfid = @Id;";
                    command.AddParameter("Id", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public bool DeleteAllRows()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM RfidUser;";
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public Rfid GetRfid(string id)
        {
            using (var con = new MySqlConnection(connectionString))
            {

                Rfid rfid = new Rfid();
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM RfidUser WHERE Rfid = @Id;";
                    command.AddParameter("Id", id);

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MapObject(rfid, reader);
                           
                        }

                    }

                  
                }
                return rfid;
            }
        }

        public bool UpdateRfid(Rfid rfid)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"UPDATE RfidUser SET UserID = @userId, EnteredAt = @enteredAt, LeftAt = @leftAt WHERE Rfid = @rfidTag";

                    command.AddParameter("rfidTag", rfid.RfidTag);
                    command.AddParameter("userId", rfid.UserID);
                    command.AddParameter("enteredAt", rfid.EnteredAt);
                    command.AddParameter("leftAt", rfid.LeftAt);

                    return command.ExecuteNonQuery() > 0 ? true : false;

                }
            }


        }
        public List<Rfid> GetAllRfids()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM RfidUser;";

                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Rfid> rfids = new List<Rfid>();
                        while (reader.Read())
                        {
                            Rfid rfid = new Rfid();
                            MapObject(rfid, reader);

                            rfids.Add(rfid);
                        }

                        return rfids;
                    }
                }
            }
        }
        public List<Rfid> GetAllRfidsByUserId(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM RfidUser WHERE UserID = @id;";
                    command.AddParameter("id", id);


                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Rfid> rfids = new List<Rfid>();
                        while (reader.Read())
                        {
                            Rfid rfid = new Rfid();
                            MapObject(rfid, reader);

                            rfids.Add(rfid);
                        }

                        return rfids;
                    }
                }
            }
        }


        public bool Apply(List<Rfid> rfids)
        {
            DeleteAllRows();

            foreach (Rfid r in rfids)
            {
                Insert(r);
            }

            return true;
        }

        private Rfid MapObject(Rfid rfid, MySqlDataReader reader)
        {
            rfid.RfidTag= (string)reader["Rfid"];
            rfid.UserID = (int)reader["UserID"];
            rfid.EnteredAt = (DateTime)reader["EnteredAt"];
            rfid.LeftAt = (DateTime)reader["LeftAt"];
            return rfid;            
        }
    }
}
