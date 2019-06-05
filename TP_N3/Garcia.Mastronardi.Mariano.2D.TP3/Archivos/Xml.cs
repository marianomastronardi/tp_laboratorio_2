using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Archivos
{
  public class Xml<T> : IArchivo<T>
  {
    public bool Guardar(string archivo, T datos)
    {
      XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
      XmlSerializer ser = new XmlSerializer(typeof(T));
      ser.Serialize(writer, datos);
      writer.Close();
      return true;
    }
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
