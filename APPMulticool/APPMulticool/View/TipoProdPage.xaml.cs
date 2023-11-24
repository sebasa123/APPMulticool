using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;
using APPMulticool.ViewModels;
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
            CheckTipoUsuario(GlobalObjects.LocalUsuario.FKTipoUsuario);
        }
        private void CheckTipoUsuario(int pTipoUs)
        {
            if (pTipoUs == 3)
            {
                Bv1.IsVisible = false;
                LblTP.IsVisible = false;
                TxtID.IsVisible = false;
                TxtNombre.IsVisible = false;
                Bv2.IsVisible = false;
                BtnAgregar.IsVisible = false;
                BtnModificar.IsVisible = false;
                BtnEliminar.IsVisible = false;
            }
        }

        private async void LoadTipoProdList()
        {
            LstTipoProducto.ItemsSource = await vm.GetTipoProductos();
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
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var idtp = (LstTipoProducto.SelectedItem as TipoProducto).IDTP;
            var result = await DisplayAlert("Tipo de producto", "¿Desea borrar el tipo de producto?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteTipoProducto(idtp);
                if (R)
                {
                    await DisplayAlert("Tipo de producto", "El tipo de producto se borro correctamente", "OK");
                    await Navigation.PopAsync();
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
                var idtp = (LstTipoProducto.SelectedItem as TipoProducto).IDTP;
                var resp = await DisplayAlert("Tipo de producto", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    bool R = await vm.UpdateTipoProducto(idtp, TxtNombre.Text.Trim());
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
            }
        }


        private void LstTipoProducto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (TipoProducto)e.SelectedItem;
            TxtID.Text = seleccion.IDTP.ToString();
            TxtNombre.Text = seleccion.NombreTP;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstTipoProducto_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstTipoProducto.IsRefreshing = false;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private async void SbTipoProducto_SearchButtonPressed(object sender, EventArgs e)
        {
            string busqueda = SbTipoProducto.Text.Trim();
            var filtro = await vm.GetNombreTipoProducto(busqueda);
            LstTipoProducto.ItemsSource = filtro;
        }
    }
}