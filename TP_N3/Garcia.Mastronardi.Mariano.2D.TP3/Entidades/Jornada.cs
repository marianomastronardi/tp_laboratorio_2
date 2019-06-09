using Archivos;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }
        
        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        public List<Alumno> Alumno
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        private Jornada()
        {
            this.Alumno = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) :this()
        {
            this.clase = clase;
            this.instructor = new Profesor();
            this.instructor = instructor;
        }

        public static bool Guardar(Jornada jornada)
        {
            return new Texto().Guardar("Jornada.txt", jornada.ToString());
        }

        public string Leer()
        {
            string j = string.Empty;
            new Texto().Leer("Jornada.txt", out j);
            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            if (alumnos != null)
            {
                foreach (Alumno a in alumnos)
                    sb.Append(a.ToString());
            }
            return sb.ToString();
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return (!(a != j.clase));
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j!=a))
                j.alumnos.Add(a);
            return j;
        }
    }
}
