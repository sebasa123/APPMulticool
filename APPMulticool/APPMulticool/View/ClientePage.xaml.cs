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
    public partial class ClientePage : ContentPage
    {
        UserViewModel vm;
        public ClientePage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private void SbCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbCliente.Text;
            var itemsFilter = vm.GetNombreCliente(busq).Result;
            CvCliente.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClienteManagementPage());
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClienteManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Cliente", "¿Desea borrar el cliente?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteCliente((ClienteDTO)CvCliente.SelectedItem);
            }
        }
    }
}