using EntidadesAbstractas;
using System.Text;

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private EEstadoCuenta estadoCuenta;
        private Universidad.EClases claseQueToma;

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Llama al metodo ToString() de la clase base y le agrega el estado de cuenta
        /// </summary>
        /// <returns>Los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("\nESTADO DE CUENTA: {0}\n", this.estadoCuenta.ToString());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Busca las clases del aluno
        /// </summary>
        /// <returns>string con las clases del alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TOMA CLASES DE: {0}\n\n", this.claseQueToma);

            return sb.ToString();
        }

        /// <summary>
        /// Llama al metodo MostrarDatos()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si el alumno ya tiene la clase del parametro
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>True en caso de que tenga asignada la clase y no sea Deudor</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Verifica si el alumno ya tiene la clase del parametro
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>True en caso de que NO tenga asignada la clase</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }
    }
}
