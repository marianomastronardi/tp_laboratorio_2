using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Genera un archivo xml con el contenido del parametro datos 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            ser.Serialize(writer, datos);
            writer.Close();
            return true;
        }

        /// <summary>
        /// Lee el archivo pasado por el parametro archivo 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True en caso de poder leerlo y el objeto T</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = new XmlTextReader(archivo);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            datos = (T)ser.Deserialize(reader);
            reader.Close();
            return true;
        }
    }
}
