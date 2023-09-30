using System;
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
    public partial class UsuarioPage : ContentPage
    {
        UserViewModel vm;
        public UsuarioPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnModificar_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}