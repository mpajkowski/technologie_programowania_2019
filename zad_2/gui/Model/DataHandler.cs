using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using casino;
using services;

namespace gui.Model
{
    public class DataHandler : IDataHandler
    {
        private Repository Repository { get; }

        public DataHandler(Repository repository)
        {
            Repository = repository;
        }

        public async void AddNewGambler(Gambler gambler)
        {
            await Task.Run(() => Repository.AddNewGambler(gambler));
        }

        public async Task<IEnumerable<Gambler>> FetchAllGamblers()
        {
            return await Repository.GetAllGamblers();
        }

        public async void RemoveGambler(Gambler gambler)
        {
            await Task.Run(() => Repository.RemoveGambler(gambler));
        }

        public async void UpdateGambler(Gambler updatedGambler)
        {
            await Task.Run(() => Repository.UpdateGambler(updatedGambler));
        }

        public async void AddNewCroupier(Croupier croupier)
        {
            await Task.Run(() => Repository.AddNewCroupier(croupier));
        }

        public async Task<IEnumerable<Croupier>> FetchAllCroupiers()
        {
            return await Repository.GetAllCroupiers();
        }

        public async void RemoveCroupier(Croupier croupier)
        {
            await Task.Run(() => Repository.RemoveCroupier(croupier));
        }

        public async void UpdateCroupier(Croupier updatedCroupier)
        {
            await Task.Run(() => Repository.UpdateCroupier(updatedCroupier));
        }

        public async void AddNewGame(Game game)
        {
            await Task.Run(() => Repository.AddNewGame(game));
        }

        public async Task<IEnumerable<Game>> FetchAllGames()
        {
           return await Repository.GetAllGames();
        }

        public async void RemoveGame(Game game)
        {
            await Task.Run(() => Repository.RemoveGame(game));
        }

        public async void UpdateGame(Game updatedGame)
        {
            await Task.Run(() => Repository.UpdateGame(updatedGame));
        }

        public async void AddNewGameEvent(GameEvent gameEvent)
        {
            await Task.Run(() => Repository.AddNewGameEvent(gameEvent));
        }

        public async Task<IEnumerable<GameEvent>> FetchAllGameEvents()
        {
            return await Repository.GetAllGameEvents();
        }

        public async void RemoveGameEvent(GameEvent gameEvent)
        {
            await Task.Run(() => Repository.RemoveGameEvent(gameEvent));
        }

        public async void UpdateGameEvent(GameEvent gameEvent)
        {
            await Task.Run(() => Repository.UpdateGameEvent(gameEvent));
        }
    }
}
