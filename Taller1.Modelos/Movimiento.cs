using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class Movimiento
    {
        public DateTime fecha { get; set; }
        public string tipo { get; set; }
        public string codigoProducto { get; set; }
        public int cantidad { get; set; }
        public decimal costoUnitario { get; set; }
        public decimal total { get; set; }
        public string entidad { get; set; }
        public int saldoAcumulado { get; set; }

        public Movimiento()
        {
            tipo = "";
            codigoProducto = "";
            entidad = "";
        }
    }
}
