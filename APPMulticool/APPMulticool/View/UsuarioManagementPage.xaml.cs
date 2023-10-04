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
    public partial class UsuarioManagementPage : ContentPage
    {
        UserViewModel vm;
        public UsuarioManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadTipoList();
        }

        public UsuarioManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadTipoList();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            TipoUsuario tu = PckrTU.SelectedItem as TipoUsuario;
            bool R = await vm.AddUsuario(TxtNombre.Text.Trim(),
                TxtContra.Text.Trim(), tu.IDTU);
            if (R)
            {
                await DisplayAlert("Usuario", "Usuario agregado", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Usuario", "Algo salio mal", "OK");
            }
        }

        private async void LoadTipoList() 
        {
            PckrTU.ItemsSource = await vm.GetTipoUsuario();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}