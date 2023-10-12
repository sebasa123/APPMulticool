using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoProdManagementPage : ContentPage
    {
        UserViewModel vm;
        private string nom;

        public TipoProdManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        public TipoProdManagementPage(string nom)
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            this.nom = nom;
            LoadTipoProdData();
        }

        private void LoadTipoProdData()
        {
            TxtNombre.Text = nom;
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

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoProdData())
            {
                var resp = await DisplayAlert("Tipo de producto", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    bool R = await vm.AddTipoProducto(TxtNombre.Text.Trim());
                    if (R)
                    {
                        await DisplayAlert("Tipo de producto", "Informacion agregada", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Tipo de producto", "Algo salio mal", "OK");
                    }
                }
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void BtnSideMenu_Clicked(object sender, EventArgs e)
        {
            SideMenu.State = SideMenuState.LeftMenuShown;
        }

        private async void SmInicio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void SmSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}