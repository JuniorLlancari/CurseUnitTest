//using Example01;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Example01NUnitTest
//{
//    [TestFixture]
//    public class ProductoXUnitTests
//    {
//        [Test]
//        public void GetPrecio_PremiunCliente_ReturnPrecio80()
//        {
//            Producto producto = new Producto();
//            producto.Precio = 50;

//            //var cliente = new Mock<ICliente>();
//            //cliente.Setup(s=>s.IsPremiun).Returns(true);
//            //var resultado = producto.GetPrecio(cliente.object);

//            var resultado = producto.GetPrecio(new Cliente { IsPremiun = true });
//            Assert.That(resultado, Is.EqualTo(40));

//        }

//        [Test]
//        [TestCase(200, 100)]
//        [TestCase(200, 150)]
//        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
//        {
//            var loggerMock = new Mock<ILoggerGeneral>();
//            loggerMock.Setup(t => t.LogDatabase(It.IsAny<string>())).Returns(true);
//            loggerMock.Setup(t => t.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);

//            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
//            cuentaBancaria.Deposito(balance);
//            var resultado = cuentaBancaria.Retiro(retiro);
//            Assert.IsTrue(resultado);
//        }


//        [Test]
//        [TestCase(200, 300)]
//        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
//        {
//            var loggerMock = new Mock<ILoggerGeneral>();
//            //loggerMock.Setup(t => t.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
//            loggerMock.Setup(t => t.LogBalanceDespuesRetiro(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

//            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
//            cuentaBancaria.Deposito(balance);
//            var resultado = cuentaBancaria.Retiro(retiro);
//            Assert.IsFalse(resultado);
//        }

 

//    }
//}
