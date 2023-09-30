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
    public partial class Producto : ContentPage
    {
        UserViewModel vm;
        public Producto()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            Models.TipoProducto tp = PckrTP.SelectedItem as Models.TipoProducto;
            bool R = await vm.AddProducto(TxtNombre.Text.Trim(), tp.IDTP);
            if (R)
            {
                await DisplayAlert("Producto", "Producto agregado", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Producto", "Algo salio mal", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}