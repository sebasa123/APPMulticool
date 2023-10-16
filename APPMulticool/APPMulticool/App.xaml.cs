using System;
using APPMulticool.Services;
using APPMulticool.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; private set; }
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage (new LoginPage());
            //MainPage = new NavigationPage(new MainMenuPage());
            //MainPage = new NavigationPage(new UsuarioPage());
            //MainPage = new NavigationPage(new UsuarioManagementPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
