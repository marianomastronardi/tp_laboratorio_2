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
        private Queue<EClases> clasesDelDia;
        private static Random random;

        //como declaro un constructor vacio privado
        //private Profesor()
        //{

        //}

        public Profesor()
        {
            //como hago para pasar por aca cuando llamo al otro constructor
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._randomClases();
        }

        private void _randomClases()
        {
            switch(random.Next(4))
            {
                case ((int)EClases.Laboratorio):
                    this.clasesDelDia.Enqueue(EClases.Laboratorio);
                    break;
                case ((int)EClases.Legislacion):
                    this.clasesDelDia.Enqueue(EClases.Legislacion);
                    break;
                case ((int)EClases.Programacion):
                    this.clasesDelDia.Enqueue(EClases.Programacion);
                    break;
                case ((int)EClases.SPD):
                    this.clasesDelDia.Enqueue(EClases.SPD);
                    break;
                default:
                    break;
            }
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            EClases clase;
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

        public static bool operator ==(Profesor i, EClases clase)
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

        public static bool operator !=(Profesor i, EClases clase)
        {
            return (!(i == clase));
        }
    }
}
