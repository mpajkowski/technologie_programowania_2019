using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Croupier : Person
    {
        public Croupier() : base(string.Empty, string.Empty, string.Empty) { }
        public Croupier(string name, string surname, string phoneNumber) : base(name, surname, phoneNumber) { }
    }
}
