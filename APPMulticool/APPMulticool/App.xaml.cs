using System;
using APPMulticool.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new LoginPage();
            MainPage = new MainMenuPage();
            //MainPage = new UsuarioManagementPage();
            //MainPage = new UsuarioPage();
            //MainPage = new PasswordRecoveryPage();
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
