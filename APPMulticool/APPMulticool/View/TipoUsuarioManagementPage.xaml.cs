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
    public partial class TipoUsuarioManagementPage : ContentPage
    {
        UserViewModel vm;
        public TipoUsuarioManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            bool R = await vm.AddTipoUsuario(TxtNombre.Text.Trim());
            if (R)
            {
                await DisplayAlert("Tipo de usuario", "Tipo de usuario agregado", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Tipo de usuario", "Algo salio mal", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}