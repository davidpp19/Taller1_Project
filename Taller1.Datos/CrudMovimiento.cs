using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller1.Modelos;

namespace Taller1.Datos
{
    public class CrudMovimiento
    {
        private string rutaArchivo = "movimientos.json";
        private JsonSerializerSettings configuracion;

        public CrudMovimiento()
        {
            configuracion = new JsonSerializerSettings();
            configuracion.Formatting = Formatting.Indented;
        }

        public List<Movimiento> ObtenerTodos()
        {
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                List<Movimiento> lista = JsonConvert.DeserializeObject<List<Movimiento>>(json, configuracion);

                if (lista != null)
                {
                    return lista;
                }
            }
            return new List<Movimiento>();
        }

        // CREATE: Agregar un nuevo movimiento al Kárdex
        public void Crear(Movimiento nuevoMovimiento)
        {
            List<Movimiento> movimientos = ObtenerTodos();
            int nuevoId = 1;
            foreach (Movimiento m in movimientos)
            {
                if (m.IdMovimiento >= nuevoId)
                {
                    nuevoId = m.IdMovimiento + 1;
                }
            }
            nuevoMovimiento.IdMovimiento = nuevoId;

            movimientos.Add(nuevoMovimiento);

            string json = JsonConvert.SerializeObject(movimientos, configuracion);
            File.WriteAllText(rutaArchivo, json);
        }
    }
}
