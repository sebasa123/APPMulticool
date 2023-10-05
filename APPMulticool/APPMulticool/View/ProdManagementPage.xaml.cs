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
    public partial class ProdManagementPage : ContentPage
    {
        UserViewModel vm;
        public ProdManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadTPList();
        }
        private async void LoadTPList()
        {
            PckrTP.ItemsSource = await vm.GetProducto();
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