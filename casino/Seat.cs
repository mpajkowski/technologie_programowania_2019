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
    public class Seat
    {
        public Seat() { }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Game)}: {Game}";
        }

        public override bool Equals(object obj)
        {
            var seat = obj as Seat;
            return seat != null &&
                   Id.Equals(seat.Id) &&
                   EqualityComparer<Game>.Default.Equals(Game, seat.Game) &&
                   IsAvailable == seat.IsAvailable;
        }

        public override int GetHashCode()
        {
            var hashCode = 1087062119;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Game>.Default.GetHashCode(Game);
            hashCode = hashCode * -1521134295 + IsAvailable.GetHashCode();
            return hashCode;
        }

        public Seat(Game game)
        {
            Id = Guid.NewGuid();
            Game = game;
            IsAvailable = true;
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set;  }

        [DataMember]
        public Game Game { get; set; }

        [DataMember]
        public bool IsAvailable { get; set; }
    }
}