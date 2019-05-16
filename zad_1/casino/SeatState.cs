using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class SeatState
    {
        public SeatState(Seat seat)
        {
            Seat = seat;
            CreationTime = new DateTimeOffset();
        }

        public Seat Seat { get;  }
        public DateTimeOffset CreationTime { get;  }
    }
}
