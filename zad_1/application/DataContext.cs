using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using casino;

namespace application
{
    public class DataContext
    {
        public List<Gambler> gamblers;
        public List<Croupier> croupiers;
        public List<Game> games;
        public List<Seat> seats;
        public List<SeatState> seatStates;
        public ObservableCollection<GameEvent> gameEvents;

        public DataContext()
        {
            gamblers = new List<Gambler>();
            croupiers = new List<Croupier>();
            games = new List<Game>();
            seats = new List<Seat>();
            seatStates = new List<SeatState>();
            gameEvents = new ObservableCollection<GameEvent>();

            gameEvents.CollectionChanged += GameEvents_CollectionChanged;
        }

        private void GameEvents_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    GameEvents_CollectionAddCallback(e);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    GameEvents_CollectionRemoveCallback(e);
                    break;
            }
        }

        private void GameEvents_CollectionAddCallback(NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Added new items:");
            foreach (var item in e.NewItems) {
                Console.WriteLine(item);
            }
        }

        private void GameEvents_CollectionRemoveCallback(NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Removed following items:");
            foreach (var item in e.NewItems) {
                Console.WriteLine(item);
            }
        }

        public override bool Equals(object obj)
        {
            var context = obj as DataContext;
            return context != null &&
                   gamblers.SequenceEqual(context.gamblers) &&
                   croupiers.SequenceEqual(context.croupiers) &&
                   games.SequenceEqual(context.games) &&
                   seats.SequenceEqual(context.seats) &&
                   seatStates.SequenceEqual(context.seatStates) &&
                   gameEvents.SequenceEqual(context.gameEvents);
        }

        public override int GetHashCode()
        {
            var hashCode = 329031736;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Gambler>>.Default.GetHashCode(gamblers);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Croupier>>.Default.GetHashCode(croupiers);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Game>>.Default.GetHashCode(games);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Seat>>.Default.GetHashCode(seats);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<SeatState>>.Default.GetHashCode(seatStates);
            hashCode = hashCode * -1521134295 + EqualityComparer<ObservableCollection<GameEvent>>.Default.GetHashCode(gameEvents);
            return hashCode;
        }
    }
}
