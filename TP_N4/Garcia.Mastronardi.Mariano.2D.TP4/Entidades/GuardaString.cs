using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string text, string archivo)
        {
            StreamWriter sw = new StreamWriter(archivo);
            sw.WriteLine(text);
            sw.Close();
            return true;
        }
    }
}
