using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.Services;
using APPMulticool.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioPage : ContentPage
    {
        UserViewModel vm;
        public UsuarioPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioManagementPage());
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioManagementPage());
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    var result = await this.DisplayAlert("Usuario", "Borrar el usuario?", "Si", "No");
            //    if (result)
            //    {
            //        var db = new APIConnection(db.);
            //    }
            //}
        }
    }
}