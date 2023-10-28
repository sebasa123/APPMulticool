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
    public partial class HerramientaPage : ContentPage
    {
        UserViewModel vm;
        public HerramientaPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadHerramientaList();
        }

        private async void LoadHerramientaList()
        {
            LstHerramienta.ItemsSource = await vm.GetHerramientas();
        }

        private void SbHeramienta_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbHeramienta.Text;
            var itemsFilter = vm.GetNombreHerramienta(busq).Result;
            LstHerramienta.ItemsSource = itemsFilter;
        }

        private bool ValidateHerramientaData()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtNumero.Text != null && !string.IsNullOrEmpty(TxtNumero.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el nombre de la herramienta", "OK");
                    TxtNombre.Focus();
                    return false;
                }
                if (TxtNumero.Text == null || string.IsNullOrEmpty(TxtNumero.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar la cantidad", "OK");
                    TxtNumero.Focus();
                    return false;
                }
            }
            return R;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateHerramientaData())
            {
                var resp = await DisplayAlert("Herramienta", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreHerramienta(TxtNombre.Text.Trim()) == null)
                    {
                        bool R = await vm.AddHerramienta(TxtNombre.Text.Trim(), ((int)TxtNumero.TextTransform));
                        if (R)
                        {
                            await DisplayAlert("Herramienta", "Herramienta agregada", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Herramienta", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Herramienta", "La herramienta ya existe", "OK");
                    }
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateHerramientaData())
            {
                var resp = await DisplayAlert("Herramienta", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreHerramienta(TxtNombre.Text.Trim()) != null)
                    {
                        bool R = await vm.AddHerramienta(TxtNombre.Text.Trim(), ((int)TxtNumero.TextTransform));
                        if (R)
                        {
                            await DisplayAlert("Herramienta", "Herramienta modificada", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Herramienta", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Herramienta", "La herramienta no existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Herramienta", "¿Desea borrar la herramienta?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteHerramienta(((int)TxtID.TextTransform));
                if (R)
                {
                    await DisplayAlert("Herramienta", "La herramienta se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Herramienta", "Algo salio mal", "OK");
                }
            }
        }

        private void LstHerramienta_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (Herramienta)e.SelectedItem;
            TxtID.Text = seleccion.IDHer.ToString();
            TxtNombre.Text = seleccion.NombreHer;
            TxtNumero.Text = seleccion.NumeroHer.ToString();
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstHerramienta_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstHerramienta.IsRefreshing = false;
        }
    }
}