using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.View;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private async void BtnPedidoManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PedidoPage());
        }

        private async void BtnRepuestoManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RepuestoPage());
        }

        private async void BtnTipoRepuestoManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoRepuestoPage());
        }

        private async void BtnClienteManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientePage());
        }

        private async void BtnProductoManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductoPage());
        }

        private async void BtnTipoProductoManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoProdPage());
        }

        private async void BtnHerramientaManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HerramientaPage());
        }

        private async void BtnUsuarioManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new UsuarioPage()));
        }

        private async void BtnTipoUsuarioManagement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoUsuarioPage());
        }

    }
}