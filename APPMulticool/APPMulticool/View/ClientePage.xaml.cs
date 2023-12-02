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
            CheckTipoUsuario(GlobalObjects.LocalUsuario.FKTipoUsuario);
        }

        private void CheckTipoUsuario(int pTipoUs)
        {
            if (pTipoUs == 3)
            {
                Bv1.IsVisible = false;
                LblCli.IsVisible = false;
                TxtID.IsVisible = false;
                TxtNombre.IsVisible = false;
                TxtApellido.IsVisible = false;
                TxtCedula.IsVisible = false;
                TxtDireccion.IsVisible = false;
                Bv2.IsVisible = false;
                BtnAgregar.IsVisible = false;
                BtnModificar.IsVisible = false;
                BtnEliminar.IsVisible = false;
            }
        }

        private async void LoadClienteList()
        {
            LstCliente.ItemsSource = await vm.GetClientes();
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
                    int ced = int.Parse(TxtCedula.Text);
                    bool R = await vm.AddCliente(TxtNombre.Text.Trim(),
                            TxtApellido.Text.Trim(), ced, TxtDireccion.Text.Trim());
                    if (R)
                    {
                        await DisplayAlert("Cliente", "Cliente agregado", "OK");
                        LstCliente.ItemsSource = await vm.GetClientes();
                        TxtID.Text = null;
                        TxtNombre.Text = null;
                        TxtApellido.Text = null;
                        TxtCedula.Text = null;
                        TxtDireccion.Text = null;
                        //await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Cliente", "Algo salio mal", "OK");
                    }
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateClienteData())
            {
                var idcli = (LstCliente.SelectedItem as Cliente).IDCli;
                int ced = int.Parse(TxtCedula.Text);
                var resp = await DisplayAlert("Cliente", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    bool R = await vm.UpdateCliente(idcli, TxtNombre.Text.Trim(),
                            TxtApellido.Text.Trim(), ced, TxtDireccion.Text.Trim());
                    if (R)
                    {
                        await DisplayAlert("Cliente", "Cliente modificado", "OK");
                        LstCliente.ItemsSource = await vm.GetClientes();
                        TxtID.Text = null;
                        TxtNombre.Text = null;
                        TxtApellido.Text = null;
                        TxtCedula.Text = null;
                        TxtDireccion.Text = null;
                        BtnAgregar.IsEnabled = true;
                        BtnModificar.IsEnabled = false;
                        BtnEliminar.IsEnabled = false;
                        //await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Cliente", "Algo salio mal", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var idcli = (LstCliente.SelectedItem as Cliente).IDCli;
            var result = await this.DisplayAlert("Cliente", "¿Desea borrar el cliente?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteCliente(idcli);
                if (R)
                {
                    await DisplayAlert("Cliente", "El cliente se borro correctamente", "OK");
                    LstCliente.ItemsSource = await vm.GetClientes();
                    TxtID.Text = null;
                    TxtNombre.Text = null;
                    TxtApellido.Text = null;
                    TxtCedula.Text = null;
                    TxtDireccion.Text = null;
                    BtnAgregar.IsEnabled = true;
                    BtnModificar.IsEnabled = false;
                    BtnEliminar.IsEnabled = false;
                    //await Navigation.PopAsync();
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
            TxtID.Text = seleccion.IDCli.ToString();
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

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private async void SbCliente_SearchButtonPressed(object sender, EventArgs e)
        {
            string busqueda = SbCliente.Text.Trim();
            var filtro = await vm.GetNombreCliente(busqueda);
            LstCliente.ItemsSource = filtro;
        }
    }
}