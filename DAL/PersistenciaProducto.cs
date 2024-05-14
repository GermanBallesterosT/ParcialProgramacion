using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersistenciaProducto
    {
        public void sobreescribirProductosEnArchivo(List<Producto> productos, string nombreArchivo)
        {
            try
            {
                // Obtener la ruta del directorio actual donde se encuentra el ejecutable
                string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
        
                // Combinar el directorio actual con el nombre del archivo para obtener la ruta completa
                string rutaArchivo = Path.Combine(directorioActual, nombreArchivo);
        
                // Escribir en el archivo
                using (StreamWriter writer = new StreamWriter(rutaArchivo))
                {
                    foreach (var producto in productos)
                    {
                        // Escribir cada producto en una línea del archivo
                        writer.WriteLine($"{producto.referencia},{producto.nombre},{producto.stockMinimo},{producto.nombre},{producto.existencias},{producto.precioUnitario},{producto.estado}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: {ex.Message}");
            }
        }
        
        
        //
        public void GuardarProductoEnArchivo(Producto producto, string nombreArchivo)
        {
            try
            {
                // Obtener la ruta del directorio actual donde se encuentra el ejecutable
                string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
        
                // Combinar el directorio actual con el nombre del archivo para obtener la ruta completa
                string rutaArchivo = Path.Combine(directorioActual, nombreArchivo);
        
                // Escribir en el archivo
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    // Escribir el producto en una línea del archivo
                    writer.WriteLine($"{producto.referencia},{producto.nombre},{producto.stockMinimo},{producto.nombre},{producto.existencias},{producto.precioUnitario},{producto.estado}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el cliente en el archivo");
            }
        }
        
        
        public List<Producto> LeerProductosDesdeArchivo(string nombreArchivo)
        {
            List<Producto> productos = new List<Producto>();
        
            try
            {
                // Obtener la ruta completa del archivo
                string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
                string rutaArchivo = Path.Combine(directorioActual, nombreArchivo);
        
                // Verificar si el archivo existe
                if (File.Exists(rutaArchivo))
                {
                    // Leer todas las líneas del archivo
                    string[] lineas = File.ReadAllLines(rutaArchivo);
        
                    // Procesar cada línea para crear objetos producto
                    foreach (string linea in lineas)
                    {
                        // Dividir la línea por las comas para obtener los atributos del producto
                        string[] atributos = linea.Split(',');
        
                        // Crear un nuevo objeto producto y agregarlo a la lista
                        Producto producto = new Producto
                        {
                            referencia = int.Parse(atributos[0]),
                            nombre = atributos[1],
                            stockMinimo = int.Parse(atributos[2]),
                            existencias = int.Parse(atributos[3]),
                            precioUnitario = decimal.Parse(atributos[4]),
                            estado = atributos[5]
                        };
        
                        productos.Add(producto);
                    }
                }
        
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo");
            }
        
            return productos;
        }
    }
}
