using MvvmHelpers;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CalculadoraPonderado_AX.Views;

namespace CalculadoraPonderado_AX.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        Entry EntryCantidadCursos;
        public MainViewModel(Entry EntryCantidadCursos)
        {
            this.EntryCantidadCursos = EntryCantidadCursos;
        }

        public ICommand GoCalculationPageComand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        if ((!String.IsNullOrEmpty(EntryCantidadCursos.Text)) && (Convert.ToInt32(EntryCantidadCursos.Text)>0 && Convert.ToInt32(EntryCantidadCursos.Text) <= 10))//Si no esta vacio
                        {
                            Application.Current.MainPage = new CalculationPage(Convert.ToInt32(EntryCantidadCursos.Text));
                        }
                        else
                        {
                            Application.Current.MainPage.DisplayAlert("Algo está mal", "Asegurate de haber ingresado un número correcto (Max 10)", "Ok");
                        }
                    }
                    catch(Exception ex)
                    {
                        Application.Current.MainPage.DisplayAlert("Algo está mal", "Asegurate de haber ingresado un número", "Ok");
                    }
                });
            }
        }
    }
}
