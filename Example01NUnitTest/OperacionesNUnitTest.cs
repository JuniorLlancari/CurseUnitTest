using Example01;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example01NUnitTest
{
    [TestFixture]
    public class OperacionesNUnitTest
    {
        [Test]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //Arrange (Inicializar)
            Operaciones oper = new Operaciones();
            int numero1Test = 45;
            int numero2Test = 14;
            //Act
            int resultado = oper.SumarNumeros(numero1Test, numero2Test);
            //Assert
            Assert.AreEqual(59, resultado);
        }
        [Test]
        public void IsNumeroPar_InputNumeroImpar_ReturnFalse()
        {

            Operaciones oper = new Operaciones();
            int numeroTest = 5;
            //Act
            bool resultado = oper.IsNumeroPar(numeroTest);
            //Assert
            Assert.IsFalse(resultado);
            Assert.That(resultado, Is.EqualTo(false));

        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool IsNumeroPar_InputNumeroImpar_ReturnFalseV2(int numeroPar)
        {
            Operaciones oper = new Operaciones();
            return oper.IsNumeroPar(numeroPar);
        }


        [Test]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(-4)]
        public void IsNumeroPar_InputNumeroPar_ReturnTrue(int numeroPar)
        {
            //Arrange (Inicializar)
            Operaciones oper = new Operaciones();
            //Act
            bool resultado = oper.IsNumeroPar(numeroPar);
            //Assert
            Assert.IsTrue(resultado);
            Assert.That(resultado, Is.EqualTo(true));

        }


        [Test]
        [TestCase(2.2, 1.2)]
        [TestCase(2.23, 1.21)]
        public void SumarDecimales_InputDosNumeros_GetValorCorrecto(double num1, double num2)
        {
            Operaciones oper = new Operaciones();
            double resultado = oper.SumarDecimales(num1, num2);
            //Añadimos un intervalo de +-0.1
            Assert.AreEqual(3.4, resultado, 0.1);
        }

        [Test]
        public void GetListaNumerosImpares_InputMinimoMaximoIntervalos_ReturnsListaImpares()
        {
            //Arrange
            Operaciones op = new Operaciones();
            List<int> numerosImparesEsperados = new List<int> { 5, 7, 9 };
            //Ac
            List<int> resultados = op.GetListaNumerosImpares(5, 10);

            Assert.That(resultados, Is.EquivalentTo(numerosImparesEsperados));
            Assert.AreEqual(resultados, numerosImparesEsperados);
            Assert.That(resultados, Does.Contain(5));
            Assert.Contains(5, resultados);
            Assert.That(resultados, Is.Not.Empty);
            Assert.That(resultados.Count, Is.EqualTo(3));
            Assert.That(resultados, Has.No.Member(100));
            Assert.That(resultados, Is.Ordered.Ascending);
            Assert.That(resultados, Is.Unique); //No haya repetidos


        }





    }
}
