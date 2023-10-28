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
            CheckTipoUsuario(GlobalObjects.LocalUsuario.FKTipoUsuario);
        }

        private void CheckTipoUsuario(int pTipoUs)
        {
            if (pTipoUs != 1)
            {
                //BtnUsuarioManagement.IsEnabled = false;
                //BtnTipoUsuarioManagement.IsEnabled = false;
            }
        }

        private void BtnPedidoManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PedidoPage());
        }
        private void BtnRepuestoManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RepuestoPage());
        }
        private void BtnTipoRepuestoManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TipoRepuestoPage());
        }
        private void BtnClienteManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClientePage());
        }
        private void BtnProductoManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductoPage());
        }
        private void BtnTipoProductoManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TipoProdPage());
        }
        private void BtnHerramientaManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HerramientaPage());
        }
        private void BtnUsuarioManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsuarioPage());
        }
        private void BtnTipoUsuarioManagement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TipoUsuarioPage());
        }

    }
}