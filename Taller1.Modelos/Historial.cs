using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class Historial
    {
        private List<Movimiento> movimientos;

        public Historial()
        {
            movimientos = new List<Movimiento>();
        }
        public List<Movimiento> ObtenerMovimientos()
        {
            return movimientos;
        }
        public void RegistrarMovimiento(Movimiento nuevoMovimiento)
        {
            nuevoMovimiento.fecha = DateTime.Now;
            movimientos.Add(nuevoMovimiento);
        }

        public void CargarDesdeArchivo(List<Movimiento> movimientosGuardados)
        {
            if (movimientosGuardados != null)
            {
                movimientos = movimientosGuardados;
            }
        }
    }
}
