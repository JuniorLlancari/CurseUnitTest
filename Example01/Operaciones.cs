using System;
using System.Collections.Generic;

namespace Example01
{
    public class Operaciones
    {
        public List<int> NumerosImpares = new List<int>();

        public int SumarNumeros(int num1, int num2)
        {
            return num1 + num2;
        }
        public bool IsNumeroPar(int numero)
        {
            if (numero % 2 == 0)
            {
                return true;
            }
            return false;
        } 
        public double SumarDecimales(double num1,double num2)
        {
            return num1 + num2;
        }

        public List<int> GetListaNumerosImpares(int intervaloMin, int intervaloMax)
        {
            NumerosImpares.Clear();
            for (int i = intervaloMin; i < intervaloMax; i++)
            {
                if (i % 2 != 0)
                {
                    NumerosImpares.Add(i);
                }
            }
            return NumerosImpares;
        }

    }
}
