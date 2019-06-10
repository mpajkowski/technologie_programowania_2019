using gui.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel.MainViewModel.Instance;
        }

        private void NewCroupier_ButtonClick(object sender, RoutedEventArgs e)
        {
            AddNewCroupierWindow addNewCroupierWindow = new AddNewCroupierWindow();
            addNewCroupierWindow.Show();
        }

        private void NewGambler_ButtonClick(object sender, RoutedEventArgs e)
        {
            AddNewGamblerWindow addNewCroupierWindow = new AddNewGamblerWindow();
            addNewCroupierWindow.Show();
        }

        private void NewGame_ButtonClick(object sender, RoutedEventArgs e)
        {
            AddNewGameWindow addNewCroupierWindow = new AddNewGameWindow();
            addNewCroupierWindow.Show();
        }
        private void NewGameEvent_ButtonClick(object sender, RoutedEventArgs e)
        {
            AddNewGameEventWindow addNewCroupierWindow = new AddNewGameEventWindow();
            (DataContext as ViewModel.MainViewModel).NewGameEventGamblers = new ObservableCollection<casino.Gambler>();
            addNewCroupierWindow.Show();
        }
    }
}
