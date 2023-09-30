using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Repuesto : ContentPage
    {
        UserViewModel vm;
        public Repuesto()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }
        private async void LoadTRList()
        {
            PckrTR.ItemsSource = await vm.GetTipoRepuesto();
        }
        private async void LoadTHList()
        {
            PckrHer.ItemsSource = await vm.GetHerramienta();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
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

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}