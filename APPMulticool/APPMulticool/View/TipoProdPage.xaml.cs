using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoProdPage : ContentPage
    {
        UserViewModel vm;
        public TipoProdPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
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
            await Navigation.PushAsync(new TipoProdManagementPage());
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Tipo de usuario", "¿Desea borrar el tipo de usuario?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteTipoProducto((TipoProductoDTO)CvTipoProducto.SelectedItem);
            }
        }
    }
}