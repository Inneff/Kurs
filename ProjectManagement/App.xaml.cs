using BLL;
using ProjectManagement.utils;
using Ninject;
using System.Windows;

namespace ProjectManagement
{
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel(new NinjectRegistrations(), new ServiceModule());
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.Title = "ProjectManagement App";
        }
    }
}
