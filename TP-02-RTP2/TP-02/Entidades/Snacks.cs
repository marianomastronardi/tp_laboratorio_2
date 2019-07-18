using System;
using System.Text;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region "Constructores"
        public Snacks(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
        {
        }
        #endregion

        #region "Propiesdades"
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Muestra llos atributos de Snacks
        /// </summary>
        /// <returns>retorna los atributos de Snacks y su clase padre</returns>
        public override string Mostrar()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine((string)this);
            sb.AppendLine(string.Format("CALORIAS : {0}", this.CantidadCalorias));
            sb.AppendLine("----------------------");

            return sb.ToString();
        }
        #endregion
    }
}
