using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class GameEvent
    {
        public GameEvent(List<Person> gamblers, Person croupier, Seat seat, Game game, DateTimeOffset beginTime, DateTimeOffset? endTime)
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

        public Guid Id { get; }
        public List<Person> Gamblers { get;  }
        public Person Croupier { get; }
        public Seat Seat { get;  }
        public Game Game { get;  }
        public DateTimeOffset BeginTime { get;  }
        public DateTimeOffset? EndTime { get; set; }

        public override bool Equals(object obj)
        {
            var @event = obj as GameEvent;
            return @event != null &&
                   Id.Equals(@event.Id) &&
                   EqualityComparer<List<Person>>.Default.Equals(Gamblers, @event.Gamblers) &&
                   EqualityComparer<Person>.Default.Equals(Croupier, @event.Croupier) &&
                   EqualityComparer<Seat>.Default.Equals(Seat, @event.Seat) &&
                   EqualityComparer<Game>.Default.Equals(Game, @event.Game) &&
                   BeginTime.Equals(@event.BeginTime) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(EndTime, @event.EndTime);
        }

        public override int GetHashCode()
        {
            var hashCode = -596209425;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Person>>.Default.GetHashCode(Gamblers);
            hashCode = hashCode * -1521134295 + EqualityComparer<Person>.Default.GetHashCode(Croupier);
            hashCode = hashCode * -1521134295 + EqualityComparer<Seat>.Default.GetHashCode(Seat);
            hashCode = hashCode * -1521134295 + EqualityComparer<Game>.Default.GetHashCode(Game);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(BeginTime);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset?>.Default.GetHashCode(EndTime);
            return hashCode;
        }
    }
}
