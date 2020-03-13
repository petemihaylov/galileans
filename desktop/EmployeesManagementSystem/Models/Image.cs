using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Image
    {
        public int ID { get; set; }
        public string UrlPath { get; set; }
        public int UserID { get; set; }

        public Image(int userId, string path)
        {
            this.UrlPath = path;
            this.UserID = userId;
        }
    }
}
