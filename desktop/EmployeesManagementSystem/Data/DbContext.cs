using System;
using System.Configuration;
using System.Data;

namespace EmployeesManagementSystem
{
    public abstract class DbContext
    {
        protected string connectionString;
        public DbContext()
        {
            // Change the connection string in the App.config file
            connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public abstract bool Insert(object obj);
        public abstract bool DeleteById(int id);

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
