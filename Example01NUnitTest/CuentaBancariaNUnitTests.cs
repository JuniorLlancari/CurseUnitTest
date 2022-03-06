using Example01;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example01NUnitTest
{
    [TestFixture]
    public class CuentaBancariaNUnitTests
    {
 
        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        public void Deposito_InputMonto100LoggerFake_ReturnTrue()
        {
            var cuentaBancaria = new CuentaBancaria(new LoggerFake());

            var resultado = cuentaBancaria.Deposito(100);

            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }

         
        [Test]
        public void Deposito_InputMonto100Mocking_ReturnTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();

            var cuentaBancaria = new CuentaBancaria(mocking.Object);
            
            var resultado = cuentaBancaria.Deposito(100);

            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }
        [Test]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";
            loggerGeneralMock.Setup(u => u.MessageReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());
            var resultado = loggerGeneralMock.Object.MessageReturnString("Hola Mundo");
            Assert.That(resultado, Is.EqualTo(textoPrueba));
        }
        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingOutPut_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";
            loggerGeneralMock.Setup(u => u.MessageWithOutParameterReturnBoolean(It.IsAny<string>(), out textoPrueba)).Returns(true);
            string parametroOut = "";
            var resultado = loggerGeneralMock.Object.MessageWithOutParameterReturnBoolean("Junior", out parametroOut);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingRef_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            Cliente cliente = new Cliente();
            Cliente clienteNoUsado = new Cliente();
            loggerGeneralMock.Setup(t => t.MessageWithReferenceParameterReturnBoolean(ref cliente)).Returns(true);

            Assert.IsTrue(loggerGeneralMock.Object.MessageWithReferenceParameterReturnBoolean(ref cliente));
            Assert.IsFalse(loggerGeneralMock.Object.MessageWithReferenceParameterReturnBoolean(ref clienteNoUsado));


        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.SetupAllProperties();

            loggerGeneralMock.Setup(t => t.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(t => t.PrioridadLogger).Returns(10);

            loggerGeneralMock.Object.PrioridadLogger = 100;

            Assert.That(loggerGeneralMock.Object.TipoLogger,Is.EqualTo("warning"));
            Assert.That(loggerGeneralMock.Object.PrioridadLogger, Is.EqualTo(100));

            //Callbacks
            string textTemporal = "Junior";
            loggerGeneralMock.Setup(u => u.LogDatabase(It.IsAny<string>()))
                .Returns(true).Callback((string parametro) => textTemporal += parametro);
            loggerGeneralMock.Object.LogDatabase("Llancari");

            Assert.That(textTemporal, Is.EqualTo("JuniorLlancari"));


        }
        [Test]
        public void CuentaBancariaLogger_VerifyEjemplo()
        {
            var loggerGeneralMock=new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerGeneralMock.Object);
            cuentaBancaria.Deposito(100);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(100));
            //Verifica cuantas veces el mock esta llamando a metodo
            loggerGeneralMock.Verify(u=>u.Message(It.IsAny<string>()),Times.Exactly(3));

            //Verifica cuantas veces el mock esta llamando a metodo
            loggerGeneralMock.Verify(u => u.Message("Bien, :)"),Times.AtLeastOnce);
            loggerGeneralMock.VerifySet(u=>u.PrioridadLogger=100,Times.Once);
            loggerGeneralMock.VerifyGet(u => u.PrioridadLogger, Times.Once);


        }

    }
}
