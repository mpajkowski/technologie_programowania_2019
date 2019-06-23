using gui.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using Unity;
using gui.Model;
using services;
using gui.Utils;

namespace gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDialogService, DialogService>();
            containerRegistry.Register<IDataHandler, DataHandler>();
            containerRegistry.Register<Repository>();
        }
    }
}
