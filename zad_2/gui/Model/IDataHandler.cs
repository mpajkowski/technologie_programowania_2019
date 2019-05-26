using casino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.Model
{
    public interface IDataHandler
    {
        void AddNewGambler(Gambler gambler);

        IEnumerable<Gambler> GetAllGamblers();

        void RemoveGambler(Gambler gambler);

        void UpdateGambler(Gambler updatedGambler);

        void AddNewCroupier(Croupier croupier);

        Croupier GetCroupier(Croupier croupier);

        IEnumerable<Croupier> GetAllCroupiers();

        void RemoveCroupier(Croupier croupier);

        void UpdateCroupier(Croupier updatedCroupier);

        void AddNewGame(Game game);

        Game GetGame(Game game);

        IEnumerable<Game> GetAllGames();

        void RemoveGame(Game game);

        void UpdateGame(Game updatedGame);

        void AddNewSeat(Seat seat);

        Seat GetSeat(Seat seat);

        IEnumerable<Seat> GetAllSeats();

        void RemoveSeat(Seat seat);

        void AddNewGameEvent(GameEvent gameEvent);

        GameEvent GetGameEvent(GameEvent gameEvent);

        IEnumerable<GameEvent> GetAllGameEvents();

        void RemoveGameEvent(GameEvent gameEvent);
    }
}
