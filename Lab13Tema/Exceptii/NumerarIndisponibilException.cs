using System;
using System.Runtime.Serialization;

namespace Lab13Tema.Exceptii
{
    [Serializable]
    public class NumerarIndisponibilException : Exception
    {
        public NumerarIndisponibilException()
        {
        }

        public NumerarIndisponibilException(string message) : base(message)
        {
        }
    }
}