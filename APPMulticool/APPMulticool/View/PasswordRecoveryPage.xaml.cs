using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.ViewModels;
using APPMulticool.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordRecoveryPage : ContentPage
    {
        UserViewModel vm;
        public PasswordRecoveryPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadUsuarioList();
            
        }

        private async void LoadUsuarioList()
        {
            PckrUsuarios.ItemsSource = await vm.GetUsuario();
        }

        private async void BtnEnviarCodigo_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                bool R = await vm.AddCodigoRecuperacion(TxtEmail.Text.Trim());
                if (R)
                {
                    TxtEmail.IsEnabled = false;
                    await DisplayAlert("Codigo de recuperacion", "El codigo fue enviado", "OK");
                }
                else
                {
                    await DisplayAlert("Codigo de recuperacion", "Ocurrio un error", "OK");
                }
            }
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            var us = vm.GetUsuarioData((string)PckrUsuarios.SelectedItem);
            string nom = us.Result.NombreUs;
            int tipo = us.Result.FKTipoUsuario;
            if (!string.IsNullOrEmpty(TxtContra.Text.Trim()))
            {
                bool R = await vm.AddUsuario(nom, TxtContra.Text.Trim(), tipo);
                if (R)
                {
                    await DisplayAlert("Contraseña", "La contraseña se ha cambiado", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Contraseña", "Algo salio mal", "OK");
                }
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnCheckCodigo_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCodigo.Text))
            {
                bool R = await vm.ValidacionCodigoRecuperacion(TxtEmail.Text, TxtCodigo.Text);
                if (R)
                {
                    TxtContra.IsEnabled = true;
                    BtnApply.IsEnabled = true;
                    await DisplayAlert("Codigo correcto", "Digite la contraseña nueva", "OK");
                }
                else
                {
                    await DisplayAlert("Codigo incorrecto", "El codigo de recuperacion es incorrecto", "OK");
                }
            }
        }

    }
}