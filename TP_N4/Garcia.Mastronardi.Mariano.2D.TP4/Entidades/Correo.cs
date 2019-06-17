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

        /// <summary>
        /// Cierra todos los hilos iniciados
        /// </summary>
        public void FinEntregas()
        {
            if (mockPaquetes != null)
            {
                foreach (Thread t in mockPaquetes)
                    t.Abort();
            }
        }

        /// <summary>
        /// Muestra la info de todos los paquetes del correo
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>info paquetes</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elementos).Paquetes)
                sb.AppendFormat("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Agrega un paquete a la lista de paquetes del correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>Correo con paquete agregado o exception</returns>
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
