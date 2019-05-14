using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    class Game
    {
        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; }
        public String Name { get; set; }

    }
}
