using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample1
{
    public class ConsoleNotification : INotificationService
    {
        public void NotifyUsernameChange(User user)
        {
            Console.WriteLine($"Username has been updated to: {user.Username}");

        }

    }
}
