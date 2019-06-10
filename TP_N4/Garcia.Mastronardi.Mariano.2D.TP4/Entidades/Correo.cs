using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }

        public Correo()
        {

        }

        public void FinEntregas()
        {

        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            return string.Empty;
        }

        public static Correo operator +(Correo c, Paquete p)
        {

        }
    }
}
