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
            CvTipoRepuesto.ItemsSource = await vm.GetUsuario();
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
            CvTipoRepuesto.ItemsSource = itemsFilter;
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
            var btn = (Button)sender;
            var tiporep = (TipoRepuesto)btn.BindingContext;
            int id = tiporep.IDTR;

            var result = await this.DisplayAlert("Tipo de repuesto", "¿Desea borrar el tipo de repuesto?", "OK", "Cancelar");
            if (result)
            {
                bool R = await vm.DeleteTipoRepuesto(id);
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

        private void CvTipoRepuesto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccion = (TipoRepuesto)e.CurrentSelection;
            TxtDescripcion.Text = seleccion.DescripcionTR;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }
    }
}