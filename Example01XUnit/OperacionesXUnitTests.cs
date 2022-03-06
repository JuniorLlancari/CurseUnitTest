using Example01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Example01XUnit
{
    public class OperacionesXUnitTests
    {
        [Fact]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //Arrange (Inicializar)
            Operacion oper = new Operacion();
            int numero1Test = 45;
            int numero2Test = 14;
            //Act
            int resultado = oper.SumarNumeros(numero1Test, numero2Test);
            //Assert
            Assert.Equal(59, resultado);
        }
        [Fact]
        public void IsNumeroPar_InputNumeroImpar_ReturnFalse()
        {

            Operacion oper = new Operacion();
            int numeroTest = 5;
            //Act
            bool resultado = oper.IsNumeroPar(numeroTest);
            //Assert
            Assert.False(resultado);
            //Assert.Equal(false, resultado);


        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        public void IsNumeroPar_InputNumeroImpar_ReturnFalseV2(int numeroPar, bool expectResult)
        {
            Operacion oper = new Operacion();
            var resultado = oper.IsNumeroPar(numeroPar);
            Assert.Equal(expectResult, resultado);
        }


        [Theory]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(-4)]
        public void IsNumeroPar_InputNumeroPar_ReturnTrue(int numeroPar)
        {
            //Arrange (Inicializar)
            Operacion oper = new Operacion();
            //Act
            bool resultado = oper.IsNumeroPar(numeroPar);
            //Assert
            Assert.True(resultado);

        }


        [Theory]
        [InlineData(2.2, 1.2)]
        [InlineData(2.23, 1.21)]
        public void SumarDecimales_InputDosNumeros_GetValorCorrecto(double num1, double num2)
        {
            Operacion oper = new Operacion();
            double resultado = oper.SumarDecimales(num1, num2);
            //Añadimos un intervalo de +-0.1
            Assert.Equal(3.4, resultado, 0);
        }

        [Fact]
        public void GetListaNumerosImpares_InputMinimoMaximoIntervalos_ReturnsListaImpares()
        {
            //Arrange
            Operacion op = new Operacion();
            List<int> numerosImparesEsperados = new List<int> { 5, 7, 9 };
            //Ac
            List<int> resultados = op.GetListaNumerosImpares(5, 10);

            Assert.Equal(numerosImparesEsperados, resultados);
            Assert.Contains(5, resultados);
            Assert.NotEmpty(resultados);
            Assert.Equal(3, resultados.Count);
            Assert.DoesNotContain(100, resultados);
            Assert.Equal(resultados.OrderBy(u => u), resultados);


        }





    }
}
