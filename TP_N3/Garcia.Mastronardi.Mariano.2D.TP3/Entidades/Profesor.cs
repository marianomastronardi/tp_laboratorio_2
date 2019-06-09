using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        /// <summary>
        /// Asigna una Clase al profesor mediante un random
        /// </summary>
        private void _randomClases()
        {
            switch (random.Next(4))
            {
                case ((int)Universidad.EClases.Laboratorio):
                    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case ((int)Universidad.EClases.Legislacion):
                    this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case ((int)Universidad.EClases.Programacion):
                    this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case ((int)Universidad.EClases.SPD):
                    this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Llama al mismo metodo de la clase base y le agrega los datos de el profesor 
        /// </summary>
        /// <returns>Todos los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            Universidad.EClases clase = this.clasesDelDia.Dequeue();
            sb.AppendFormat("CLASE DE {0} POR {1}\n", clase.ToString(), base.MostrarDatos());
            this.clasesDelDia.Enqueue(clase);
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Busca las clases asignadas
        /// </summary>
        /// <returns>Las clases asignadas al profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            Queue<Universidad.EClases>.Enumerator clase = this.clasesDelDia.GetEnumerator();
            sb.AppendLine("CLASES DEL DÍA:");
            while (clase.MoveNext())
            {
                sb.AppendLine(clase.Current.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Llama al metodo MostrarDatos()
        /// </summary>
        /// <returns>Devuelve los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si el profesor ya tiene asiganda la clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>True en caso de exista</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i == clase));
        }
    }
}
