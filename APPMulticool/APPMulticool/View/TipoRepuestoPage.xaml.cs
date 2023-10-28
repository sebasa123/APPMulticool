using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;
using APPMulticool.ViewModels;
using APPMulticool.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoRepuestoPage : ContentPage
    {
        UserViewModel vm;
        public TipoRepuestoPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadTipoRepList();
        }

        private async void LoadTipoRepList()
        {
            LstTipoRepuesto.ItemsSource = await vm.GetTipoRepuestos();
        }

        private bool ValidateTipoRepData()
        {
            bool R = false;
            if (TxtDescripcion.Text != null && !string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (TxtDescripcion.Text == null || string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar la descripcion del tipo de repuesto", "OK");
                    TxtDescripcion.Focus();
                    return false;
                }
            }
            return R;
        }

        private void SbTipoRepuesto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbTipoRepuesto.Text;
            var itemsFilter = vm.GetNombreTipoRepuesto(busq).Result;
            LstTipoRepuesto.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoRepData())
            {
                var resp = await DisplayAlert("Tipo de repuesto", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreTipoRepuesto(TxtDescripcion.Text.Trim()) == null)
                    {
                        bool R = await vm.AddTipoRepuesto(TxtDescripcion.Text.Trim());
                        if (R)
                        {
                            await DisplayAlert("Tipo de repuesto", "Tipo de repuesto agregado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Tipo de repuesto", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Tipo de repuesto", "El tipo de repuesto ya existe", "OK");
                    }
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoRepData())
            {
                var resp = await DisplayAlert("Tipo de repuesto", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreTipoRepuesto(TxtDescripcion.Text.Trim()) != null)
                    {
                        bool R = await vm.AddTipoRepuesto(TxtDescripcion.Text.Trim());
                        if (R)
                        {
                            await DisplayAlert("Tipo de repuesto", "Tipo de repuesto modificado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Tipo de repuesto", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Tipo de repuesto", "El tipo de repuesto no existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Tipo de repuesto", "¿Desea borrar el tipo de repuesto?", "OK", "Cancelar");
            if (result)
            {
                bool R = await vm.DeleteTipoRepuesto(((int)TxtID.TextTransform));
                if (R)
                {
                    await DisplayAlert("Tipo de repuesto", "El tipo de repuesto se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Tipo de repuesto", "Algo salio mal", "OK");
                }
            }
        }

        private void LstTipoRepuesto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (TipoRepuesto)e.SelectedItem;
            TxtID.Text = seleccion.IDTR.ToString();
            TxtDescripcion.Text = seleccion.DescripcionTR;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstTipoRepuesto_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstTipoRepuesto.IsRefreshing = false;
        }
    }
}