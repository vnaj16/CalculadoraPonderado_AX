using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CalculadoraPonderado_AX.Core
{
    interface IEnlace : INotifyPropertyChanged //Se implementa esto para que cada entidad le notifique a la vista sobre sus cambios y los muestre automaticamente   
    {
    }
}
