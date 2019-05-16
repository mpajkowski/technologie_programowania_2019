using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Seat
    {
        public Seat(Game game)
        {
            Id = Guid.NewGuid();
            Game = game;
        }

        public Guid Id { get; }

        public Game Game { get; }

        public override bool Equals(object obj)
        {
            var seat = obj as Seat;
            return seat != null &&
                   EqualityComparer<Game>.Default.Equals(Game, seat.Game);
        }

        public override int GetHashCode()
        {
            return 764056639 + EqualityComparer<Game>.Default.GetHashCode(Game);
        }
    }
}