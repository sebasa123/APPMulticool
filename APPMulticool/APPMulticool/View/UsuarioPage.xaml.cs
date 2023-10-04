using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.Services;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioPage : ContentPage
    {
        UserViewModel vm;
        public UsuarioPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadUsuarioList();
        }
        private async void LoadUsuarioList()
        {
            CvUsuarios.ItemsSource = await vm.GetUsuario();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioManagementPage());
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {         
            var result = await this.DisplayAlert("Usuario", "¿Desea borrar el usuario?", "OK", "Cancelar");
            if (result)
            {
                bool R = await vm.DeleteUsuario((UsuarioDTO)CvUsuarios.SelectedItem);
            }
        }

        private void SbUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbUsuario.Text;
            var itemsFilter = vm.GetNombreUsuario(busq).Result;
            CvUsuarios.ItemsSource = itemsFilter;
        }
    }
}