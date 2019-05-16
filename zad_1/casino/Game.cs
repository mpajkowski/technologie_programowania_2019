using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Game
    {
        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; }
        public String Name { get; set; }

        public override bool Equals(object obj)
        {
            var game = obj as Game;
            return game != null &&
                   Id.Equals(game.Id) &&
                   Name == game.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
