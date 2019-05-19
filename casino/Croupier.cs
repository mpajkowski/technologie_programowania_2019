using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Croupier : Person
    {
        public Croupier(string name, string surname, string phoneNumber, Address address) : base(name, surname, phoneNumber, address) { }
    }
}
