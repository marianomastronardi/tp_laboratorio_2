using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionManager
{
    public class DniInvalidoException : Exception
   {
    private string mensajeBase;

    public DniInvalidoException()
    {
            this.mensajeBase = "Error de formato en el DNI.";
    }

    public DniInvalidoException(Exception e) :this(string.Empty, e)
    {
            
    }

    public DniInvalidoException(string message) :this(message,null)
    {

    }

    public DniInvalidoException(string message, Exception e) :base(message, e)
    {

    }
  }
}
