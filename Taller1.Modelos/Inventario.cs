using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public Producto BuscarPorCodigo(string codigo)
        {
            foreach (Producto p in productos)
            {
                if (p.codigo.ToUpper() == codigo.ToUpper())
                {
                    return p;
                }
            }
            return null; 
        }

        public void CargarDesdeArchivo(List<Producto> productosGuardados)
        {
            if (productosGuardados != null)
            {
                productos = productosGuardados;
            }
        }
    }
}
