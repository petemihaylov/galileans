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
        private ShiftContext shiftContext = new ShiftContext();

        public List<Rfid> Rfids { get => rfids; set => rfids = value; }
        public List<User> Users { get => users; set => users = value; }

        public RfidController()
        {
            this.rfids = rfidContext.GetAllRfids();
            this.users = userContext.GetAllUsers().OfType<User>().ToList();
        }

        // Saves the passed Rfid object
        public void Insert(Rfid rfid)
        {
            this.Rfids.Add(rfid);
            rfidContext.Insert(rfid);
        }
        // Updates Rfid by the tag
        public void UpdateRfid(Rfid rfid)
        {
            rfidContext.UpdateRfid(rfid);
        }
        // Gets List of rfids from DB
        public List<Rfid> GetRfids()
        {
            return this.rfidContext.GetAllRfids();
        }
        // Returns rfid
        public Rfid GetRfidByRfidID(string rfidId)
        {
            return rfidContext.GetRfid(rfidId);
        }
        // Delete rfid from the DB
        public void DeleteRfidByRfidID(string rfidId)
        {
            try
            {
                Rfid rfid = new Rfid();
                rfid = this.Rfids.Where(r => r.RfidTag.Equals(rfidId)).First();
                this.Rfids.Remove(rfid);
                this.rfidContext.DeleteById(rfidId);
            }
            catch (Exception ex) { }
        }
        // Gets random number for the RFID tag
        public int GenerateRandomNo()
        {
            int _min = 10000000;
            int _max = 99999999;
            Random _rdm = new Random();

            return _rdm.Next(_min, _max);
        }

        public List<Rfid> SortRfidByUser(User user)
        {

            List<Rfid> rfids = this.GetRfids();
            if (user == null) return rfids;

            return rfids.FindAll(o => o.UserID == user.ID).ToList();
        }
        // Validates
        public bool isRfidValid(string rfid)
        {
            Regex rx = new Regex(@"^[0-9]{8}$");
            return rx.IsMatch(rfid);
        }
        // Returns User by id
        public User GetUserById(int id)
        {
            return this.Users.Where(u => u.ID == id).First();
        }
        // Marks shift of the user with attended in DB
        public bool CanCheckIn(User user, DateTime date)
        {
            Shift shift = shiftContext.GetShiftByDate(date, user);

            if (shift != null)
            {
                shift.Attended = true;
                shiftContext.UpdateShift(shift);
                return true;
            }
            return false;
        }
        // Returns user by fullname
        public User GetUserByFullname(string name)
        {
            try { return this.Users.Where(u => u.FullName == name).First(); }
            catch (Exception)
            {
                return null;
            }
        }
        // Returns a new generated Users rfid tag collection
        public Dictionary<User, int> GetUsers()
        {
            Dictionary<User, int> result = new Dictionary<User, int>();


            this.Users.ForEach(user =>

                result.Add(user, GenerateRandomNo())
            );

            return result;
        }

    }
}
