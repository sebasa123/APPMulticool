using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.ViewModels;
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
        }

        private async void BtnEnviarCodigo_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                bool R = await vm.AddCodigoRecuperacion(TxtEmail.Text.Trim());
                if (true)
                {
                    TxtEmail.IsEnabled = false;
                    await DisplayAlert("Codigo de recuperacion", "El codigo fue enviado", "OK");
                }
            }
        }
    }
}