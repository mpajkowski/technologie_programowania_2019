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
                throw new ArgumentException("BeginTime > endTime!");
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
    }
}
