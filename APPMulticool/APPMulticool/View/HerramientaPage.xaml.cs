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
    public partial class HerramientaPage : ContentPage
    {
        UserViewModel vm;
        public HerramientaPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private void SbHeramienta_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbHeramienta.Text;
            var itemsFilter = vm.GetNombreHerramienta(busq).Result;
            CvHerramienta.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HerramientaManagementPage());
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HerramientaManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Herramienta", "¿Desea borrar la herramienta?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteHerramienta((HerramientaDTO)CvHerramienta.SelectedItem);
            }
        }
    }
}