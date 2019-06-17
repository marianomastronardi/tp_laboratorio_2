using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entidades
{
    public static class GuardaString
    {
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
