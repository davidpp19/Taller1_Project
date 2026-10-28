using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class NoPerecible : Producto
    {
        public int MesesGarantia { get; set; }

        public override double PrecioVenta
        {
            get
            {
                return precioBase * 1.15;
            }
        }
    }
}
