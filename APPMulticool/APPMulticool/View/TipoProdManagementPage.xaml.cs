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
    public partial class TipoProdManagementPage : ContentPage
    {
        UserViewModel vm;
        public TipoProdManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            bool R = await vm.AddTipoProducto(TxtNombre.Text.Trim());
            if (R)
            {
                await DisplayAlert("Tipo de producto", "Tipo de producto agregado", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Tipo de producto", "Algo salio mal", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}