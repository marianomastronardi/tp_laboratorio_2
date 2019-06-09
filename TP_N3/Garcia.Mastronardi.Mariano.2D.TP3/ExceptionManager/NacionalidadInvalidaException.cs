using System;

namespace ExceptionManager
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
        {

        }

        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
