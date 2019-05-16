using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Seat
    {
        private static int seatCounter = 0;

        public Seat()
        {
            Number = seatCounter++;
        }

        public int Number { get; }
    }
}
