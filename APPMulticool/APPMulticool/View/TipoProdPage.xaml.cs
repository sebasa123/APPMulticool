using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;
using APPMulticool.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoProdPage : ContentPage
    {
        UserViewModel vm;
        string nom;
        public TipoProdPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            nom = ((TipoProducto)CvTipoProducto.SelectedItem).NombreTP;
        }

        private void SbTipoProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbTipoProducto.Text;
            var itemsFilter = vm.GetNombreTipoProducto(busq).Result;
            CvTipoProducto.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoProdManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Tipo de producto", "¿Desea borrar el tipo de producto?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteTipoProducto((TipoProductoDTO)CvTipoProducto.SelectedItem);
                if (R)
                {
                    await DisplayAlert("Tipo de producto", "El tipo de producto se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Tipo de producto", "Algo salio mal", "OK");
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoProdManagementPage(nom));
        }

        private void BtnSideMenu_Clicked(object sender, EventArgs e)
        {
            SideMenu.State = SideMenuState.LeftMenuShown;
        }

        private async void SmInicio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenuPage());
        }

        private async void SmSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}