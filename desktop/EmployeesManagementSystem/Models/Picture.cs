
namespace EmployeesManagementSystem.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string UrlPath { get; set; }
        private User user = new User();
        public User User { get { return user; } set { this.user = value; } }


        public Picture(User user, string path)
        {
            this.UrlPath = path;
            this.User = user;
        }
        public Picture() { }
    }
}
