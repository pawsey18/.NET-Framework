using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample1
{
    public class User
    {
        private INotificationService _notificationService;

        public User(string username, INotificationService notificationService)
        {
            Username = username;

            _notificationService = notificationService;
        }

        public string Username { get; set; }

        public void ChangeUsername(string newUsername)
        {
            Username = newUsername;
            _notificationService.NotifyUsernameChange(this);
        }
    }
}
