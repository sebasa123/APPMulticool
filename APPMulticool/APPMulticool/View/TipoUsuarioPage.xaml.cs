﻿using System;
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
    public partial class TipoUsuarioPage : ContentPage
    {
        UserViewModel vm;
        public TipoUsuarioPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadTipoUsuarioList();
        }

        private async void LoadTipoUsuarioList()
        {
            LstTipoUsuario.ItemsSource = await vm.GetTipoUsuarios();
        }

        private void SbTipoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbTipoUsuario.Text;
            var itemsFilter = vm.GetNombreTipoUsuario(busq).Result;
            LstTipoUsuario.ItemsSource = itemsFilter;
        }

        private bool ValidateTipoUsuarioData()
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
                    DisplayAlert("Error de validacion", "Debe de digitar el nombre del tipo de usuario", "OK");
                    TxtNombre.Focus();
                    return false;
                }
            }
            return R;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoUsuarioData())
            {
                var resp = await DisplayAlert("Tipo de usuario", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreTipoUsuario(TxtNombre.Text.Trim()) == null)
                    {
                        bool R = await vm.AddTipoUsuario(TxtNombre.Text.Trim());
                        if (R)
                        {
                            await DisplayAlert("Tipo de usuario", "Tipo de usuario agregado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Tipo de usuario", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Tipo de usuario", "El tipo de usuario ya existe", "OK");
                    }
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateTipoUsuarioData())
            {
                var resp = await DisplayAlert("Tipo de usuario", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    if (vm.GetNombreTipoUsuario(TxtNombre.Text.Trim()) != null)
                    {
                        bool R = await vm.AddTipoUsuario(TxtNombre.Text.Trim());
                        if (R)
                        {
                            await DisplayAlert("Tipo de usuario", "Tipo de usuario modificado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Tipo de usuario", "Algo salio mal", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Tipo de usuario", "El tipo de usuario no existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Tipo de usuario", "¿Desea borrar el tipo de usuario?", "OK", "Cancelar");
            if (result)
            {
                bool R = await vm.DeleteTipoUsuario(((int)TxtID.TextTransform));
                if (R)
                {
                    await DisplayAlert("Tipo de usuario", "El tipo de usuario se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Tipo de usuario", "Algo salio mal", "OK");
                }
            }
        }

        private void LstTipoUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (TipoUsuario)e.SelectedItem;
            TxtID.Text = seleccion.IDTU.ToString();
            TxtNombre.Text = seleccion.NombreTU;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstTipoUsuario_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstTipoUsuario.IsRefreshing = false;
        }
    }
}