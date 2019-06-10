using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Gambler : Person
    {
        public Gambler() : base(string.Empty, string.Empty, string.Empty) { GameEvents = new HashSet<GameEvent>();  }
        public Gambler(string name, string surname, string phoneNumber) : base(name, surname, phoneNumber) { }
        public ICollection<GameEvent> GameEvents { get; set; }
    }
}
