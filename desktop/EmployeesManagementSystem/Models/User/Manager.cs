
namespace EmployeesManagementSystem.Models
{
    class Manager : User
    {
        public Manager(int id, string fullName, string email, string phoneNumber, string password, double wage)
            : base(id, fullName, email, phoneNumber, password, Role.Manager, wage)
        {

        }
    }
}
