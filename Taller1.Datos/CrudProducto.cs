using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Taller1.Modelos;

namespace Taller1.Datos
{
    public class CrudProducto
    {
        private string rutaArchivo = "productos.json";
        private JsonSerializerSettings configuracion;

        public CrudProducto()
        {
            configuracion = new JsonSerializerSettings();
            configuracion.Formatting = Formatting.Indented;
            configuracion.TypeNameHandling = TypeNameHandling.Auto;
        }

        // READ: Obtener todos los productos
        public List<Producto> ObtenerTodos()
        {
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(json, configuracion);

                if (lista != null)
                {
                    return lista;
                }
            }
            return new List<Producto>();
        }

        public Producto ObtenerPorCodigo(string codigo)
        {
            List<Producto> productos = ObtenerTodos();

            foreach (Producto p in productos)
            {
                if (p.codigo.ToUpper() == codigo.ToUpper())
                {
                    return p;
                }
            }
            return null; 
        }

        public void Crear(Producto nuevoProducto)
        {
            List<Producto> productos = ObtenerTodos();
            productos.Add(nuevoProducto);
            GuardarTodo(productos);
        }

        public void Actualizar(Producto productoModificado)
        {
            List<Producto> productos = ObtenerTodos();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].codigo.ToUpper() == productoModificado.codigo.ToUpper())
                {
                    productos[i] = productoModificado;
                    break;
                }
            }
            GuardarTodo(productos);
        }

        public void Eliminar(string codigo)
        {
            List<Producto> productos = ObtenerTodos();
            Producto productoAEliminar = null;

            foreach (Producto p in productos)
            {
                if (p.codigo.ToUpper() == codigo.ToUpper())
                {
                    productoAEliminar = p;
                    break;
                }
            }

            if (productoAEliminar != null)
            {
                productos.Remove(productoAEliminar);
                GuardarTodo(productos);
            }
        }

        private void GuardarTodo(List<Producto> productos)
        {
            string json = JsonConvert.SerializeObject(productos, configuracion);
            File.WriteAllText(rutaArchivo, json);
        }
    }
}
