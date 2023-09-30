﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HerramientaManagementPage : ContentPage
    {
        UserViewModel vm;
        public HerramientaManagementPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            int cant = int.Parse(TxtNumero.Text.Trim());
            bool R = await vm.AddHerramienta(TxtNombre.Text.Trim(), cant);
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

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}