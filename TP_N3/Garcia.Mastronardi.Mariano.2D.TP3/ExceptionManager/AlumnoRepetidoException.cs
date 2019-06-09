using System;

namespace ExceptionManager
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }
    }
}
