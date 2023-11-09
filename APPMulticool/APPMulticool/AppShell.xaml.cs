﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPMulticool.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPMulticool
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //CurrentItem = shellViews;
            //shellViews.CurrentItem = shellMainMenu;
            Routing.RegisterRoute(nameof(MainMenuPage), typeof(MainMenuPage));
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}