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
            PckrUsuarios.ItemDisplayBinding = new Binding("NombreUs");
        }

        private async void BtnEnviarCodigo_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                bool R = await vm.AddCodigoRecuperacion(TxtEmail.Text.Trim());
                if (R)
                {
                    TxtEmail.IsEnabled = false;
                    TxtCodigo.IsEnabled = true;
                    BtnCheckCodigo.IsEnabled = true;
                    await DisplayAlert("Codigo de recuperacion", "El codigo fue enviado", "OK");
                }
                else
                {
                    await DisplayAlert("Codigo de recuperacion", "Ocurrio un error", "OK");
                }
            }
            else
            {
                await DisplayAlert("Codigo de recuperacion", "Digite el correo electronico", "OK");
            }
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            var us = vm.GetUsuarioData((string)PckrUsuarios.SelectedItem);
            UsuarioDTO backup = new UsuarioDTO();
            backup = GlobalObjects.LocalUs;
            GlobalObjects.LocalUs.NombreUs = us.Result.NombreUs;
            GlobalObjects.LocalUs.ContrasUs = us.Result.ContrasUs;
            GlobalObjects.LocalUs.FKTipoUsuario = us.Result.FKTipoUsuario;
            GlobalObjects.LocalUs.EstadoUs = true;

            try
            {
                bool R = await vm.UpdateUsuario(GlobalObjects.LocalUs);
                if (R)
                {
                    await DisplayAlert("Contraseña", "La contraseña se ha cambiado", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Contraseña", "Algo salio mal", "OK");
                    GlobalObjects.LocalUs = backup;
                }
            }
            catch (Exception)
            {
                GlobalObjects.LocalUs = backup;
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
                    PckrUsuarios.IsEnabled = true;
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