using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class Rfid
    {
        public string RfidTag { get; set; }
        public int UserID { get; set; }
        public DateTime EnteredAt { get; set; }

        public DateTime LeftAt { get; set; }


        public Rfid(string rfidTag, int userID, DateTime entered, DateTime left)
        {
            this.RfidTag = rfidTag;
            this.UserID = userID;
            this.EnteredAt = entered;
            this.LeftAt = left;
        }
        public Rfid(string rfidTag, int userID)
        {
            this.RfidTag = rfidTag;
            this.UserID = userID;
        }
        public Rfid() { }
    }
}
