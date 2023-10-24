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
    public partial class ClientePage : ContentPage
    {
        UserViewModel vm;
        public ClientePage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadClienteList();
        }

        private async void LoadClienteList()
        {
            LstCliente.ItemsSource = await vm.GetClientes();
        }

        private void SbCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbCliente.Text;
            var itemsFilter = vm.GetNombreCliente(busq).Result;
            LstCliente.ItemsSource = itemsFilter;
        }

        private bool ValidateClienteData()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtApellido.Text != null && !string.IsNullOrEmpty(TxtApellido.Text.Trim()) &&
                TxtCedula.Text != null && !string.IsNullOrEmpty(TxtCedula.Text.Trim()) &&
                TxtDireccion.Text != null && !string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el nombre del cliente", "OK");
                    TxtNombre.Focus();
                    return false;
                }
                if (TxtApellido.Text == null || string.IsNullOrEmpty(TxtApellido.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el apellido del usuario", "OK");
                    TxtApellido.Focus();
                    return false;
                }
                if (TxtCedula.Text == null || string.IsNullOrEmpty(TxtCedula.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el numero de cedula", "OK");
                    TxtCedula.Focus();
                    return false;
                }
                if (TxtDireccion.Text == null || string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar la direccion", "OK");
                    TxtDireccion.Focus();
                    return false;
                }
            }
            return R;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateClienteData())
            {
                var resp = await DisplayAlert("Cliente", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreCliente(TxtNombre.Text.Trim()) == null)
                    {
                        bool R = await vm.AddCliente(TxtNombre.Text.Trim(),
                            TxtApellido.Text.Trim(), ((int)TxtCedula.TextTransform),
                            TxtDireccion.Text.Trim());
                        if (R)
                        {
                            await DisplayAlert("Cliente", "Cliente agregado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Cliente", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Cliente", "El cliente ya existe", "OK");
                    }
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateClienteData())
            {
                var resp = await DisplayAlert("Cliente", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreCliente(TxtNombre.Text.Trim()) != null)
                    {
                        bool R = await vm.AddCliente(TxtNombre.Text.Trim(),
                            TxtApellido.Text.Trim(), ((int)TxtCedula.TextTransform),
                            TxtDireccion.Text.Trim());
                        if (R)
                        {
                            await DisplayAlert("Cliente", "Cliente modificado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Cliente", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Cliente", "El cliente no existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var cli = (Cliente)btn.BindingContext;
            int id = cli.IDCli;

            var result = await this.DisplayAlert("Cliente", "¿Desea borrar el cliente?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteCliente(id);
                if (R)
                {
                    await DisplayAlert("Cliente", "El cliente se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Cliente", "Algo salio mal", "OK");
                }
            }
        }

        private void LstCliente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (Cliente)e.SelectedItem;
            TxtNombre.Text = seleccion.NombreCli;
            TxtApellido.Text = seleccion.ApellidoCli;
            TxtCedula.Text = seleccion.CedulaCli.ToString();
            TxtDireccion.Text = seleccion.DireccionCli;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstCliente_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstCliente.IsRefreshing = false;
        }
    }
}