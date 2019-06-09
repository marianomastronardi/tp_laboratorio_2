using System;

namespace ExceptionManager
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException() : base("Error de formato en el DNI.")
        {
            this.mensajeBase = this.Message;
        }

        public DniInvalidoException(Exception e) : this(string.Empty, e)
        {

        }

        public DniInvalidoException(string message) : this(message, null)
        {

        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
    }
}
