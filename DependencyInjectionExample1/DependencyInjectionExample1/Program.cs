using System;

namespace DependencyInjectionExample1
{
    class Program 
    {
        static void Main(string[] args)
        {
            var notificationService = new ConsoleNotification();
            var user1 = new User("Robin", notificationService);
            user1.ChangeUsername("Locke");

            Console.ReadLine();
        }
    }
}
