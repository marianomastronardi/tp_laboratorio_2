using System;

namespace ExceptionManager
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base(" Error I/O en el Archivo", innerException)
        {

        }

    }
}
