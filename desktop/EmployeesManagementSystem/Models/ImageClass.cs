using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class ImageClass
    {
        public int ID { get; set; }
        public string UrlPath { get; set; }
        public int UserID { get; set; }

        public ImageClass(int userId, string path)
        {
            this.UrlPath = path;
            this.UserID = userId;
        }
        public ImageClass() { }
    }
}
