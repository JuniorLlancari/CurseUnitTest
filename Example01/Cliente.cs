using System;
using System.Collections.Generic;
using System.Text;

namespace Example01
{
    public class Cliente
    {

        public int OrderTotal { get; set; }
        public string ClienteNombre { get; set; }
        public int Descuento = 10;
        public bool IsPremiun { get; set; }


        public Cliente()
        {
            IsPremiun = false;
        }


        public string CrearNombreCompleto(string nombre, string apellido)
        {

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre está en blanco");
            }
            Descuento = 30;
 
            return ClienteNombre = string.Format("{0} {1}",nombre,apellido);
        }
        public TipoCliente GetClienteDetalle()
        {
            if (OrderTotal < 500)
            {
                return new ClienteBasico();
            }
            return new ClientePremium();
        }

 
    }

    public class TipoCliente { }

    public class ClienteBasico : TipoCliente { }

    public class ClientePremium : TipoCliente { }
}
