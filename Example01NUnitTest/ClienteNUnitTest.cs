using Example01;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example01NUnitTest
{
    [TestFixture]
    public class ClienteNUnitTest
    {

        private Clientes cliente { get; set; }

        [SetUp]
        public void Setup()
        {
            cliente = new Clientes();
        }


        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            cliente.CrearNombreCompleto("Junior", "Llancari");

            Assert.Multiple(() => {           
                Assert.That(cliente.ClienteNombre, Is.EqualTo("Junior Llancari"));
                Assert.AreEqual(cliente.ClienteNombre, "Junior Llancari");
                Assert.That(cliente.ClienteNombre, Does.Contain("Junior"));//Si contiene
                Assert.That(cliente.ClienteNombre, Does.Contain("Junior").IgnoreCase);//Ignoramos Case
                Assert.That(cliente.ClienteNombre, Does.StartWith("Junior"));     
            });

        }




        [Test]
        public void ClienteNombre_Novolues_ReturnsNull()
        {           
            Assert.IsNull(cliente.ClienteNombre);
        }


        [Test]
        public void DescuentoEvaluacion_DefaultCliente_ReturnDescuentoIntervalo()
        {
            int descuento = cliente.Descuento;
            Assert.That(descuento, Is.InRange(5, 24));
        }

        /// <summary>
        /// 
        /// </summary>

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            cliente.CrearNombreCompleto("Vaxi", "");

            Assert.IsNotNull(cliente.ClienteNombre);
            Assert.IsFalse(string.IsNullOrEmpty(cliente.ClienteNombre));
        }

        [Test]
        public void ClientNombre_InputNombreEnBlanco_ThrowException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(
                () => cliente.CrearNombreCompleto("", "Llancari"));

            Assert.AreEqual("El nombre está en blanco", exceptionDetalle.Message);

            Assert.That(() => cliente.CrearNombreCompleto("", "Llancari"),
                Throws.ArgumentException.With.Message.EqualTo("El nombre está en blanco"));

            Assert.Throws<ArgumentException>( () => cliente.CrearNombreCompleto("", "Llancari"));
            Assert.That(() => cliente.CrearNombreCompleto("", "Llancari"), Throws.ArgumentException);



        }
        [Test]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrderTotal = 150;
            var resultado = cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrderTotal = 600;
            var resultado = cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClientePremium>());
        }
    }
}
