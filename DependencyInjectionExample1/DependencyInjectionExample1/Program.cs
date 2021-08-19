using System;

namespace DependencyInjectionExample1
{
    class Program 
    {
        static void Main(string[] args)
        {
            var user1 = new User("Robin");
            user1.ChangeUsername("Locke");

            Console.ReadLine();
        }

    
    }
}
