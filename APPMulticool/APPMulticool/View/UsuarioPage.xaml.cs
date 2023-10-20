using System;
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
            CvUsuarios.ItemsSource = await uvm.GetUsuario();
        }

        private async void LoadTipoList()
        {
            PckrTU.ItemsSource = await uvm.GetTipoUsuario();
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
            CvUsuarios.ItemsSource = itemsFilter;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidateUsuarioData())
            {
                var resp = await DisplayAlert("Usuario", "¿Desea agregar la informacion?", "Si", "No");
                if (resp)
                {
                    //if (vm.GetUsuarioData(TxtNombre.Text).Result.IDUs == 0)
                    if (uvm.GetNombreUsuario(TxtNombre.Text.Trim()) == null)
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
                    }
                    else
                    {
                        await DisplayAlert("Usuario", "El usuario ya existe", "OK");
                    }
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
                    if (uvm.GetUsuarioData(TxtNombre.Text).Result.IDUs != 0)
                    {
                        TipoUsuario tu = PckrTU.SelectedItem as TipoUsuario;
                        bool R = await uvm.AddUsuario(TxtNombre.Text.Trim(),
                            TxtContra.Text.Trim(), tu.IDTU);
                        if (R)
                        {
                            await DisplayAlert("Usuario", "Usuario modificado", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Usuario", "Algo salio mal", "OK");
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
            var btn = (Button)sender;
            var usuario = (Usuario)btn.BindingContext;
            int id = usuario.IDUs;

            var result = await DisplayAlert("Usuario", "¿Desea borrar el usuario?", "OK", "Cancelar");
            if (result)
            {
                bool R = await uvm.DeleteUsuario(id);
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

        private void CvUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccion = (Usuario)e.CurrentSelection.FirstOrDefault();
            TxtNombre.Text = seleccion.NombreUs;
            TxtContra.Text = seleccion.ContrasUs;
            PckrTU.SelectedIndex = seleccion.UsXTU.IDTU;
            BtnAgregar.IsEnabled = false;
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;
        }
    }
}