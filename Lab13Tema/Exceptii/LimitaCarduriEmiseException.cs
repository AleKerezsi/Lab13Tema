using System;
using System.Runtime.Serialization;

namespace Lab13Tema.Exceptii
{
    [Serializable]
    public class LimitaCarduriEmiseException : Exception
    {
        public LimitaCarduriEmiseException()
        {
        }

        public LimitaCarduriEmiseException(string message) : base(message)
        {
        }
     
    }
}