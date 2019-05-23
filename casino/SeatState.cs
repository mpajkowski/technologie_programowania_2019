using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    [DataContract]
    public class SeatState
    {
        public SeatState(Seat seat)
        {
            Seat = seat;
            CreationTime = new DateTimeOffset();
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"{nameof(Seat)}: {Seat}," +
                   $" {nameof(CreationTime)}: {CreationTime}," +
                   $" {nameof(IsAvailable)}: {IsAvailable}";
        }

        public override bool Equals(object obj)
        {
            var state = obj as SeatState;
            return state != null &&
                   Id.Equals(state.Id) &&
                   EqualityComparer<Seat>.Default.Equals(Seat, state.Seat) &&
                   CreationTime.Equals(state.CreationTime) &&
                   IsAvailable == state.IsAvailable;
        }

        public override int GetHashCode()
        {
            var hashCode = -1871079971;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Seat>.Default.GetHashCode(Seat);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(CreationTime);
            hashCode = hashCode * -1521134295 + IsAvailable.GetHashCode();
            return hashCode;
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DataMember]
        public Seat Seat { get; }
        [DataMember]
        public DateTimeOffset CreationTime { get; }
        [DataMember]
        public bool IsAvailable { get; set; }
    }
}
