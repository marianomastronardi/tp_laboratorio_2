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
            foreach (Thread t in mockPaquetes)
                t.Abort();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in this.Paquetes)
                sb.AppendFormat("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            
            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            if(c != null && p != null)
            {
                if (!(c.Paquetes.Contains(p)))
                {
                    c.Paquetes.Add(p);
                    Thread t = new Thread(new p.MockCicloVida());
                    c.mockPaquetes.Add(t);
                }
                else
                    throw new TrackingIdRepetidoException(string.Format("Paquete repetido: \n{0}", p.ToString()));
            }
            return c;
        }
    }
}
