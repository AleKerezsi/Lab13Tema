using System;
using System.Runtime.Serialization;

namespace Lab13Tema.Exceptii
{
    [Serializable]
    public class EroarePlataException : Exception
    {
        public EroarePlataException()
        {
        }

        public EroarePlataException(string message) : base(message)
        {
        }

    }
}