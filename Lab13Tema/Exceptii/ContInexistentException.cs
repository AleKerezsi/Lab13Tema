using System;
using System.Runtime.Serialization;

namespace Lab13Tema.Exceptii
{
    [Serializable]
    public class ContInexistentException : Exception
    {
        public ContInexistentException()
        {
        }

        public ContInexistentException(string message) : base(message)
        {
        }

        //public ContInexistentException(string message, Exception innerException) : base(message, innerException)
        //{
        //}

        //protected ContInexistentException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}