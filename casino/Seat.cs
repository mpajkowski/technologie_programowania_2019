﻿using System;
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
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Game)}: {Game}";
        }

        public Seat(Game game)
        {
            Id = Guid.NewGuid();
            Game = game;
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set;  }

        [DataMember]
        public Game Game { get; }

        public override bool Equals(object obj)
        {
            var seat = obj as Seat;
            return seat != null &&
                   Id.Equals(seat.Id) &&
                   EqualityComparer<Game>.Default.Equals(Game, seat.Game);
        }

        public override int GetHashCode()
        {
            var hashCode = 1076413479;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Game>.Default.GetHashCode(Game);
            return hashCode;
        }
    }
}