using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class Perecible : Producto
    {
        public DateTime fechaCaducidad { get; set; }
        public bool caduco { get; set; }

        public Perecible(string codigo, string nombre, decimal precio, string tipo, DateTime fechaCaducidad)
            : base(codigo, nombre, precio, tipo)
        {
            this.fechaCaducidad = fechaCaducidad;
            this.caduco = false;
        }

        private void ActualizarEstadoCaducidad()
        {
            if (DateTime.Now.Date > fechaCaducidad.Date)
            {
                caduco = true;
            }
            else
            {
                caduco = false;
            }
        }

        public override decimal CalcularPrecioFinal()
        {
            decimal precioBase = base.CalcularPrecioFinal();
            TimeSpan diferencia = fechaCaducidad.Date - DateTime.Now.Date;

            if (diferencia.TotalDays <= 7 && diferencia.TotalDays >= 0)
            {
                decimal descuento = precioBase * 0.30m;
                return precioBase - descuento;
            }

            return precioBase;
        }

        public override void MostrarInformacion()
        {
            ActualizarEstadoCaducidad();
            base.MostrarInformacion();
            Console.WriteLine($"Fecha de Caducidad: {fechaCaducidad:dd/MM/yyyy}");

            if (caduco)
            {
                Console.WriteLine("Estado: Caducado");
            }
            else
            {
                Console.WriteLine("Estado: Vigente");
            }

            Console.WriteLine($"Precio Final (con descuento si aplica): ${CalcularPrecioFinal():F2}");
        }

    }
}
