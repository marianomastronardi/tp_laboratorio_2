using System;
using System.Text;
using System.Threading;

namespace Entidades
{

    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public string TrackingID
        {
            get { return trackingID; }
            set { trackingID = value; }
        }

        public EEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Muestra la informacion del paquete con su estado.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} Estado {1}\n", this.MostrarDatos(this), this.Estado.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Modifica el estado del paquete y al llegar a Entregado lo guarda en la BD
        /// </summary>
        public void MockCicloVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado = this.Estado == EEstado.Ingresado ? EEstado.EnViaje : EEstado.Entregado;
                DelegadoEstado d = this.InformaEstado;
                d(this, null);
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Muestra la informacion del paquete sin el estado
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}\n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return (!(p1 == p2));
        }
    }
}
