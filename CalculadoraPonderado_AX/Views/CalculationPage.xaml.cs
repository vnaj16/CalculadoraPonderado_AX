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
    public partial class CalculationPage : ContentPage
    {
        private CalculationViewModel CalculationVM;
        public CalculationPage(int n)
        {
            InitializeComponent();
            CalculationVM = new CalculationViewModel(StackLayout_Cursos,n);
            this.BindingContext = CalculationVM;
        }

    }
}