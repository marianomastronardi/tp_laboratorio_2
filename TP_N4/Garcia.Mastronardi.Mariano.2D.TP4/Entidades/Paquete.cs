using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoEstado(object sender, EventArgs e);
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

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

        }

        public override string ToString()
        {
            return base.ToString();

        }

        public void MockCicloVida()
        {

        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Empty;
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
