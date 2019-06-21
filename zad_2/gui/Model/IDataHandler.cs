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

        Task<IEnumerable<Gambler>> FetchAllGamblers();

        void RemoveGambler(Gambler gambler);

        void UpdateGambler(Gambler updatedGambler);

        void AddNewCroupier(Croupier croupier);

        Task<IEnumerable<Croupier>> FetchAllCroupiers();

        void RemoveCroupier(Croupier croupier);

        void UpdateCroupier(Croupier updatedCroupier);

        void AddNewGame(Game game);

        Task<IEnumerable<Game>> FetchAllGames();

        void RemoveGame(Game game);

        void UpdateGame(Game updatedGame);

        void AddNewGameEvent(GameEvent gameEvent);

        IEnumerable<GameEvent> FetchAllGameEvents();

        void UpdateGameEvent(GameEvent gameEvent);

        void RemoveGameEvent(GameEvent gameEvent);
    }
}
