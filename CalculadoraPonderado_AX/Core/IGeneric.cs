using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CalculadoraPonderado_AX.Core
{
    public class IGeneric : IEnlace
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string Property_name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property_name));
            }
        }
    }
}
