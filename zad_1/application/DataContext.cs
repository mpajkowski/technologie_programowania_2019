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
        public List<Person> gamblers;
        public List<Person> croupiers;
        public List<Game> games;
        public List<Seat> seats;
        public Dictionary<Seat, Game> seatGamesMap;
        public List<SeatState> seatStates;
        public ObservableCollection<GameEvent> gameEvents;

        public DataContext()
        {
            gamblers = new List<Person>();
            croupiers = new List<Person>();
            games = new List<Game>();
            seats = new List<Seat>();
            seatGamesMap = new Dictionary<Seat, Game>();
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
    }
}
