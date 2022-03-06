using System;
using System.Collections.Generic;
using System.Text;

namespace Example01
{
    public class CuentaBancaria
    {
        public int Balance { get; set; }
        private readonly ILoggerGeneral _loggerGeneral;

        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {

            Balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Deposito(int monto)
        {
            _loggerGeneral.Message("Esta depositando la cantidad de :" + monto);
            _loggerGeneral.Message("Bien, :)"  );
            _loggerGeneral.Message("OK" );
            _loggerGeneral.PrioridadLogger = 100;
            //Representa un Get
            var prioridad = _loggerGeneral.PrioridadLogger;
            Balance += monto;
            return true;
        }

        public bool Retiro(int monto)
        {
            if (monto <= Balance)
            {
                _loggerGeneral.LogDatabase("Monto de retiro: " + monto.ToString());
                Balance -= monto;
                return  _loggerGeneral.LogBalanceDespuesRetiro(Balance);
            }
            return  _loggerGeneral.LogBalanceDespuesRetiro(Balance - monto);
        }






        public int GetBalance()
        {
            return Balance;
        }
    }
}
