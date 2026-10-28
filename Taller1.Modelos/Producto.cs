using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class Producto
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public double precioBase { get; set; }
        public int stock { get; private set; }

        public Producto()
        {
            codigo = "";
            nombre = "";
            stock = 0;
        }

        public void ModificarStock(int cantidad)
        {
            stock = stock + cantidad;
        }

        public abstract double PrecioVenta { get; }
    }
}
