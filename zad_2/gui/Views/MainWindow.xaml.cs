using gui.Views;
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

namespace gui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCroupier_ButtonClick(object sender, RoutedEventArgs e)
        {
            NewCroupierWindow addNewCroupierWindow = new NewCroupierWindow();
            addNewCroupierWindow.Show();
        }

        private void NewGambler_ButtonClick(object sender, RoutedEventArgs e)
        {
            NewGamblerWindow addNewCroupierWindow = new NewGamblerWindow();
            addNewCroupierWindow.Show();
        }

        private void NewGame_ButtonClick(object sender, RoutedEventArgs e)
        {
            NewGameWindow addNewCroupierWindow = new NewGameWindow();
            addNewCroupierWindow.Show();
        }
        private void NewGameEvent_ButtonClick(object sender, RoutedEventArgs e)
        {
            NewGameEventWindow addNewCroupierWindow = new NewGameEventWindow();
            addNewCroupierWindow.Show();
        }
    }
}
