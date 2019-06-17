using System.Collections.Generic;
using System.Text;
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
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            if (mockPaquetes != null)
            {
                foreach (Thread t in mockPaquetes)
                    t.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elemento).Paquetes)
                sb.AppendFormat("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());

            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            if (!(c is null | p is null))
            {
                foreach (Paquete paq in c.Paquetes)
                    if (paq == p) throw new TrackingIdRepetidoException(string.Format("Paquete repetido: \n{0}", p.ToString()));

                c.Paquetes.Add(p);
                Thread t = new Thread(p.MockCicloVida);
                c.mockPaquetes.Add(t);
                t.Start();

            }
            return c;
        }
    }
}
