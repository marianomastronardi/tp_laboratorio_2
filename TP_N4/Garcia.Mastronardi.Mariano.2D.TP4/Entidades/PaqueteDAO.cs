using System;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        static PaqueteDAO()
        {

        }

        /// <summary>
        /// Inserta el paquete en la tabla dbo.Paquete
        /// </summary>
        /// <param name="p"></param>
        /// <returns>True si se pudo insertar en la BD</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.DbTp4);
                comando = new SqlCommand(string.Format("Insert into dbo.Paquetes values ('{0}', '{1}', '{2}');", p.DireccionEntrega, p.TrackingID, "Mariano.Garcia.Mastronardi"), conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Error al insertar el Paquete en la BD", e);
            }
            return true;
        }
    }
}
