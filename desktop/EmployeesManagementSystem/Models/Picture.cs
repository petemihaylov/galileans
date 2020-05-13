
namespace EmployeesManagementSystem.Models
{
    class Picture
    {
        public int ID { get; set; }
        public string UrlPath { get; set; }
        public User User { get; set; }


        public Picture(User user, string path)
        {
            this.UrlPath = path;
            this.User = user;
        }
        public Picture() { }
    }
}
