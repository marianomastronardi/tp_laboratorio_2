using System;
using System.Text;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region "Atributos"
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorías del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region "Constructores"
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.codigoDeBarras = patente;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public abstract string Mostrar();
        #endregion

        #region "Operadores"
        /// <summary>
        /// Recibe un Producto el cual debe castear a string 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>todos sus atributos</returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("CODIGO DE BARRAS: {0}", p.codigoDeBarras));
            sb.AppendLine(string.Format("MARCA          : {0}", p.marca.ToString()));
            sb.AppendLine(string.Format("COLOR EMPAQUE  : {0}", p.colorPrimarioEmpaque.ToString()));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
