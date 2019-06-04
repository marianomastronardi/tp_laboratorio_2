using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }


        public EClases Clase
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

        public Jornada(EClases clase, Profesor instructor)
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public bool Guardar(Jornada jornada)
        {

        }

        public string Leer()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Instructor.ToString());
            foreach (Alumno a in alumnos)
                sb.Append(a.ToString());
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
            if (!(j.alumnos.Contains(a)))
                j.alumnos.Add(a);
            return j;
        }
    }
}
