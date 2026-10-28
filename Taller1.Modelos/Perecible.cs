using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class Perecible : Producto
    {
        public DateTime FechaCaducidad { get; set; }

        public override double PrecioVenta
        {
            get
            {
                TimeSpan diferencia = FechaCaducidad.Date - DateTime.Now.Date;
                int diasRestantes = diferencia.Days;

                if (diasRestantes <= 7 && diasRestantes >= 0)
                {
                    return precioBase * 0.70; 
                }

                return precioBase;
            }
        }

    }
}
