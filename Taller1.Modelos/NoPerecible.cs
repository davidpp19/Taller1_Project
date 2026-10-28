using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class NoPerecible : Producto
    {
        public int mesesGarantia { get; set; }

        public NoPerecible(string codigo, string nombre, decimal precio, string tipo, int MesesGarantia)
            : base(codigo, nombre, precio, tipo)
        {
            this.mesesGarantia = MesesGarantia;
        }

        public override decimal CalcularPrecioFinal()
        {
            decimal precioBase = base.CalcularPrecioFinal();
            decimal iva = precioBase * 0.15m;
            decimal precioFinal = precioBase + iva;
            return precioFinal;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Garantía: {mesesGarantia} meses");
            Console.WriteLine($"Precio Final (con 15% IVA): ${CalcularPrecioFinal():F2}");
        }
    }
}
