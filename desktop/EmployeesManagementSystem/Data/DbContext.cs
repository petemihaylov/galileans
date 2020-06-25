using System;
using System.Configuration;
using System.Data;

namespace EmployeesManagementSystem
{
    public abstract class DbContext : Data.IDBContext
    {
        private string connectionString;

        protected string ConnectionString { get => connectionString; set => connectionString = value; }

        public DbContext()
        {
            // Change the connection string in the App.config file
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            }
            catch (Exception)
            {
                ConnectionString = "Server=remotemysql.com;Uid=Crj2OTSNvh;Database=Crj2OTSNvh;Pwd=3bNXrfEhiw;";
            }
        }

        public DbContext(string connection)
        {
            this.ConnectionString = connection;
        } 

        public abstract bool Insert(object obj);
        public abstract bool DeleteById(int id);

        public string GetConnectionString()
        {
            return this.ConnectionString;
        }

        public void SetConnectionString(string connection)
        {
            this.ConnectionString = connection;
        }
    }

    //
    // Helping Class
    //
    public static class CommandExtensions
    {
        /// <summary>
        ///     This method is not part of a IDbCommand interface.  
        /// </summary>
        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");

            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value ?? DBNull.Value;
            command.Parameters.Add(p);
        }
    }
}
