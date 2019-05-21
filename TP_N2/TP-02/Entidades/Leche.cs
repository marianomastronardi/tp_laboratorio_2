using System;
using System.Text;

namespace Entidades_2018
{
  public class Leche : Producto
  {
    #region "Atributos"
    public enum ETipo { Entera, Descremada }
    private ETipo tipo;
    #endregion

    #region "Constructores"
    /// <summary>
    /// Por defecto, TIPO será ENTERA
    /// </summary>
    /// <param name="marca"></param>
    /// <param name="patente"></param>
    /// <param name="color"></param>
    public Leche(EMarca marca, string patente, ConsoleColor color) : this(marca, patente, color, ETipo.Entera)
    {

    }

    public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) : base(patente, marca, color)
    {
      this.tipo = tipo;
    }
    #endregion

    #region "Propiedades"
    /// <summary>
    /// Las leches tienen 20 calorías
    /// </summary>
    protected override short CantidadCalorias
    {
      get
      {
        return 20;
      }
    }
    #endregion

    #region "Métodos"
    /// <summary>
    /// Publica todos los datos de Leche y los de su clase padre Producto
    /// </summary>
    /// <returns>string con todos los valores de la instancia de la clase</returns>
    public override string Mostrar()
    {
      StringBuilder sb = new StringBuilder();

      sb.AppendLine("LECHE");
      sb.AppendLine((string)this);
      sb.Append(string.Format("CALORIAS : {0}", this.CantidadCalorias));
      sb.AppendLine("TIPO : " + this.tipo);
      sb.AppendLine("");
      sb.AppendLine("----------------------");

      return sb.ToString();
    }
    #endregion
  }
}
