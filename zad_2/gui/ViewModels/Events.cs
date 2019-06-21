using casino;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.ViewModels
{
    public class GamblersFetchedMessage : PubSubEvent<ObservableCollection<Gambler>> { }
    public class CroupiersFetchedMessage : PubSubEvent<ObservableCollection<Croupier>> { }
    public class GamesFetchedMessage : PubSubEvent<ObservableCollection<Game>> { }
    public class GameEventsFetchedMessage : PubSubEvent<ObservableCollection<GameEvent>> { }

    public class DataRequest : PubSubEvent { }

    public class GamblerAddedMessage : PubSubEvent<Gambler> { }
    public class CroupierAddedMessage : PubSubEvent<Croupier> { }
    public class GameAddedMessage : PubSubEvent<Game> { }
    public class GameEventAddedMessage : PubSubEvent<GameEvent> { }
}
