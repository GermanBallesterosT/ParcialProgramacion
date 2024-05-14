using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Producto
    {
        public int referencia { get; set; }
        public string nombre { get; set; }
        public int existencias { get; set; }
        public int stockMinimo { get; set; }
        public decimal precioUnitario { get; set; }
        public bool estado { get; set; }
    }
}
