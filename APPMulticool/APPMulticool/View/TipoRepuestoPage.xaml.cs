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
using Xamarin.CommunityToolkit.UI.Views;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoRepuestoPage : ContentPage
    {
        UserViewModel vm;
        string desc;
        public TipoRepuestoPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            desc = ((TipoRepuesto)CvTipoRepuesto.SelectedItem).DescripcionTR;
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
            await Navigation.PushAsync(new TipoRepManagementPage(desc));
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Tipo de repuesto", "¿Desea borrar el tipo de repuesto?", "OK", "Cancelar");
            if (result)
            {
                bool R = await vm.DeleteTipoRepuesto((TipoRepuestoDTO)CvTipoRepuesto.SelectedItem);
                if (R)
                {
                    await DisplayAlert("Tipo de repuesto", "El tipo de repuesto se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Tipo de repuesto", "Algo salio mal", "OK");
                }
            }
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