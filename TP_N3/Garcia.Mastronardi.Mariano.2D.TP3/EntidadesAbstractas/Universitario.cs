using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.Legajo = legajo;
        }

        /// <summary>
        /// Muestra los atrinutos de la clase base y el legajo
        /// </summary>
        /// <returns>los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.ToString());
            sb.AppendFormat("LEGAJO NÚMERO: {0}", this.Legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Verifica si los dos universitarios son igulales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>si coinciden en DNI y tipo, es true</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return ((pg1.DNI == pg2.DNI | pg1.Legajo == pg2.Legajo) && pg1.GetType() == pg2.GetType());
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (!(pg1 == pg2));
        }

        public override bool Equals(object obj)
        {
            return (this == (Universitario)obj);
        }
    }
}
