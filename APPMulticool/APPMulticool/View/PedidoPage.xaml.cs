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
    public partial class PedidoPage : ContentPage
    {
        UserViewModel vm;
        public PedidoPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private void SbPedido_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbPedido.Text;
            var itemsFilter = vm.GetNombrePedido(busq).Result;
            CvPedido.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PedidoManagementPage());
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PedidoManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Pedido", "¿Desea borrar el pedido?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeletePedido((PedidoDTO)CvPedido.SelectedItem);
            }
        }
    }
}