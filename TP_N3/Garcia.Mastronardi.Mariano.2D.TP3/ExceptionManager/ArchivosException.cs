using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionManager
{
  public class ArchivosException : Exception
  {
    public ArchivosException(Exception innerException) :base(string.Empty, innerException)
    {

    }

    }
}
