using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample1
{
    interface INotificationService
    {
        void NotifyUsernameChange(User user);
    }
}
