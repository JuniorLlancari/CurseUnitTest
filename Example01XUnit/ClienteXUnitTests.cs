using Example01;
 using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Example01XUnit
{
    public class ClienteXUnitTests
    {

        private Cliente cliente { get; set; }

        public ClienteXUnitTests()
        {
            cliente = new Cliente();
        }


        [Fact]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            cliente.CrearNombreCompleto("Junior", "Llancari");
         
            Assert.Equal("Junior Llancari", cliente.ClienteNombre);
            Assert.Contains("Junior",cliente.ClienteNombre);//Si contiene
            Assert.StartsWith("Junior",cliente.ClienteNombre);
            Assert.EndsWith("Llancari", cliente.ClienteNombre);

             

        }




        [Fact]
        public void ClienteNombre_Novolues_ReturnsNull()
        {
            Assert.Null(cliente.ClienteNombre);
        }


        [Fact]
        public void DescuentoEvaluacion_DefaultCliente_ReturnDescuentoIntervalo()
        {
            int descuento = cliente.Descuento;
            Assert.InRange(descuento,5, 24);
        }

  
        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            cliente.CrearNombreCompleto("Vaxi", "");

            Assert.NotNull(cliente.ClienteNombre);
            Assert.False(string.IsNullOrEmpty(cliente.ClienteNombre));
        }

        [Fact]
        public void ClientNombre_InputNombreEnBlanco_ThrowException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(
                () => cliente.CrearNombreCompleto("", "Llancari"));

            Assert.Equal("El nombre está en blanco", exceptionDetalle.Message);

        
            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Llancari"));
 


        }
        [Fact]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrderTotal = 150;
            var resultado = cliente.GetClienteDetalle();
            Assert.IsType<ClienteBasico>(resultado);
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrderTotal = 600;
            var resultado = cliente.GetClienteDetalle();
            Assert.IsType<ClientePremium>(resultado);
        }
    }
}
