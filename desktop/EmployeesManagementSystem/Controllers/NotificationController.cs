using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Controllers
{
    class NotificationController
    {
        private NotificationContext notificationContext = new NotificationContext();
        private UserContext userContext = new UserContext();

        public void AddMessage(string message, int userId)
        {
            User user = userContext.GetUserByID(userId);

            if(user != null)
            notificationContext.Insert(new Notification(message, user));
        }
    }
}
