using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoUsuarioPage : ContentPage
    {
        UserViewModel vm;
        public TipoUsuarioPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private void SbTipoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbTipoUsuario.Text;
            var itemsFilter = vm.GetNombreTipoUsuario(busq).Result;
            CvTipoUsuarios.ItemsSource = itemsFilter;
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnModificar_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Tipo de usuario", "¿Desea borrar el tipo de usuario?", "OK", "Cancelar");
            if (result == true)
            {
                //bool R = await vm.DeleteTipoUsuario(CvTipoUsuarios.SelectedItem);
            }
        }
    }
}