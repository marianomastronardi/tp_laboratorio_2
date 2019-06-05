using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        //como declaro un constructor vacio privado
        static Profesor()
        {
          random = new Random();
        }

        public Profesor() 
        {
            //como hago para pasar por aca cuando llamo al otro constructor
      
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._randomClases();
        }

        private void _randomClases()
        {
            switch(random.Next(4))
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
            Universidad.EClases clase;
            sb.AppendFormat("CLASE DE {0} POR {1} ", this.clasesDelDia.ToString(), base.ToString());
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            while (clasesDelDia.Count > 0)
            {
                sb.AppendLine(clasesDelDia.Dequeue().ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool existe = false;

            while(i.clasesDelDia.Count > 0)
            {
                if(i.clasesDelDia.Dequeue() == clase)
                {
                    existe = !existe;
                    break;
                }
            }
            return existe;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i == clase));
        }
    }
}
