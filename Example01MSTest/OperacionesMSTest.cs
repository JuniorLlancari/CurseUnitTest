using Example01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example01MSTest
{
    [TestClass]
    public class OperacionesMSTest
    {
        [TestMethod]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //Arrange (Inicializar)
            Operacion oper = new Operacion();
            int numero1Test = 45;
            int numero2Test = 14;
            //Act
            int resultado=oper.SumarNumeros(numero1Test, numero2Test);
            //Assert
            Assert.AreEqual(59, resultado);
        }
    }
}
