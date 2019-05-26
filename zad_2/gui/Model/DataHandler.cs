﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using casino;
using services;

namespace gui.Model
{
    public class DataHandler : IDataHandler
    {
        private Repository repository;

        public DataHandler()
        {
            this.repository = new Repository();
        }

        public void AddNewGambler(Gambler gambler)
        {
            Task.Run(() => repository.AddNewGambler(gambler));
        }

        public async Task<IEnumerable<Gambler>> GetAllGamblers()
        {
            return await repository.GetAllGamblers();
        }

        public void RemoveGambler(Gambler gambler)
        {
            Task.Run(() => repository.RemoveGambler(gambler));
        }

        public void UpdateGambler(Gambler updatedGambler)
        {
            Task.Run(() => repository.UpdateGambler(updatedGambler));
        }

        public void AddNewCroupier(Croupier croupier)
        {
            Task.Run(() => repository.AddNewCroupier(croupier));
        }

        public Croupier GetCroupier(Croupier croupier)
        {
            return repository.GetCroupier(croupier);
        }

        public Task<IEnumerable<Croupier>> GetAllCroupiers()
        {
            return repository.GetAllCroupiers();
        }

        public void RemoveCroupier(Croupier croupier)
        {
            Task.Run(() => repository.RemoveCroupier(croupier));
        }

        public void UpdateCroupier(Croupier updatedCroupier)
        {
            Task.Run(() => repository.UpdateCroupier(updatedCroupier));
        }

        public void AddNewGame(Game game)
        {
            Task.Run(() => repository.AddNewGame(game));
        }

        public Game GetGame(Game game)
        {
            return repository.GetGame(game);
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            return await repository.GetAllGames();
        }

        public void RemoveGame(Game game)
        {
            Task.Run(() => repository.RemoveGame(game));
        }

        public void UpdateGame(Game updatedGame)
        {
            Task.Run(() => repository.UpdateGame(updatedGame));
        }

        public void AddNewSeat(Seat seat)
        {
            Task.Run(() => repository.AddNewSeat(seat));
        }

        public Seat GetSeat(Seat seat)
        {
            return repository.GetSeat(seat);
        }

        public async Task<IEnumerable<Seat>> GetAllSeats()
        {
            return await repository.GetAllSeats();
        }

        public void RemoveSeat(Seat seat)
        {
            Task.Run(() => repository.RemoveSeat(seat));
        }

        public void AddNewGameEvent(GameEvent gameEvent)
        {
            Task.Run(() => repository.AddNewGameEvent(gameEvent));
        }

        public GameEvent GetGameEvent(GameEvent gameEvent)
        {
            return repository.GetGameEvent(gameEvent);
        }

        public async Task<IEnumerable<GameEvent>> GetAllGameEvents()
        {
            return await repository.GetAllGameEvents();
        }

        public void RemoveGameEvent(GameEvent gameEvent)
        {
            Task.Run(() => repository.AddNewGameEvent(gameEvent));
        }
    }
}
