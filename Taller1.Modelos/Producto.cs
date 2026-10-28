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
        public decimal precioBase { get; set; }
        public int stock { get; protected set; }
        public string tipo { get; set; }

        public Producto(string codigo, string nombre, decimal precio, string tipo)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precioBase = precio;
            this.stock = 0; 
            this.tipo = tipo;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Código: {codigo}");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Precio Base: ${precioBase:F2}");
            Console.WriteLine($"Stock: {stock}");
            Console.WriteLine($"Tipo: {tipo}");
        }

        public virtual decimal CalcularPrecioFinal()
        {
            return precioBase;
        }

        public int ObtenerStock()
        {
            return stock;
        }

        // Tus excelentes validaciones intactas
        public void AumentarStock(int cantidad)
        {
            if (cantidad < 0)
            {
                throw new ArgumentException("La cantidad a aumentar no puede ser negativa.");
            }
            stock += cantidad;
        }

        public void DisminuirStock(int cantidad)
        {
            if (cantidad < 0)
            {
                throw new ArgumentException("La cantidad a disminuir no puede ser negativa.");
            }
            if (cantidad > stock)
            {
                throw new InvalidOperationException("No hay suficiente stock para disminuir la cantidad solicitada.");
            }
            stock -= cantidad;
        }
    }
}
