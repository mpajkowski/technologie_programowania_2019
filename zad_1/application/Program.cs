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
            Person g = new Person("Żołnierz", "Fortuny", "05-825", new Address("Grodzisk", "05-825", "abc", new System.Globalization.RegionInfo("pl")));
            Person b = new Person("Hej", "Hej", "05-825", new Address("Grodzisk", "05-825", "abc", new System.Globalization.RegionInfo("pl")));

            List<Person> gamblers = new List<Person>
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
