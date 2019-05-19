using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using casino;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            Gambler g = new Gambler("Żołnierz", "Fortuny", "05-825", new Address("Grodzisk", "05-825", "abc", "PL"));
            Gambler b = new Gambler("Hej", "Hej", "05-825", new Address("Grodzisk", "05-825", "abc", "PL"));

            List<Gambler> gamblers = new List<Gambler>
            {
                g,
                b
            };

            Service service = new Service(null);
            Console.WriteLine(service.GetGamblersInfo(gamblers));

            Thread.Sleep(4000);
        }
    }
}
