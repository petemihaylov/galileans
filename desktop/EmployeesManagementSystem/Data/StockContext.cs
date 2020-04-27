using EmployeesManagementSystem.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EmployeesManagementSystem.Data
{
    class StockContext : DbContext
    {
        public Stock[] GetAllStocks()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();


                using (var command = new MySqlCommand("SELECT * FROM Stocks", con))
                {
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Stock> stocks = new List<Stock>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Stock stock = new Stock();

                            stock.ID = (int)reader["ID"];
                            stock.Name = (string)reader["Name"];
                            stock.Price = (double)reader["Price"];
                            stock.Amount = (int)reader["Amount"];
                            stock.Availability = (bool)reader["Availability"];
                            stocks.Add(stock);
                        }
                        return stocks.ToArray();
                    }
                }
            }
        }
        
        public void UpdateStockByID(int ID, string name, double price, int amount, bool availability)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE Stocks SET Name = @name, Price = @price, Amount = @amount, Availability = @availability WHERE ID = @ID";
                    command.AddParameter("ID", ID);
                    // Executing it 
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@availability", availability);
                    command.ExecuteNonQuery();
                }
            }
        }

        public override void Insert(object obj)
        {
            Stock stock = (Stock)obj;

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Stocks (Name, Amount, Price, Availability)" +
                    " VALUES(@name, @amount, @price, @availability)";

                    command.AddParameter("name", stock.Name);
                    command.AddParameter("price", stock.Price);
                    command.AddParameter("amount", stock.Amount);
                    command.AddParameter("availability", stock.Availability);
                    command.ExecuteNonQuery();
                }
            }
        }
        public override void DeleteById(int stockId)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Stocks WHERE ID = @ID";
                    command.AddParameter("ID", stockId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Stock GetStockByID(int ID)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Stocks WHERE ID = @stockId";
                    command.AddParameter("stockId", ID);

                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        Stock stock = new Stock();
                        if (reader.Read())
                        {
                            // Mapping the return data to the object
                            stock.ID = (int)reader["ID"];
                            stock.Name = (string)reader["Name"];
                            stock.Amount = (int)reader["Amount"];
                            stock.Price = (double)reader["Price"];
                            stock.Availability = (bool)reader["Availability"];
                        }
                        else
                        {
                            return null;
                        }

                        return stock;
                    }
                }
            }
        }

      
     }
}
