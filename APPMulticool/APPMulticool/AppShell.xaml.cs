using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainMenuPage), typeof(MainMenuPage));
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}