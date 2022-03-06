using System;
using System.Collections.Generic;
using System.Text;

namespace Example01
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);
        string MessageReturnString(string message);
        bool MessageWithOutParameterReturnBoolean(string str,out string outputStr);
        bool MessageWithReferenceParameterReturnBoolean(ref Cliente cliente);


        int PrioridadLogger { get; set; }
        string TipoLogger { get; set; }
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {
                Console.WriteLine("Exito");
                return true;
            }
            Console.WriteLine("Error");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }

        public bool MessageWithOutParameterReturnBoolean(string str, out string outputStr)
        {
            outputStr = "Hola" + str;
            return true;
        }

        public bool MessageWithReferenceParameterReturnBoolean(ref Cliente cliente)
        {
            return true;
        }
    }

    public class LoggerFake: ILoggerGeneral
    {
        public int PrioridadLogger { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TipoLogger { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            throw new NotImplementedException();
        }

        public bool LogDatabase(string message)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {
         }

        public string MessageReturnString(string message)
        {
            throw new NotImplementedException();
        }

        public bool MessageWithOutParameterReturnBoolean(string str, out string outputStr)
        {
            throw new NotImplementedException();
        }

        public bool MessageWithReferenceParameterReturnBoolean(ref Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }


}
