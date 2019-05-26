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
    public class GameEvent
    {
        public GameEvent() { }

        public GameEvent(ICollection<Gambler> gamblers, Croupier croupier, Seat seat, Game game, DateTimeOffset beginTime, DateTimeOffset? endTime)
        {
            if (beginTime > endTime)
            {
                throw new ArgumentException("beginTime > endTime!");
            }

            Id = Guid.NewGuid();
            Gamblers = gamblers;
            Croupier = croupier;
            Seat = seat;
            Game = game;
            BeginTime = beginTime;
            EndTime = endTime;
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set;  }
        [DataMember]
        public ICollection<Gambler> Gamblers { get; set; }
        [DataMember]
        public Croupier Croupier { get; set; }
        [DataMember]
        public Seat Seat { get; set; }
        [DataMember]
        public Game Game { get; set; }
        [DataMember]
        public DateTimeOffset BeginTime { get; set; }
        [DataMember]
        public DateTimeOffset? EndTime { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}," +
                $"{nameof(Gamblers)}: {Gamblers}," +
                $"{nameof(Croupier)}: {Croupier}," +
                $" {nameof(Seat)}: {Seat}," +
                $" {nameof(Game)}: {Game}," +
                $" {nameof(BeginTime)}: {BeginTime}," +
                $" {nameof(EndTime)}: {EndTime}";
        }

        public override bool Equals(object obj)
        {
            GameEvent @event = obj as GameEvent;
            return @event != null &&
                   EndTime != null &&
                   @event.EndTime != null &&
                   Id.Equals(@event.Id) &&
                   Gamblers.SequenceEqual(@event.Gamblers) &&
                   EqualityComparer<Croupier>.Default.Equals(Croupier, @event.Croupier) &&
                   EqualityComparer<Seat>.Default.Equals(Seat, @event.Seat) &&
                   EqualityComparer<Game>.Default.Equals(Game, @event.Game) &&
                   BeginTime.Equals(@event.BeginTime) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(EndTime, @event.EndTime);
        }

        public override int GetHashCode()
        {
            var hashCode = 423756076;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<Gambler>>.Default.GetHashCode(Gamblers);
            hashCode = hashCode * -1521134295 + EqualityComparer<Croupier>.Default.GetHashCode(Croupier);
            hashCode = hashCode * -1521134295 + EqualityComparer<Seat>.Default.GetHashCode(Seat);
            hashCode = hashCode * -1521134295 + EqualityComparer<Game>.Default.GetHashCode(Game);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(BeginTime);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset?>.Default.GetHashCode(EndTime);
            return hashCode;
        }
    }
}
