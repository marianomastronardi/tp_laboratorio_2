using System;

namespace ExceptionManager
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base(innerException.Message, innerException)
        {

        }

    }
}
