using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APPMulticool.Models;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidoManagementPage : ContentPage
    {
        UserViewModel vm;
        public PedidoManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadRepList();
            LoadCliList();
            LoadProdList();
            LoadUsList();
        }

        public async void LoadRepList()
        {
            PckrRep.ItemsSource = await vm.GetRepuesto();
        }

        public async void LoadCliList()
        {
            PckrCli.ItemsSource = await vm.GetCliente();
        }

        public async void LoadProdList()
        {
            PckrProd.ItemsSource = await vm.GetProducto();
        }

        public async void LoadUsList()
        {
            PckrUs.ItemsSource = await vm.GetUsuario();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            Models.Repuesto rep = PckrRep.SelectedItem as Models.Repuesto;
            Cliente cli = PckrCli.SelectedItem as Cliente;
            Models.Producto prod = PckrProd.SelectedItem as Models.Producto;
            Usuario us = PckrUs.SelectedItem as Usuario;
            bool R = await vm.AddPedido(TxtDesc.Text.Trim(), DtPckrFecha.Date,
                rep.IDRep, cli.IDCli, prod.IDProd, us.IDUs);
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

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}