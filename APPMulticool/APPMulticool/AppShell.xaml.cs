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
            //CurrentItem = shellViews;
            //shellViews.CurrentItem = shellMainMenu;
            Routing.RegisterRoute("menuPrincipal", typeof(MainMenuPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("usuario", typeof(UsuarioPage));
            Routing.RegisterRoute("tipous", typeof(TipoUsuarioPage));
            Routing.RegisterRoute("cliente", typeof(ClientePage));
            Routing.RegisterRoute("pedido", typeof(PedidoPage));
            Routing.RegisterRoute("repuesto", typeof(RepuestoPage));
            Routing.RegisterRoute("tiporep", typeof(TipoRepuestoPage));
            Routing.RegisterRoute("herramienta", typeof(HerramientaPage));
            Routing.RegisterRoute("producto", typeof(ProductoPage));
            Routing.RegisterRoute("tipoprod", typeof(TipoProdPage));
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}