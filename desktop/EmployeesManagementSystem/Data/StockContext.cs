using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EmployeesManagementSystem.Models;
using System.Data;

namespace EmployeesManagementSystem.Data
{
    public class StockContext : DbContext
    {
        public override bool Insert(object obj)
        {
            Stock stock = (Stock)obj;

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Stock (Name, Amount, Price, Availability, DepartmentID)" +
                    " VALUES(@name, @amount, @price, @availability, @departmentID)";

                    command.AddParameter("name", stock.Name);
                    command.AddParameter("price", stock.Price);
                    command.AddParameter("amount", stock.Amount);
                    command.AddParameter("availability", stock.Availability);
                    command.AddParameter("departmentID", stock.Department.ID);
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
                    command.CommandText = @"DELETE FROM Stock WHERE ID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public bool DeleteByDepartment(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Stock WHERE DepartmentID = @ID";
                    command.AddParameter("ID", id);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public Stock[] GetAllStocks()
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();


                using (var command = new MySqlCommand("SELECT * FROM Stock", con))
                {
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Stock> stocks = new List<Stock>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Stock stock = new Stock();
                            MapObject(stock, reader);
                            stocks.Add(stock);
                        }
                        return stocks.ToArray();
                    }
                }
            }
        }

        public DataTable GetStockTable()
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // select statement
                    command.CommandText = @"SELECT * FROM Stock";

                    // executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        if (reader.Read())
                        {
                            table.Load(reader);
                        }

                        return table;
                    }
                }
            }
        }

        // Doesn't work properly
        public bool UpdateStock(Stock stock)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"UPDATE Stock SET Name = @name, Price = @price, Amount = @amount, Availability = @availability WHERE ID = @ID";
                    command.AddParameter("ID", stock.ID);
                    // Executing it 
                    command.Parameters.AddWithValue("@name", stock.Name);
                    command.Parameters.AddWithValue("@price", stock.Price);
                    command.Parameters.AddWithValue("@amount", stock.Amount);
                    command.Parameters.AddWithValue("@availability", stock.Availability);
                    return command.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public Stock GetStockById(int id)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    // Select statement
                    command.CommandText = @"SELECT * FROM Stock WHERE ID = @stockId";
                    command.AddParameter("stockId", id);

                    // Ececuting it 
                    using (var reader = command.ExecuteReader())
                    {
                        Stock stock = new Stock();
                        if (reader.Read())
                        {
                            MapObject(stock, reader);
                        }
                        else { return null; }

                        return stock;
                    }
                }
            }
        }

        public Stock[] GetAllFilteredStocks(DataTable table)
        {
            List<Stock> stocks = new List<Stock>();

            foreach (DataRow row in table.Rows)
            {
                Stock stock = new Stock();
                stock.ID = (int) row["ID"];
                stock.Name = (string) row["Name"];
                stock.Price = (double) row["Price"];
                stock.Amount = (int) row["Amount"];
                stock.Availability = (bool) row["Availability"];
                stock.Department.ID = (int) row["DepartmentID"];

                stocks.Add(stock);
            }

            return stocks.ToArray();
        }

        private Stock MapObject(Stock stock, MySqlDataReader reader)
        {

            stock.ID = (int)reader["ID"];
            stock.Name = (string)reader["Name"];
            stock.Price = (double)reader["Price"];
            stock.Amount = (int)reader["Amount"];
            stock.Availability = (bool)reader["Availability"];
            stock.Department.ID = (int)reader["DepartmentID"];

            return stock;
        }

        public Stock[] SearchByName(string name)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Stock WHERE Name LIKE @name";
                    command.Parameters.AddWithValue("@name", name + "%");
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Stock> stocks = new List<Stock>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Stock stock = new Stock();
                            MapObject(stock, reader);
                            stocks.Add(stock);
                        }
                        return stocks.ToArray();
                    }
                }
            }
        }
        public Stock[] StocksByDepID(string name)
        {
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var command = con.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Stock WHERE Department = @name";
                    command.Parameters.AddWithValue("@name", name);
                    // Executing it 
                    using (var reader = command.ExecuteReader())
                    {
                        List<Stock> stocks = new List<Stock>();
                        while (reader.Read())
                        {
                            // Mapping the return data to the object
                            Stock stock = new Stock();
                            MapObject(stock, reader);
                            stocks.Add(stock);
                        }
                        return stocks.ToArray();
                    }
                }
            }
        }

    }
}
