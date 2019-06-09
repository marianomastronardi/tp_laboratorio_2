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

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = new Profesor();
            this.instructor = instructor;
        }

        /// <summary>
        /// Llama a la interface IArchivo para generar un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True en caso de que se haya creado el archivo</returns>
        public static bool Guardar(Jornada jornada)
        {
            return new Texto().Guardar(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Llama a la interface IArchivo para leer un archivo de texto
        /// </summary>
        /// <returns>el texto con el contenido del archivo</returns>
        public string Leer()
        {
            string j = string.Empty;
            new Texto().Leer(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\Jornada.txt", out j);
            return j;
        }

        /// <summary>
        /// Busca los profesores y los alumnos asignados a la jornada
        /// </summary>
        /// <returns>los datos de profesores y alumnos</returns>
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

        /// <summary>
        /// Si un alumno no esta asignado a la jornada, lo agrega
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>retorna la jornada con el alumno agregado en caso de que no existiera antes</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j != a))
                j.alumnos.Add(a);
            return j;
        }
    }
}
