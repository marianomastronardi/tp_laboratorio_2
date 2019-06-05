using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Archivos
{
    [Serializable]
    public class Texto : IArchivo<string>
    {
    public bool Guardar(string archivo, string datos)
    {
      FileStream fs = new FileStream(archivo, FileMode.Create);
      BinaryFormatter bf = new BinaryFormatter();
      bf.Serialize(fs, datos);
      fs.Close();
      return true;
    }
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
