namespace EmployeesManagementSystem.Models
{
    public class Administrator : User
    {
        public Administrator(int id, string fullName, string email, string phoneNumber, string password, double wage)
            : base(id, fullName, email, phoneNumber, password, Role.Administrator, wage)
        {

        }
    }
}
