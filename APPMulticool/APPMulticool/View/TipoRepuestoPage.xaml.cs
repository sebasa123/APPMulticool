using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;
using APPMulticool.ViewModels;
using APPMulticool.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoRepuestoPage : ContentPage
    {
        UserViewModel vm;
        public TipoRepuestoPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private void SbTipoRepuesto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbTipoRepuesto.Text;
            var itemsFilter = vm.GetNombreTipoRepuesto(busq).Result;
            CvTipoRepuesto.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoRepManagementPage());
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoRepManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Tipo de repuesto", "¿Desea borrar el tipo de repuesto?", "OK", "Cancelar");
            if (result)
            {
                bool R = await vm.DeleteTipoRepuesto((TipoRepuestoDTO)CvTipoRepuesto.SelectedItem);
            }
        }
    }
}