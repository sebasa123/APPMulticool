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
            CheckTipoUsuario(GlobalObjects.LocalUsuario.FKTipoUsuario);
        }

        private void CheckTipoUsuario(int pTipoUs)
        {
            if (pTipoUs == 3)
            {
                Bv1.IsVisible = false;
                LblRep.IsVisible = false;
                TxtID.IsVisible = false;
                TxtDesc.IsVisible = false;
                PckrHer.IsVisible = false;
                PckrTR.IsVisible = false;
                LblCompleto.IsVisible = false;
                SwCompleto.IsVisible = false;
                Bv2.IsVisible = false;
                BtnAgregar.IsVisible = false;
                BtnModificar.IsVisible = false;
                BtnEliminar.IsVisible = false;
            }
        }
        private async void LoadRepList()
        {
            LstRepuesto.ItemsSource = await vm.GetRepuestos();
        }
        private async void LoadTipoRepList()
        {
            PckrTR.ItemsSource = await vm.GetTipoRepuesto();
            PckrTR.ItemDisplayBinding = new Binding("DescripcionTR");
        }
        private async void LoadHerramientaList()
        {
            PckrHer.ItemsSource = await vm.GetHerramienta();
            PckrHer.ItemDisplayBinding = new Binding("NombreHer");
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

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateRepuestoData())
            {
                var resp = await DisplayAlert("Repuesto", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
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
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var idrep = (LstRepuesto.SelectedItem as Repuesto).IDRep;
            var result = await DisplayAlert("Repuesto", "¿Desea borrar el repuesto?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteRepuesto(idrep);
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
                var idrep = (LstRepuesto.SelectedItem as Repuesto).IDRep;
                var resp = await DisplayAlert("Repuesto", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    TipoRepuesto tr = PckrTR.SelectedItem as TipoRepuesto;
                    Herramienta her = PckrHer.SelectedItem as Herramienta;
                    bool R = await vm.UpdateRepuesto(idrep, SwCompleto.IsToggled, TxtDesc.Text.Trim(),
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
            }
        }


        private void LstRepuesto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (Repuesto)e.SelectedItem;
            TxtID.Text = seleccion.IDRep.ToString();
            TxtDesc.Text = seleccion.DescripcionRep;
            PckrTR.SelectedIndex = seleccion.FKTipoRep - 1;
            PckrHer.SelectedIndex = seleccion.FKHerramientas - 1;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstRepuesto_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstRepuesto.IsRefreshing = false;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private async void SbRepuesto_SearchButtonPressed(object sender, EventArgs e)
        {
            string busqueda = SbRepuesto.Text.Trim();
            var filtro = await vm.GetNombreRepuesto(busqueda);
            LstRepuesto.ItemsSource = filtro;
        }
    }
}