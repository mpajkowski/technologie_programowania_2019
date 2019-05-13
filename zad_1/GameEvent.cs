using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kasyno
{
    class GameEvent
    {
        public GameEvent(Gambler gambler, Seat seat, Game game, DateTimeOffset beginTime, DateTimeOffset? endTime)
        {
            Gambler = gambler;
            Seat = seat;
            Game = game;
            BeginTime = beginTime;
            EndTime = endTime;
        }

        public Gambler Gambler { get;  }
        public Seat Seat { get;  }
        public Game Game { get;  }
        public DateTimeOffset BeginTime { get;  }
        public DateTimeOffset? EndTime { get; set; }
    }
}
