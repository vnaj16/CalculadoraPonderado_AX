using CalculadoraPonderado_AX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculadoraPonderado_AX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainViewModel MainVM;
        public MainPage()
        {
            InitializeComponent();
            MainVM = new MainViewModel(EntryCantidadCursos);
            this.BindingContext = MainVM;
        }
    }
}