using System;

namespace ExceptionManager
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException() : base("No hay Profesor para la clase.")
        {

        }
    }
}
