using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class SeatState
    {
        public SeatState(Seat seat, bool available)
        {
            Seat = seat;
            Available = available;
        }

        public Seat Seat { get;  }
        public bool Available { get; set; }
    }
}
