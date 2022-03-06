using Example01;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Example01XUnitTest
{
     public class CuentaBancariaXUnitTests
    {
        private CuentaBancaria cuenta;
        public CuentaBancariaXUnitTests()
        {

        }
 

        [Fact]
        public void Deposito_InputMonto100LoggerFake_ReturnTrue()
        {
            var cuentaBancaria = new CuentaBancaria(new LoggerFake());

            var resultado = cuentaBancaria.Deposito(100);

            Assert.True(resultado);
            Assert.Equal(100, cuentaBancaria.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            loggerMock.Setup(t => t.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(t => t.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);
            var resultado = cuentaBancaria.Retiro(retiro);
            Assert.True(resultado);
        }


        [Theory]
        [InlineData(200, 300)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            //loggerMock.Setup(t => t.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
            loggerMock.Setup(t => t.LogBalanceDespuesRetiro(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);
            var resultado = cuentaBancaria.Retiro(retiro);
            Assert.False(resultado);
        }


        [Fact]
        public void Deposito_InputMonto100Mocking_ReturnTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();

            var cuentaBancaria = new CuentaBancaria(mocking.Object);

            var resultado = cuentaBancaria.Deposito(100);

            Assert.True(resultado);
            Assert.Equal(100,cuentaBancaria.GetBalance());
        }
        [Fact]

        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";
            loggerGeneralMock.Setup(u => u.MessageReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());
            var resultado = loggerGeneralMock.Object.MessageReturnString("Hola Mundo");
            Assert.Equal(textoPrueba,resultado);
        }
        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingOutPut_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";
            loggerGeneralMock.Setup(u => u.MessageWithOutParameterReturnBoolean(It.IsAny<string>(), out textoPrueba)).Returns(true);
            string parametroOut = "";
            var resultado = loggerGeneralMock.Object.MessageWithOutParameterReturnBoolean("Junior", out parametroOut);
            Assert.True(resultado);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingRef_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            Cliente cliente = new Cliente();
            Cliente clienteNoUsado = new Cliente();
            loggerGeneralMock.Setup(t => t.MessageWithReferenceParameterReturnBoolean(ref cliente)).Returns(true);

            Assert.True(loggerGeneralMock.Object.MessageWithReferenceParameterReturnBoolean(ref cliente));
            Assert.False(loggerGeneralMock.Object.MessageWithReferenceParameterReturnBoolean(ref clienteNoUsado));


        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.SetupAllProperties();

            loggerGeneralMock.Setup(t => t.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(t => t.PrioridadLogger).Returns(10);

            loggerGeneralMock.Object.PrioridadLogger = 100;

            Assert.Equal("warning",loggerGeneralMock.Object.TipoLogger );
            Assert.Equal(100,loggerGeneralMock.Object.PrioridadLogger);

            //Callbacks
            string textTemporal = "Junior";
            loggerGeneralMock.Setup(u => u.LogDatabase(It.IsAny<string>()))
                .Returns(true).Callback((string parametro) => textTemporal += parametro);
            loggerGeneralMock.Object.LogDatabase("Llancari");

            Assert.Equal("JuniorLlancari",textTemporal);


        }
        [Fact]
        public void CuentaBancariaLogger_VerifyEjemplo()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerGeneralMock.Object);
            cuentaBancaria.Deposito(100);
            Assert.Equal(100,cuentaBancaria.GetBalance());
            //Verifica cuantas veces el mock esta llamando a metodo
            loggerGeneralMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(3));

            //Verifica cuantas veces el mock esta llamando a metodo
            loggerGeneralMock.Verify(u => u.Message("Bien, :)"), Times.AtLeastOnce);
            loggerGeneralMock.VerifySet(u => u.PrioridadLogger = 100, Times.Once);
            loggerGeneralMock.VerifyGet(u => u.PrioridadLogger, Times.Once);


        }

    }
}
