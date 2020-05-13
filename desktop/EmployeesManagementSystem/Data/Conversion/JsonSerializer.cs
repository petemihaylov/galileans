using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem
{
    /*  
     *  Documentation with examples 
     *  https://www.newtonsoft.com/json/help/html/SerializeWithJsonSerializerToFile.htm
     */
    class JsonSerializer
    {
        public string filePath { get; set; }

        public JsonSerializer(string path)
        {
            this.filePath = path;
        }

        public bool Write(Object obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                Console.WriteLine(json);

                File.WriteAllText(filePath,json);
                return true;
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine("Can't Serialize the Obj" + ex.Message);
            }
            return false;

        }

        public bool Write(List<Object> objs)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objs, Formatting.Indented);
                Console.WriteLine(json);

                File.WriteAllText(filePath, json);
                return true;
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine("Can't Serialize the Obj" + ex.Message);
            }
            return false;
        }
    }
}
