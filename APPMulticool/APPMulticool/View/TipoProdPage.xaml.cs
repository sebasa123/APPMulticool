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
    public partial class TipoProdPage : ContentPage
    {
        UserViewModel vm;
        public TipoProdPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadTipoProdList();
        }

        private async void LoadTipoProdList()
        {
            CvTipoProducto.ItemsSource = await vm.GetTipoProducto();
        }

        private void SbTipoProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbTipoProducto.Text;
            var itemsFilter = vm.GetNombreTipoProducto(busq).Result;
            CvTipoProducto.ItemsSource = itemsFilter;
        }

        private bool ValidateTipoProdData()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el nombre del tipo de producto", "OK");
                    TxtNombre.Focus();
                    return false;
                }
            }
            return R;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoProdData())
            {
                var resp = await DisplayAlert("Tipo de producto", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreTipoProducto(TxtNombre.Text.Trim()) == null)
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
                    else
                    {
                        await DisplayAlert("Tipo de producto", "El tipo de productoario ya existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var tipoprod = (TipoProducto)btn.BindingContext;
            int id = tipoprod.IDTP;

            var result = await DisplayAlert("Tipo de producto", "¿Desea borrar el tipo de producto?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteTipoProducto(id);
                if (R)
                {
                    await DisplayAlert("Tipo de producto", "El tipo de producto se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Tipo de producto", "Algo salio mal", "OK");
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoProdData())
            {
                var resp = await DisplayAlert("Tipo de producto", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreTipoProducto(TxtNombre.Text.Trim()) != null)
                    {
                        bool R = await vm.AddTipoProducto(TxtNombre.Text.Trim());
                        if (R)
                        {
                            await DisplayAlert("Tipo de producto", "Tipo de producto modificado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Tipo de producto", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Tipo de producto", "El tipo de productoario no existe", "OK");
                    }
                }
            }
        }

        private void CvTipoProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccion = (TipoProducto)e.CurrentSelection.FirstOrDefault();
            TxtNombre.Text = seleccion.NombreTP;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }
    }
}