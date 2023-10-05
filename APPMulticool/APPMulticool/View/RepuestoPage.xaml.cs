﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;
using APPMulticool.ViewModels;
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
        }

        private void SbRepuesto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbRepuesto.Text;
            var itemsFilter = vm.GetNombreRepuesto(busq).Result;
            CvRepuesto.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RepManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Repuesto", "¿Desea borrar el repuesto?", "OK", "Cancelar");
            if (result == true)
            {
                bool R = await vm.DeleteRepuesto((RepuestoDTO)CvRepuesto.SelectedItem);
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RepManagementPage());
        }
    }
}