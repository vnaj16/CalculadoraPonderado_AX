using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CalculadoraPonderado_AX.Views;
using CalculadoraPonderado_AX.Core;
using CalculadoraPonderado_AX.Model;
using System.Collections.ObjectModel;

namespace CalculadoraPonderado_AX.ViewModel
{
    public class CalculationViewModel : IGeneric
    {

        public CalculationViewModel(StackLayout StackLayout_Cursos, int _cantidadCursos)
        {            
            cantidadCursos = _cantidadCursos;
            LoadData();
            LoadFields(StackLayout_Cursos);
            EstadoPromedio = 0;
        }

        #region Atributos
        public int cantidadCursos;

        private ObservableCollection<Curso> cursos;

        public ObservableCollection<Curso> Cursos
        {
            get
            {
                return cursos;
            }

            set
            {
                cursos = value;

                /*if (value != null && value.Count > 0)//SI LA LISTA NO ESTA VACIA
                {
                    currentPersona = value[0];
                }*/

                RaisePropertyChanged("Cursos");
            }
        }

        private float promedioCalculado;

        public float PromedioCalculado
        {
            get
            {
                return promedioCalculado;
            }

            set
            {
                promedioCalculado = value;

                /*if (value != null && value.Count > 0)//SI LA LISTA NO ESTA VACIA
                {
                    currentPersona = value[0];
                }*/

                RaisePropertyChanged("PromedioCalculado");
            }
        }

        private int EstadoPromedio; //0: Calculadora correctamente, 1: Algun promedio mayor a 20 o menor a 0
        #endregion

        private void LoadData()
        {
            ObservableCollection<Curso> cursos_temp = new ObservableCollection<Curso>();

            for(int i=0; i<cantidadCursos;i++)
            {
                cursos_temp.Add(new Curso());
            }

            Cursos = cursos_temp;
        }

        private void LoadFields(StackLayout StackLayout_Cursos)
        {
            for (int i = 0; i < cantidadCursos; i++)
            {
                Label LabelCurso = new Label();
                LabelCurso.Margin = new Thickness(0, 15, 0, 0);
                LabelCurso.FontSize = 15;
                LabelCurso.Text = "Curso " + (i + 1);
                LabelCurso.TextColor = Color.FromHex("#142850");

                /*
                 Binding binding = new Binding("Text");
                binding.Source = txtValue;
                lblValue.SetBinding(TextBlock.TextProperty, binding);
                 */
                Binding bindingNombre = new Binding("Nombre");
                bindingNombre.Source = Cursos[i];
                Entry EntryNombre = new Entry();
                EntryNombre.SetBinding(Entry.TextProperty, bindingNombre);
                EntryNombre.Placeholder = "Nombre";
                EntryNombre.WidthRequest = 150;
                EntryNombre.Completed += EntryNombre_Completed;


                Binding bindingCreditos = new Binding("Creditos");
                bindingCreditos.Source = Cursos[i];
                Entry EntryCreditos = new Entry();
                EntryCreditos.SetBinding(Entry.TextProperty, bindingCreditos);
                EntryCreditos.Placeholder = "Creditos";
                EntryCreditos.Keyboard = Keyboard.Numeric;
                EntryCreditos.MaxLength = 1;
                EntryCreditos.WidthRequest = 50;


                Binding bindingPromedio = new Binding("Promedio");
                bindingPromedio.Source = Cursos[i];
                Entry EntryPromedio = new Entry();
                EntryPromedio.BindingContext = Cursos[i].Promedio;
                EntryPromedio.SetBinding(Entry.TextProperty, bindingPromedio);
                EntryPromedio.Placeholder = "Promedio";
                EntryPromedio.Keyboard = Keyboard.Numeric;
                EntryPromedio.MaxLength = 5;
                EntryPromedio.WidthRequest = 60;
                EntryPromedio.Margin = new Thickness(5, 0, 0, 0);

                //Agrego los elementos al StackLayout del curso
                StackLayout SL_Curso = new StackLayout();
                SL_Curso.Orientation = StackOrientation.Horizontal;
                SL_Curso.VerticalOptions = LayoutOptions.Center;
                SL_Curso.HorizontalOptions = LayoutOptions.Center;

                SL_Curso.Children.Add(LabelCurso);
                SL_Curso.Children.Add(EntryNombre);
                SL_Curso.Children.Add(EntryCreditos);
                SL_Curso.Children.Add(EntryPromedio);



                //Agrego este StackLayout del curso al StackLayout general (StackLayout_Cursos)
                StackLayout_Cursos.Children.Add(SL_Curso);
            }
        }

        private void EntryNombre_Completed(object sender, EventArgs e)
        {
                ((Entry)sender).CursorPosition = 0;
                ((Entry)sender).Unfocus();
        }

        #region Comandos
        public ICommand GoMainPageComand
        {
            get
            {
                return new Command(async () =>
                {
                    bool rpta = await Application.Current.MainPage.DisplayAlert("Espera", "¿Deseas regresar al menú principal?", "Si", "No");

                    if (rpta)
                    {
                        Cursos = null;
                        Application.Current.MainPage = new MainPage();
                    }
                    else
                    {

                    }
                });
            }
        }

        public ICommand CalculateComand
        {
            get
            {
                return new Command(() =>
                {                    
                    GetPromedioPonderado();
                    if (EstadoPromedio == 0)
                    {
                        Application.Current.MainPage.DisplayAlert("Promedio Calculado", $"Tu promedio es {PromedioCalculado}", "Ok");
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Algo está mal", "Asegurate de haber ingresado un promedio dentro de 0 y 20", "Ok");
                    }
                });
            }
        }
        #endregion

        #region Funciones
        private void GetPromedioPonderado()
        {
            float Total_Puntos = 0;
            int Total_Creditos = 0;
            EstadoPromedio = 0;
            foreach (Curso x in cursos)
            {
                Total_Creditos += x.Creditos;
                if (x.Promedio >= 0 && x.Promedio <= 20)
                {
                    Total_Puntos += (x.Creditos) * (x.Promedio);
                }
                else
                {
                    EstadoPromedio = 1;
                    break;
                }
            }

            if(EstadoPromedio==0)
                PromedioCalculado = Total_Puntos / Total_Creditos;
            else
                PromedioCalculado = 0;
        }
        #endregion
    }
}
