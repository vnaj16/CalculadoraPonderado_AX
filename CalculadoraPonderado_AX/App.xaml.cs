using CalculadoraPonderado_AX.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculadoraPonderado_AX
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
