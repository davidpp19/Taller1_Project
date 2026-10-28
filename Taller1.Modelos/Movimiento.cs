using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1.Modelos
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public string codigoProducto { get; set; }
        public string tipoMov { get; set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnidad { get; set; }
        public decimal costoUnidad { get; set; }
        public decimal precioTotal { get; set; }
        public int saldoResultante { get; set; }
        public string cliente { get; set; }
        public string proveedor { get; set; }

        public Movimiento()
        {
        }

        // Método para registrar una COMPRA
        public static Movimiento RegistrarCompra(int id, string codigoProducto, int cantidad, decimal costoUnidad, int saldoResultante, string proveedor)
        {
            Movimiento compra = new Movimiento();
            compra.IdMovimiento = id;
            compra.codigoProducto = codigoProducto;
            compra.tipoMov = "Compra";
            compra.fecha = DateTime.Now;
            compra.cantidad = cantidad;
            compra.costoUnidad = costoUnidad;
            compra.precioUnidad = 0;
            compra.precioTotal = cantidad * costoUnidad;
            compra.saldoResultante = saldoResultante;
            compra.cliente = null;

            if (string.IsNullOrWhiteSpace(proveedor))
            {
                compra.proveedor = "Proveedor Desconocido";
            }
            else
            {
                compra.proveedor = proveedor;
            }

            return compra;
        }

        public static Movimiento RegistrarVenta(int id, string codigoProducto, int cantidad, decimal precioUnidad, int saldoResultante, string cliente)
        {
            Movimiento venta = new Movimiento();
            venta.IdMovimiento = id;
            venta.codigoProducto = codigoProducto;
            venta.tipoMov = "Venta";
            venta.fecha = DateTime.Now;
            venta.cantidad = cantidad;
            venta.costoUnidad = 0;
            venta.precioUnidad = precioUnidad;
            venta.precioTotal = cantidad * precioUnidad;
            venta.saldoResultante = saldoResultante;
            venta.proveedor = null;

            if (string.IsNullOrWhiteSpace(cliente))
            {
                venta.cliente = "Consumidor final";
            }
            else
            {
                venta.cliente = cliente;
            }

            return venta;
        }
    }
}
