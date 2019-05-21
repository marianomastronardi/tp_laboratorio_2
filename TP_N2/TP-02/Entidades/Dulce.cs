using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
  public class Dulce : Producto
  {
    #region "Constructores"
    public Dulce(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
    {
    }
    #endregion

    #region "Propiedades"
    /// <summary>
    /// Los dulces tienen 80 calorías
    /// </summary>
    protected override short CantidadCalorias
    {
      get
      {
        return 80;
      }
    }
    #endregion

    #region "Métodos"
    /// <summary>
    /// Publica todos los datos de Dulce y su clase padre Producto
    /// </summary>
    /// <returns>string con los valores asociados a la instancia de la clase</returns>
    public override string Mostrar()
    {
      StringBuilder sb = new StringBuilder();

      sb.AppendLine("DULCE");
      sb.AppendLine((string)this);
      sb.AppendLine(string.Format("CALORIAS : {0}", this.CantidadCalorias));
      sb.AppendLine("----------------------");

      return sb.ToString();
    }
    #endregion
  }
}
