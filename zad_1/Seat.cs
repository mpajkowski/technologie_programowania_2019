using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    class Seat
    {
        private static int seatCounter = 0;

        public Seat(int number, int game)
        {
            Number = seatCounter++;
            Game = game;
        }

        public int Number { get; }
        public int Game { get; set; }
    }
}
