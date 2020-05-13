using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesManagementSystem.Models;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Data
{
    class  DataConverterCSV
    {
        private string fileName;
        private string filePath;
        
        public DataConverterCSV(string fileName)
        {
            this.fileName = fileName;

            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.filePath = pathDesktop + $"\\{this.fileName}.csv";
        }

        // General way 
        public void CSVFileWrite<T>(List<T> items) where T : class
        {
            if (!File.Exists(this.filePath))
            {
                File.Create(this.filePath).Close();
            }

            using (TextWriter writer = File.CreateText(this.filePath))
            {
                var csv = "";
                var delimiter = ',';
                var properties = typeof(T).GetProperties()
                 .Where(n =>
                 n.PropertyType == typeof(string)
                 || n.PropertyType == typeof(bool)
                 || n.PropertyType == typeof(char)
                 || n.PropertyType == typeof(byte)
                 || n.PropertyType == typeof(decimal)
                 || n.PropertyType == typeof(int)
                 || n.PropertyType == typeof(DateTime)
                 || n.PropertyType == typeof(DateTime?));

                using (var sw = new StringWriter())
                {
                    var header = properties
                    .Select(n => n.Name)
                    .Aggregate((a, b) => a + delimiter + b); sw.WriteLine(header); foreach (var item in items)
                    {
                        var row = properties
                        .Select(n => n.GetValue(item, null))
                        .Select(n => n == null ? "null" : n.ToString()).Aggregate((a, b) => a + delimiter + b); sw.WriteLine(row);
                    }
                    csv = sw.ToString();
                }

                writer.WriteLine(csv);
            }
        }  

        // General way
        public void CSVFileRead()
        {
            try
            {
                if (File.Exists(this.filePath))
                {
                    string[] lines = File.ReadAllLines(this.filePath);

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] fields = lines[i].Split(',');

                        Array.ForEach(fields, element => Console.WriteLine(element));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This file can't be read: ", ex);
            }
        }

        public void CSVFileReadByField(string search, int position)
        {
            try
            {
                if (File.Exists(this.filePath))
                {
                    string[] lines = File.ReadAllLines(this.filePath);

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] fields = lines[i].Split(',');
                        if (findFieldMatches(search, fields, position))
                        {
                            Array.ForEach(fields, element => Console.WriteLine(element));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This file can't be read: ", ex);
            }

        }

        private bool findFieldMatches(string search, string[] record, int position)
        {
            if (record[position].Equals(search))
            {
                return true;
            }

            return false;
        }
    }
}
