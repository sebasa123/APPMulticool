using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserViewModel vm;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = vm = new UserViewModel();
        }

        private void SwContra_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwContra.IsToggled)
            {
                TxtContra.IsPassword = false;
            }
            else
            {
                TxtContra.IsPassword = true;
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtContra.Text != null && !string.IsNullOrEmpty(TxtContra.Text.Trim()))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Revisando acceso");
                    await Task.Delay(2000);
                    string nombre = TxtNombre.Text.Trim();
                    string contra = TxtContra.Text.Trim();
                    R = await vm.UsuarioAccessValidation(nombre, contra);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
            else
            {
                await DisplayAlert("Error de validacion", "Es necesario ingresar el nombre de usuario y la contraseña", "OK");
                return;
            }
            if (R)
            {
                GlobalObjects.LocalUsuario = await vm.GetUsuarioData(TxtNombre.Text.Trim());
                TxtNombre.Text = null;
                TxtContra.Text = null;
                SwContra.IsToggled = false;
                await Navigation.PushAsync(new MainMenuPage());
                return;
            }
            else
            {
                await DisplayAlert("Error de validacion", "Acceso denegado", "OK");
                return;
            }
        }

        private void BtnRecContra_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PasswordRecoveryPage());
        }
    }
}