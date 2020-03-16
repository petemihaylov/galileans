using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;

namespace EmployeesManagementSystem.Data
{
    class ImageContext : DbContext
    {
        
        public ImageClass GetImgByUser(int userId)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Images WHERE UserID = @userId";
                    command.AddParameter("userId", userId);

                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        ImageClass img = new ImageClass();
                        if (reader.Read())
                        {
                            // Mapping the return data to the object
                            img.ID = (int)reader["ID"];
                            img.UserID = (int)reader["UserID"];
                            img.UrlPath = (string)reader["UrlPath"];
                        }
                        else
                        {
                            return null;
                        }

                        return img;
                    }
                }
            }
        }
        public void DeleteImgByUserId(int userId)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Images WHERE UserID = @userID";
                    command.AddParameter("userID", userId);
                    command.ExecuteNonQuery();
                }

            }
        }
        

        public override void Insert(object obj)
        {
            ImageClass image = (ImageClass)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Images (UserID, UrlPath)" +
                    " VALUES(@userId, @urlPath)";

                    command.AddParameter("userId", image.UserID);
                    command.AddParameter("urlPath", image.UrlPath);
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
                    command.CommandText = @"DELETE FROM Images WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
