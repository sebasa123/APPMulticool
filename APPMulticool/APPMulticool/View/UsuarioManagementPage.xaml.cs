using System;
using System.Collections.Generic;
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
    public partial class UsuarioManagementPage : ContentPage
    {
        UserViewModel vm;
        private string nom;
        private string contra;
        private int tipo;

        public UsuarioManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadTipoList();
        }

        public UsuarioManagementPage(string nom, string contra, int tipo)
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadTipoList();
            this.nom = nom;
            this.contra = contra;
            this.tipo = tipo;
            LoadUsuarioData();
        }

        private void LoadUsuarioData()
        {
            TxtNombre.Text = nom;
            TxtContra.Text = contra;
            PckrTU.SelectedIndex = tipo;
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            if (ValidateUsuarioData())
            {
                var resp = await DisplayAlert("Usuario", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    TipoUsuario tu = PckrTU.SelectedItem as TipoUsuario;
                    bool R = await vm.AddUsuario(TxtNombre.Text.Trim(),
                        TxtContra.Text.Trim(), tu.IDTU);
                    if (R)
                    {
                        await DisplayAlert("Usuario", "Informacion agregada", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Usuario", "Algo salio mal", "OK");
                    }
                }
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

        private bool ValidateUsuarioData()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtContra.Text != null && !string.IsNullOrEmpty(TxtContra.Text.Trim()) &&
                PckrTU.SelectedIndex != -1)
            {
                R = true;
            }
            else
            {
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el nombre de usuario", "OK");
                    TxtNombre.Focus();
                    return false;
                }
                if (TxtContra.Text == null || string.IsNullOrEmpty(TxtContra.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar la contraseña", "OK");
                    TxtContra.Focus();
                    return false;
                }
                if (PckrTU.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de escoger un tipo de usuario", "OK");
                    PckrTU.Focus();
                    return false;
                }
            }
            return R;
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