﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Models;
using APPMulticool.Services;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioPage : ContentPage
    {
        UserViewModel uvm;
        public UsuarioPage()
        {
            InitializeComponent();
            BindingContext = uvm = new UserViewModel();
            LoadUsuarioList();
            LoadTipoList();
        }

        private async void LoadUsuarioList()
        {
            LstUsuario.ItemsSource = await uvm.GetUsuarios();
        }
        private async void LoadTipoList()
        {
            PckrTU.ItemsSource = await uvm.GetTipoUsuario();
            PckrTU.ItemDisplayBinding = new Binding("NombreTU");
        }

        private bool ValidateUsuarioData()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtContra.Text != null && !string.IsNullOrEmpty(TxtContra.Text.Trim()) &&
                PckrTU.SelectedIndex != -1)
            {
                R = true;
            }
            else
            {
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar el nombre de usuario", "OK");
                    TxtNombre.Focus();
                    return false;
                }
                if (TxtContra.Text == null || string.IsNullOrEmpty(TxtContra.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "Debe de digitar la contraseña", "OK");
                    TxtContra.Focus();
                    return false;
                }
                if (PckrTU.SelectedIndex == -1)
                {
                    DisplayAlert("Error de validacion", "Debe de escoger un tipo de usuario", "OK");
                    PckrTU.Focus();
                    return false;
                }
            }
            return R;
        }

        private void SbUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busq = SbUsuario.Text.Trim();
            var itemsFilter = uvm.GetNombreUsuario(busq).Result;
            LstUsuario.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateUsuarioData())
            {
                var resp = await DisplayAlert("Usuario", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    TipoUsuario tu = PckrTU.SelectedItem as TipoUsuario;
                    bool R = await uvm.AddUsuario(TxtNombre.Text.Trim(),
                        TxtContra.Text.Trim(), tu.IDTU);
                    if (R)
                    {
                        await DisplayAlert("Usuario", "Usuario agregado", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Usuario", "Algo salio mal", "OK");
                    }
                    //if (uvm.GetNombreUsuario(TxtNombre.Text.Trim()).Result == null)
                    //{
                    //    TipoUsuario tu = PckrTU.SelectedItem as TipoUsuario;
                    //    bool R = await uvm.AddUsuario(TxtNombre.Text.Trim(),
                    //        TxtContra.Text.Trim(), tu.IDTU);
                    //    if (R)
                    //    {
                    //        await DisplayAlert("Usuario", "Usuario agregado", "OK");
                    //        await Navigation.PopAsync();
                    //    }
                    //    else
                    //    {
                    //        await DisplayAlert("Usuario", "Algo salio mal", "OK");
                    //    }
                    //}
                    //else
                    //{
                    //    await DisplayAlert("Usuario", "El usuario ya existe", "OK");
                    //}
                }
            }
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (ValidateUsuarioData())
            {
                var resp = await DisplayAlert("Usuario", "¿Desea modificar la informacion?", "Si", "No");
                if (resp)
                {
                    UsuarioDTO backup = new UsuarioDTO();
                    backup = GlobalObjects.LocalUs;
                    GlobalObjects.LocalUs.NombreUs = TxtNombre.Text.Trim();
                    GlobalObjects.LocalUs.ContrasUs = TxtContra.Text.Trim();
                    GlobalObjects.LocalUs.FKTipoUsuario = PckrTU.SelectedIndex;
                    GlobalObjects.LocalUs.EstadoUs = true;

                    if (uvm.GetUsuarioID((int)TxtID.TextTransform) != null)
                    {
                        try
                        {
                            bool R = await uvm.UpdateUsuario(GlobalObjects.LocalUs);
                            if (R)
                            {
                                await DisplayAlert("Usuario", "Usuario modificado", "OK");
                                await Navigation.PopAsync();
                            }
                            else
                            {
                                await DisplayAlert("Usuario", "Algo salio mal", "OK");
                                GlobalObjects.LocalUs = backup;
                            }
                        }
                        catch (Exception)
                        {
                            GlobalObjects.LocalUs = backup;
                        }
                    }
                    else
                    {
                        await DisplayAlert("Usuario", "El usuario no existe", "OK");
                    }
                }
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Usuario", "¿Desea borrar el usuario?", "OK", "Cancelar");
            if (result)
            {
                bool R = await uvm.DeleteUsuario((int)TxtID.TextTransform);
                if (R)
                {
                    await DisplayAlert("Usuario", "El usuario se borro correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Usuario", "Algo salio mal", "OK");
                }
            }
        }

        private void LstUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var seleccion = (Usuario)e.SelectedItem;
            TxtID.Text = seleccion.IDUs.ToString();
            TxtNombre.Text = seleccion.NombreUs;
            TxtContra.Text = seleccion.ContrasUs;
            PckrTU.SelectedIndex = seleccion.FKTipoUsuario - 1;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }

        private async void LstUsuario_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.LstUsuario.IsRefreshing = false;
        }
    }
}