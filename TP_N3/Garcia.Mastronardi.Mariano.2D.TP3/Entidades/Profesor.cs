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
        }

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

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            Universidad.EClases clase = this.clasesDelDia.Dequeue();
            //null exception
            sb.AppendFormat("CLASE DE {0} POR {1} ", clase.ToString(), base.ToString());
            this.clasesDelDia.Enqueue(clase);
            sb.AppendFormat("LEGAJO NúMERO: {0}\n", this.Legajo);
            sb.AppendLine(ParticiparEnClase());
            
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            Universidad.EClases clase = this.clasesDelDia.Dequeue();
            sb.AppendLine("CLASES DEL DÍA:");
            sb.AppendLine(clase.ToString());
            this.clasesDelDia.Enqueue(clase);
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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
