using System;
using System.Collections.Generic;
using System.Text;

namespace Example01
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double GetPrecio(Cliente cliente)
        {
            return cliente.IsPremiun ? Precio * .8 : Precio;
        }
    }
}
