using Archivos;
using ExceptionManager;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }
        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }

        public Jornada this[int i] { get { return this.jornada[i]; } set { this.jornada[i] = value; } }

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        /// <summary>
        /// Genera los datos de las Jornadas de la clase
        /// </summary>
        /// <returns>Devuelve las Jornadas con sus Profesores y Alumnos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada j in this.Jornadas)
            {
                sb.AppendLine("JORNADA: ");
                sb.AppendLine(j.ToString());
                sb.AppendLine("<----------------------------->");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Genera un Archivo Xml con los datos de la Universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True en caso de que el archivo se genere con éxito</returns>
        public static bool Guardar(Universidad uni)
        {
            return (new Xml<Universidad>().Guardar(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\Universidad.xml", uni) ? true : throw new System.Exception("Error al Guardar el Archivo"));
        }

        /// <summary>
        /// Llama al Metodo ToString()
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Devuelve las Jornadas con sus Profesores y Alumnos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            return uni.ToString();
        }

        /// <summary>
        /// Verifica si el alumno ya existe para la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True en caso que existe, sino False</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool existe = false;
            if (!(a is null | g is null | g.Alumnos == null))
                existe = g.Alumnos.Contains(a);
            return existe;
        }

        /// <summary>
        /// Verifica que el profesor para la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si existe, sino False</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool existe = false;
            if (!(i is null | g is null | g.profesores == null))
                existe = g.profesores.Contains(i);
            return existe;
        }

        /// <summary>
        /// Verifica si hay profesores para la Clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>El profesor para esa clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor p = null;

            foreach (Profesor a in u.Instructores)
            {
                if (a == clase)
                {
                    p = new Profesor();
                    p = a;
                    break;
                }
            }
            if (p is null)
                throw new SinProfesorException();
            return p;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return (!(g == a));
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return (!(g == i));
        }

        /// <summary>
        /// Verifica si hay algun profesor que no tenga asignada esa clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Un profesor o una exception</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor p = null;

            foreach (Profesor a in u.Instructores)
            {
                if (a != clase)
                {
                    p = new Profesor();
                    p = a;
                    break;
                }
            }
            if (p is null)
                throw new SinProfesorException();
            return (p);
        }

        /// <summary>
        /// Agrega una clase a la Universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>el objeto Universidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = new Profesor();
            Jornada j = new Jornada(clase, (g == clase));
            foreach (Alumno a in g.Alumnos)
                if (a == clase) j.Alumno.Add(a);
            g.Jornadas.Add(j);
            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }
    }
}
