using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;
using APPMulticool.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoPage : ContentPage
    {
        UserViewModel vm;
        public ProductoPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadProdList();
            LoadTPList();
        }

        private async void LoadProdList()
        {
            LstProducto.ItemsSource = await vm.GetProductos();
        }

        private async void LoadTPList()
        {
            PckrTP.ItemsSource = await vm.GetTipoProducto();
        }

        private bool ValidateProductoData()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                PckrTP.SelectedIndex != -1)
            {
                R = true;
            }
            else
            {
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el nombre del producto", "OK");
                    TxtNombre.Focus();
                    return false;
                }
                if (PckrTP.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de escoger un tipo de producto", "OK");
                    PckrTP.Focus();
                    return false;
                }
            }
            return R;
        }

        private void SbProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbProducto.Text;
            var itemsFilter = vm.GetNombreProducto(busq).Result;
            LstProducto.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateProductoData())
            {
                var resp = await DisplayAlert("Producto", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreProducto(TxtNombre.Text.Trim()) == null)
                    {
                        TipoProducto tp = PckrTP.SelectedItem as TipoProducto;
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
                    else
                    {
                        await DisplayAlert("Producto", "El producto ya existe", "OK");
                    }
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateProductoData())
            {
                var resp = await DisplayAlert("Producto", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreProducto(TxtNombre.Text.Trim()) != null)
                    {
                        TipoProducto tp = PckrTP.SelectedItem as TipoProducto;
                        bool R = await vm.AddProducto(TxtNombre.Text.Trim(), tp.IDTP);
                        if (R)
                        {
                            await DisplayAlert("Producto", "Producto modificado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Producto", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Producto", "El producto no existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var prod = (Producto)btn.BindingContext;
            int id = prod.IDProd;

            var result = await DisplayAlert("Producto", "¿Desea borrar el producto?", "OK", "Cancelar");
            if (result)
            {
                bool R = await vm.DeleteProducto(id);
                if (R)
                {
                    await DisplayAlert("Producto", "El producto se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Producto", "Algo salio mal", "OK");
                }
            }
        }

        private void LstProducto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (Producto)e.SelectedItem;
            TxtNombre.Text = seleccion.NombreProd;
            PckrTP.SelectedIndex = seleccion.FKTipoProd;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstProducto_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstProducto.IsRefreshing = false;
        }
    }
}