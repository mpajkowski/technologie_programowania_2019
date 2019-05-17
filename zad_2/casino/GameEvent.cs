using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class GameEvent
    {
        public GameEvent(ICollection<Gambler> gamblers, Croupier croupier, SeatState seatState, Game game, DateTimeOffset beginTime, DateTimeOffset? endTime)
        {
            if (beginTime > endTime)
            {
                throw new ArgumentException("beginTime > endTime!");
            }

            Id = Guid.NewGuid();
            Gamblers = gamblers;
            Croupier = croupier;
            SeatState = seatState;
            Game = game;
            BeginTime = beginTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}," +
                $"{nameof(Gamblers)}: {Gamblers}," +
                $"{nameof(Croupier)}: {Croupier}," +
                $" {nameof(SeatState)}: {SeatState}," +
                $" {nameof(Game)}: {Game}," +
                $" {nameof(BeginTime)}: {BeginTime}," +
                $" {nameof(EndTime)}: {EndTime}";
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set;  }
        public ICollection<Gambler> Gamblers { get; set; }
        public Croupier Croupier { get; set; }
        public SeatState SeatState { get; set; }
        public Game Game { get; set; }
        public DateTimeOffset BeginTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }

        public override bool Equals(object obj)
        {
            var @event = obj as GameEvent;
            return @event != null &&
                   Id.Equals(@event.Id) &&
                   EqualityComparer<IEnumerable<Person>>.Default.Equals(Gamblers, @event.Gamblers) &&
                   EqualityComparer<Person>.Default.Equals(Croupier, @event.Croupier) &&
                   EqualityComparer<SeatState>.Default.Equals(SeatState, @event.SeatState) &&
                   EqualityComparer<Game>.Default.Equals(Game, @event.Game) &&
                   BeginTime.Equals(@event.BeginTime) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(EndTime, @event.EndTime);
        }

        public override int GetHashCode()
        {
            var hashCode = 423756076;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<Person>>.Default.GetHashCode(Gamblers);
            hashCode = hashCode * -1521134295 + EqualityComparer<Person>.Default.GetHashCode(Croupier);
            hashCode = hashCode * -1521134295 + EqualityComparer<SeatState>.Default.GetHashCode(SeatState);
            hashCode = hashCode * -1521134295 + EqualityComparer<Game>.Default.GetHashCode(Game);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(BeginTime);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset?>.Default.GetHashCode(EndTime);
            return hashCode;
        }
    }
}
