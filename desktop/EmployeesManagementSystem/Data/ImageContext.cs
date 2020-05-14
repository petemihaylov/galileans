using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;

namespace EmployeesManagementSystem.Data
{
    public class ImageContext : DbContext
    {
        public override bool Insert(object obj)
        {
            Picture image = (Picture)obj;
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Image (UserID, UrlPath)" +
                    " VALUES(@userId, @urlPath)";

                    command.AddParameter("userId", image.User.ID);
                    command.AddParameter("urlPath", image.UrlPath);
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
                    command.CommandText = @"DELETE FROM Image WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
        }
        public Picture GetImgByUser(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Image WHERE UserID = @userId";
                    command.AddParameter("userId", id);

                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        Picture img = new Picture();
                        if (reader.Read())
                        {
                            MapObject(img, reader);
                        }
                        else
                        { return null; }

                        return img;
                    }
                }
            }
        }
        public void DeleteImgByUserId(int id)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Image WHERE UserID = @userID";
                    command.AddParameter("userID", id);
                    command.ExecuteNonQuery();
                }

            }
        }
        private Picture MapObject(Picture picture, MySqlDataReader reader)
        {
            picture.ID = (int)reader["ID"];
            picture.UrlPath = (string)reader["UrlPath"];
            picture.User.ID = (int)reader["UserID"];

            return picture;
        }
    }
}
