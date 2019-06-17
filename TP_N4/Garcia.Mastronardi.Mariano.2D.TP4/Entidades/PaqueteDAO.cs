using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion; 

        static PaqueteDAO()
        {

        }

        public static bool Insertar(Paquete p)
        {
            try
            { 
            conexion = new SqlConnection(ConfigurationSettings.AppSettings["MainCorreo.Properties.Settings.DbTp4"].ToString());
            comando = new SqlCommand(string.Format("Insert into dbo.Paquetes values ({0}, {1}, {2});", p.DireccionEntrega, p.TrackingID, "Mariano.Garcia.Mastronardi"), conexion);
            comando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception("Error al insertar el Paquete en la BD", e);
            }
            return true;
        }
    }
}
