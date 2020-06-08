using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System.Text.RegularExpressions;

namespace EmployeesManagementSystem.Controllers
{
    public class RfidController
    {
        private List<Rfid> rfids;
        private List<User> users;

        private RfidContext rfidContext = new RfidContext();
        private UserContext userContext = new UserContext();

        public List<Rfid> Rfids { get => rfids; set => rfids = value; }
        public List<User> Users { get => users; set => users = value; }

        public RfidController()
        {
            this.rfids = rfidContext.GetAllRfids();
            this.users = userContext.GetAllUsers().OfType<User>().ToList();
        }

        // SaveRfid
        public void SaveRfid(string rfidNumber, int userId)
        {
            this.Rfids.Add(new Rfid(rfidNumber, userId, DateTime.Now, DateTime.Now));
        }

        public Rfid GetRfidByRfidID(string rfidId)
        {
            try
            {
                return this.Rfids.Where(r => r.RfidTag.Equals(rfidId)).First();
            }
            catch (Exception)
            {
                return null;
            }
        }
       

        // Get Rfid by Id
        public void DeleteRfidByRfidID(string rfidId)
        {
            try
            {
                Rfid rfid = new Rfid();
                rfid = this.Rfids.Where(r => r.RfidTag.Equals(rfidId)).First();
                this.Rfids.Remove(rfid);
            }
            catch (Exception ex) { }
        }

        // Generate random number for RFID
        public int GenerateRandomNo()
        {
            int _min = 10000000;
            int _max = 99999999;
            Random _rdm = new Random();

            return _rdm.Next(_min, _max);
        }

        // Validate Rfid
        public bool isRfidValid(string rfid)
        {
            Regex rx = new Regex(@"^[0-9]{8}$");
            return rx.IsMatch(rfid);
        }

        // Get User
        public User GetUserById(int id)
        {      
            return this.Users.Where(u => u.ID == id).First(); 
        }

        // Get Fullname
        public User GetUserByFullname(string name)
        {
            return this.Users.Where(u => u.FullName == name).First();
        }

        public bool ApplyAllChanges()
        {
            return rfidContext.Apply(this.Rfids);
        }
    }
}
