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

        public override bool Equals(object obj)
        {
            var seat = obj as Seat;
            return seat != null &&
                   Number == seat.Number;
        }

        public override int GetHashCode()
        {
            return 187193536 + Number.GetHashCode();
        }
    }
}
