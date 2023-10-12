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
    public partial class TipoRepManagementPage : ContentPage
    {
        UserViewModel vm;
        private string desc;

        public TipoRepManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        public TipoRepManagementPage(string desc)
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            this.desc = desc;
            LoadTipoRepData();
        }

        private void LoadTipoRepData()
        {
            TxtDescripcion.Text = desc;
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

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoRepData())
            {
                var resp = await DisplayAlert("Tipo de repuesto", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    bool R = await vm.AddTipoRepuesto(TxtDescripcion.Text.Trim());
                    if (R)
                    {
                        await DisplayAlert("Tipo de repuesto", "Informacion agregada", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Tipo de repuesto", "Algo salio mal", "OK");
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
            await Navigation.PushAsync(new MainMenuPage());
        }

        private async void SmSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}