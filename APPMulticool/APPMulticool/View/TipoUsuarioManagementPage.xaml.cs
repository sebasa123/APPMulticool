using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoUsuarioManagementPage : ContentPage
    {
        UserViewModel vm;
        private string tipo;

        public TipoUsuarioManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        public TipoUsuarioManagementPage(string tipo)
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            this.tipo = tipo;
            LoadTipoUsuarioData();
        }
        private void LoadTipoUsuarioData()
        {
            TxtNombre.Text = tipo;
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoUsuarioData())
            {
                var resp = await DisplayAlert("Tipo de usuario", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    bool R = await vm.AddTipoUsuario(TxtNombre.Text.Trim());
                    if (R)
                    {
                        await DisplayAlert("Tipo de usuario", "Informacion agregada", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Tipo de usuario", "Algo salio mal", "OK");
                    }
                }
            }
        }

        private bool ValidateTipoUsuarioData()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el nombre del tipo de usuario", "OK");
                    TxtNombre.Focus();
                    return false;
                }
            }
            return R;
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
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
            await Navigation.PushAsync(new LoginPage());
        }
    }
}