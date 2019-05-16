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
            Console.WriteLine(g.Id);
            Console.WriteLine(g.Name);
            Thread.Sleep(4000);
        }
    }
}
