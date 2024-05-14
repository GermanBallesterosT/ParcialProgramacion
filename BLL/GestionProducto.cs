using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionProducto
    {
        public List<Producto> productos = new List<Producto>();
        
        public void cargarProductosDelArchivo()
        {
            PersistenciaProducto persistenciaProducto = new PersistenciaProducto();
            productos = persistenciaProducto.LeerProductosDesdeArchivo("productos.txt");
        }
        
        public bool ListaVacia()
        {
            if (productos.Count == 0) {  return true; }
            return false;
        }
        
        public bool validarProductoProReferencia(string referencia)
        {
            bool existe = false;
        
            if (ListaVacia())
            {
                existe = false ;
            }
            else
            {
                for (int i = 0; i < productos.Count; i++)
                {
                    if (productos[i].referencia.Equals(referencia))
                    {
                        existe = true;
                        break;
                    }
                }
            }
        
            return existe;
        }
        
        
        public void crearNuevoProducto()
        {
            Producto producto = new Producto();
            cargarProductosDelArchivo();
            string referencia, nombre, stockMinimo, existencias, precioUnitario, estado;
        
            while (true)
            {
        
                Console.SetCursorPosition(48, 15); Console.Write("                                                                 ");
                Console.SetCursorPosition(65, 7); Console.Write("                         ");
                Console.SetCursorPosition(53, 5); Console.Write("Registrar Un Producto");
                Console.SetCursorPosition(48, 7); Console.Write("Referencia: ");
                Console.SetCursorPosition(65, 7); referencia = Console.ReadLine();
                if (!string.IsNullOrEmpty(referencia))
                {
                    if (validarEntero(referencia))
                    {
                        if (!validarProductoProReferencia(referencia))
                        {
                            producto.referencia = int.Parse(referencia);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48,15);Console.Write("ya existe un producto con esa referencia");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 15); Console.Write("Solo se admiten caracteres numericos");
                    }
                }
                else
                {
                    Console.SetCursorPosition(48, 15); Console.Write("No se admiten campos vacios");
                }
            }
        
            while (true)
            {
                Console.SetCursorPosition(48, 15); Console.Write("                                                                 ");
                Console.SetCursorPosition(65, 8); Console.Write("                         ");
                Console.SetCursorPosition(48, 8); Console.Write("Nombre: ");
                Console.SetCursorPosition(65, 8); nombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nombre))
                {
                    if (validarStringAceptarSoloLetras(nombre))
                    {
                        producto.nombre = nombre;
                        break;
                    }
                    {
                        Console.SetCursorPosition(48, 15); Console.Write("Solo se admiten caracteres alfabeticos");
                    }
                }
                else
                {
                    Console.SetCursorPosition(48, 15); Console.Write("No se admiten campos vacios");
                }
            }
        
            while (true)
            {
                Console.SetCursorPosition(48, 15); Console.Write("                                                                 ");
                Console.SetCursorPosition(65, 9); Console.Write("                         ");
                Console.SetCursorPosition(48, 9); Console.Write("Stock Minimo: ");
                Console.SetCursorPosition(65, 9); stockMinimo = Console.ReadLine();
        
                if (!string.IsNullOrEmpty(referencia))
                {
                    if (validarEntero(referencia))
                    {
                        producto.stockMinimo = int.Parse(stockMinimo);
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 15); Console.Write("Solo se admiten caracteres numericos");
                    }
                }
                else
                {
                    Console.SetCursorPosition(48, 15); Console.Write("No se admiten campos vacios");
                }
            }
        
            while(true)
            {
        
                Console.SetCursorPosition(48, 15); Console.Write("                                                                 ");
                Console.SetCursorPosition(65, 10); Console.Write("                         ");
                Console.SetCursorPosition(48, 10); Console.Write("Existecias: ");
                Console.SetCursorPosition(65, 10); existencias = Console.ReadLine();
                if (!string.IsNullOrEmpty(existencias))
                {
                    if (validarEntero(existencias))
                    {
                        if (int.Parse(existencias) < producto.stockMinimo)
                        {
                            Console.SetCursorPosition(48, 15); Console.Write("la cantidad de productos no debe ser menr que: " + producto.stockMinimo);
                            
                        }
                        else
                        {
                            producto.existencias = int.Parse(existencias);
                            break;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 15); Console.Write("Solo se admiten caracteres numericos");
                    }
                }
                else
                {
                    Console.SetCursorPosition(48, 15); Console.Write("No se admiten campos vacios");
                }
            }
        }
        
        public bool validarEntero(string dato)
        {
            int enteroProducto;
            try
            {
                enteroProducto = int.Parse(dato);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            return true;
        }
        
        public bool validarDecimal(string dato)
        {
            decimal enteroProducto;
            try
            {
                enteroProducto = decimal.Parse(dato);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            return true;
        }
        
        public bool validarStringAceptarSoloLetras(string dato)
        {
            string patron = "^[a-zA-Z]+$";
        
            return Regex.IsMatch(dato, patron);
        }
    }
}
