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

        public override bool Equals(object obj)
        {
            var state = obj as SeatState;
            return state != null &&
                   EqualityComparer<Seat>.Default.Equals(Seat, state.Seat) &&
                   CreationTime.Equals(state.CreationTime);
        }

        public override int GetHashCode()
        {
            var hashCode = -1243353683;
            hashCode = hashCode * -1521134295 + EqualityComparer<Seat>.Default.GetHashCode(Seat);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(CreationTime);
            return hashCode;
        }
    }
}
