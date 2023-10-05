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
    public partial class ProductoPage : ContentPage
    {
        UserViewModel vm;
        public ProductoPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private void SbProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbProducto.Text;
            var itemsFilter = vm.GetNombreProducto(busq).Result;
            CvProducto.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProdManagementPage());
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProdManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Producto", "¿Desea borrar el producto?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteProducto((ProductoDTO)CvProducto.SelectedItem);
            }
        }
    }
}