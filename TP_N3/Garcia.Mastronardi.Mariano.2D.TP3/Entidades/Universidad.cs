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

        public static bool Guardar(Universidad uni)
        {
            return new Xml<Universidad>().Guardar("Universidad.xml", uni);
        }

        private static string MostrarDatos(Universidad uni)
        {
            return uni.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool existe = false;
            if (!(a is null | g is null | g.Alumnos == null))
                existe = g.Alumnos.Contains(a);
            return existe;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool existe = false;
            if (!(i is null | g is null | g.profesores == null))
                existe = g.profesores.Contains(i);
            return existe;
        }

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
