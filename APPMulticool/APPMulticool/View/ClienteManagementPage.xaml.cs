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
    public partial class ClienteManagementPage : ContentPage
    {
        UserViewModel vm;
        public ClienteManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            int Cedula = int.Parse(TxtCedula.Text.Trim());
            bool R = await vm.AddCliente(TxtNombre.Text.Trim(),
                TxtApellido.Text.Trim(), Cedula,
                TxtDireccion.Text.Trim());
            if (R)
            {
                await DisplayAlert("Cliente", "Cliente agregado correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Cliente", "Algo salio mal", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}