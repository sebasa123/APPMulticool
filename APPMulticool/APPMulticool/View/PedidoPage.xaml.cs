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
    public partial class PedidoPage : ContentPage
    {
        UserViewModel vm;
        public PedidoPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadPedidoList();
            LoadRepList();
            LoadCliList();
            LoadProdList();
            LoadUsList();
        }

        private async void LoadPedidoList()
        {
            LstPedido.ItemsSource = await vm.GetPedidos();
        }
        private async void LoadRepList()
        {
            PckrRep.ItemsSource = await vm.GetRepuesto();
        }
        private async void LoadCliList()
        {
            PckrCli.ItemsSource = await vm.GetCliente();
        }
        private async void LoadProdList()
        {
            PckrProd.ItemsSource = await vm.GetProducto();
        }
        private async void LoadUsList()
        {
            PckrUs.ItemsSource = await vm.GetUsuario();
        }

        private void SbPedido_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbPedido.Text;
            var itemsFilter = vm.GetNombrePedido(busq).Result;
            LstPedido.ItemsSource = itemsFilter;
        }

        private bool ValidatePedidoData()
        {
            bool R = false;
            if (TxtDesc.Text != null && !string.IsNullOrEmpty(TxtDesc.Text.Trim()) &&
                DtPckrFecha != null && PckrRep.SelectedIndex != -1 && PckrCli.SelectedIndex != -1
                && PckrProd.SelectedIndex != -1 && PckrUs.SelectedIndex != -1)
            {
                R = true;
            }
            else
            {
                if (TxtDesc.Text == null || string.IsNullOrEmpty(TxtDesc.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar la descripcion del pedido", "OK");
                    TxtDesc.Focus();
                    return false;
                }
                if (DtPckrFecha.Date == null)
                {
                    DisplayAlert("Error de validacion", "Debe de digitar la fecha del pedido", "OK");
                    DtPckrFecha.Focus();
                    return false;
                }
                if (PckrRep.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de escoger un repuesto", "OK");
                    PckrRep.Focus();
                    return false;
                }
                if (PckrCli.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de escoger un cliente", "OK");
                    PckrCli.Focus();
                    return false;
                }
                if (PckrProd.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de escoger un producto", "OK");
                    PckrProd.Focus();
                    return false;
                }
                if (PckrUs.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de escoger un usuario", "OK");
                    PckrUs.Focus();
                    return false;
                }
            }
            return R;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidatePedidoData())
            {
                var resp = await DisplayAlert("Pedido", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombrePedido(TxtDesc.Text.Trim()) == null)
                    {
                        Repuesto rep = PckrRep.SelectedItem as Repuesto;
                        Cliente cli = PckrCli.SelectedItem as Cliente;
                        Producto prod = PckrProd.SelectedItem as Producto;
                        Usuario us = PckrUs.SelectedItem as Usuario;
                        bool R = await vm.AddPedido(TxtDesc.Text.Trim(), DtPckrFecha.Date, rep.IDRep,
                            cli.IDCli, prod.IDProd, us.IDUs);
                        if (R)
                        {
                            await DisplayAlert("Pedido", "Pedido agregado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Pedido", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Pedido", "El pedido ya existe", "OK");
                    }
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidatePedidoData())
            {
                var resp = await DisplayAlert("Pedido", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombrePedido(TxtDesc.Text.Trim()) != null)
                    {
                        Repuesto rep = PckrRep.SelectedItem as Repuesto;
                        Cliente cli = PckrCli.SelectedItem as Cliente;
                        Producto prod = PckrProd.SelectedItem as Producto;
                        Usuario us = PckrUs.SelectedItem as Usuario;
                        bool R = await vm.AddPedido(TxtDesc.Text.Trim(), DtPckrFecha.Date, rep.IDRep,
                            cli.IDCli, prod.IDProd, us.IDUs);
                        if (R)
                        {
                            await DisplayAlert("Pedido", "Pedido modificado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Pedido", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Pedido", "El pedido no existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var ped = (Pedido)btn.BindingContext;
            int id = ped.IDPed;

            var result = await this.DisplayAlert("Pedido", "¿Desea borrar el pedido?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeletePedido(id);
                if (R)
                {
                    await DisplayAlert("Pedido", "El pedido se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Pedido", "Algo salio mal", "OK");
                }
            }
        }

        private void LstPedido_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (Pedido)e.SelectedItem;
            TxtDesc.Text = seleccion.DescripcionPed;
            DtPckrFecha.Date = seleccion.FechaPed;
            PckrRep.SelectedIndex = seleccion.PedXRep.IDRep;
            PckrCli.SelectedIndex = seleccion.PedXCli.IDCli;
            PckrProd.SelectedIndex = seleccion.PedXProd.IDProd;
            PckrUs.SelectedIndex = seleccion.PedXUs.IDUs;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstPedido_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstPedido.IsRefreshing = false;
        }
    }
}