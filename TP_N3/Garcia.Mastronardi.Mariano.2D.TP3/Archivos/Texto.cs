using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Archivos
{
    [Serializable]
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda el contenido de datos en un archivo de Texto 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True en caso de generar el archivo correctamente</returns>
        public bool Guardar(string archivo, string datos)
        {
            FileStream fs = new FileStream(archivo, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, datos.Trim());
            fs.Close();
            return true;
        }

        /// <summary>
        /// Lee un archivo de texto pasado por el parametro archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True en caso de que haya podido leerlo</returns>
        public bool Leer(string archivo, out string datos)
        {
            FileStream fs = new FileStream(archivo, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            datos = (string)bf.Deserialize(fs);
            fs.Close();
            return true;
        }
    }
}
