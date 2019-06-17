using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Crea un archivo y guarda la informacion recibida
        /// </summary>
        /// <param name="text">informacion a grabar</param>
        /// <param name="archivo">ruta del archivo</param>
        /// <returns>true si pudo guardar</returns>
        public static bool Guardar(this string text, string archivo)
        {
            FileStream fs;
            BinaryFormatter bf = new BinaryFormatter();
            fs = new FileStream(archivo, FileMode.Append);
            bf.Serialize(fs, text);
            fs.Close();
            return true;
        }
    }
}
