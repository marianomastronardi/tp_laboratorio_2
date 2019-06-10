using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        static PaqueteDAO()
        {

        }

        static bool Insertar(Paquete p)
        {
            return true;
        }
    }
}
