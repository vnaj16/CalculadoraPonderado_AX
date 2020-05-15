using CalculadoraPonderado_AX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CalculadoraPonderado_AX.Model
{
    public class CursoModel { }
    public class Curso : IGeneric
    {
        private string nombre;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    RaisePropertyChanged("Nombre");
                }
            }
        }


        private int creditos;

        public int Creditos
        {
            get
            {
                return creditos;
            }
            set
            {
                if (creditos != value)
                {
                    creditos = value;
                    RaisePropertyChanged("Creditos");
                }
            }
        }


        private float promedio;

        public float Promedio
        {
            get
            {
                return promedio;
            }
            set
            {
                if (promedio != value)
                {
                    promedio = value;
                    RaisePropertyChanged("Promedio");
                }
            }
        }


    }
}
