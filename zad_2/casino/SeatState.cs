using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"{nameof(Seat)}: {Seat}," +
                   $" {nameof(CreationTime)}: {CreationTime}," +
                   $" {nameof(IsAvailable)}: {IsAvailable}";
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Seat Seat { get; }
        public DateTimeOffset CreationTime { get; }
        public bool IsAvailable { get; set; }
    }
}
