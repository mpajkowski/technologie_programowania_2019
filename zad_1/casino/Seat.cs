using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Seat
    {
        private static int numberCounter = 0;

        public static int GetNextNumber()
        {
            return numberCounter++;
        }

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

        public Seat(Game game)
        {
            Game = game;
        }
    }
}
