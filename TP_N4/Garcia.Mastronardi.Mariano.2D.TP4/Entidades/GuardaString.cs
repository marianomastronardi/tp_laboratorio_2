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
      StreamWriter sw = new StreamWriter(archivo, true, System.Text.Encoding.UTF8);
      sw.WriteLine(text);
      sw.Close();
      return true;
    }
  }
}
