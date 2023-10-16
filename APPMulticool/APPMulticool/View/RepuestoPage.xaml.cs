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
    public partial class RepuestoPage : ContentPage
    {
        UserViewModel vm;
        public RepuestoPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadRepList();
            LoadTipoRepList();
            LoadHerramientaList();
        }

        private async void LoadRepList()
        {
            CvRepuesto.ItemsSource = await vm.GetRepuesto();
        }

        private async void LoadTipoRepList()
        {
            PckrTR.ItemsSource = await vm.GetTipoRepuesto();
        }

        private async void LoadHerramientaList()
        {
            PckrHer.ItemsSource = await vm.GetHerramienta();
        }

        private bool ValidateRepuestoData()
        {
            bool R = false;
            if (TxtDesc.Text != null && !string.IsNullOrEmpty(TxtDesc.Text.Trim()) &&
                PckrTR.SelectedIndex != -1 && PckrHer.SelectedIndex != -1)
            {
                R = true;
            }
            else
            {
                if (TxtDesc.Text == null || string.IsNullOrEmpty(TxtDesc.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar la descripcion del repuesto", "OK");
                    TxtDesc.Focus();
                    return false;
                }
                if (PckrTR.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de seleccionar el tipo de repuesto", "OK");
                    PckrTR.Focus();
                    return false;
                }
                if (PckrHer.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de escoger la herramienta", "OK");
                    PckrHer.Focus();
                    return false;
                }
            }
            return R;
        }

        private void SbRepuesto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbRepuesto.Text;
            var itemsFilter = vm.GetNombreRepuesto(busq).Result;
            CvRepuesto.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateRepuestoData())
            {
                var resp = await DisplayAlert("Repuesto", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreRepuesto(TxtDesc.Text.Trim()) == null)
                    {
                        TipoRepuesto tr = PckrTR.SelectedItem as TipoRepuesto;
                        Herramienta her = PckrHer.SelectedItem as Herramienta;
                        bool R = await vm.AddRepuesto(SwCompleto.IsToggled, TxtDesc.Text.Trim(),
                            tr.IDTR, her.IDHer);
                        if (R)
                        {
                            await DisplayAlert("Repuesto", "Repuesto agregado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Repuesto", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Repuesto", "El repuesto ya existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var rep = (Repuesto)btn.BindingContext;
            int id = rep.IDRep;

            var result = await DisplayAlert("Repuesto", "¿Desea borrar el repuesto?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteRepuesto(id);
                if (R)
                {
                    await DisplayAlert("Respuesto", "El repuesto se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Respuesto", "Algo salio mal", "OK");
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateRepuestoData())
            {
                var resp = await DisplayAlert("Repuesto", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreRepuesto(TxtDesc.Text.Trim()) != null)
                    {
                        TipoRepuesto tr = PckrTR.SelectedItem as TipoRepuesto;
                        Herramienta her = PckrHer.SelectedItem as Herramienta;
                        bool R = await vm.AddRepuesto(SwCompleto.IsToggled, TxtDesc.Text.Trim(),
                            tr.IDTR, her.IDHer);
                        if (R)
                        {
                            await DisplayAlert("Repuesto", "Repuesto modificado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Repuesto", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Repuesto", "El repuesto no existe", "OK");
                    }
                }
            }
        }

        private void CvRepuesto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccion = (Repuesto)e.CurrentSelection.FirstOrDefault();
            TxtDesc.Text = seleccion.DescripcionRep;
            PckrTR.SelectedIndex = seleccion.RepXTR.IDTR;
            PckrHer.SelectedIndex = seleccion.RepXHer.IDHer;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }
    }
}