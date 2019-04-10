using System;
using System.Collections.Specialized;

namespace Entidades
{
  /*
7. Los métodos BinarioDecimal y DecimalBinario trabajaran con enteros positivos,
quedándose para esto con el valor absoluto y entero del double recibido:
b. Ambas opciones del método DecimalBinario convertirán un número decimal
a binario, en caso de ser posible. Caso contrario retornará "Valor inválido".
Reutilizar código.
     */
  public class Numero
  {
    private double numero;

    public string SetNumero
    {
      set
      {
        numero = this.ValidarNumero(value);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public Numero()
    {
      this.numero = 0;
    }

    public Numero(double numero)
    {
      this.numero = numero;
    }

    public Numero(string strNumero)
    {
      SetNumero = strNumero;
    }

    public static explicit operator double(Numero n)
    {
      return n.numero;
    }

    public static explicit operator int(Numero n)
    {
      return (int)n.numero;
    }

    public static explicit operator string(Numero n)
    {
      return n.numero.ToString();
    }

    string BinarioDecimal(double numero)
    {
      return Math.Abs((double)numero).ToString();
    }

    public string BinarioDecimal(string numero)
    {
      //Declaro un array can tantos elementos como carateres tenga el parametro numero
      int ret = 0;
      bool isNumber = true;
      bool isBinary = numero.Replace("0", "").Replace("1", "").Length == 0;
      int bit = 0;
      int i = 0;
      int j = numero.Length - 1;

      if(isNumber && isBinary)
      {
        while (i < numero.Length)
        {
          isNumber = int.TryParse(numero.Substring(i, 1), out bit);
          if (!isNumber)
            break;
          ret += (bit * (int)Math.Pow(2, j));
          i++;
          j--;
        }
      }
      
      return (isNumber && isBinary) ? ret.ToString() : numero;
    }

    public string DecimalBinario(double numero)
    {
      return this.DecimalBinario(numero.ToString());
    }

    public string DecimalBinario(string numero)
    {
      int cociente;
      StringCollection restos = new StringCollection();
      bool isNumber = int.TryParse(numero, out cociente);
      int rescociente = 0;
      if (isNumber)
      {
        //guardo en la coleccion los restos
        while (cociente >= 2)
        {
          rescociente = cociente % 2;
          restos.Add((rescociente).ToString());
          cociente = cociente / 2;
        }
        restos.Add("1");

        //recorro el stringCollection de atras para adelante
        StringEnumerator eRestos = restos.GetEnumerator();
        int i = restos.Count - 1;
        string[] ret = new string[i + 1];

        //dejo los items en mi array
        while (eRestos.MoveNext())
        {
          ret[i] = eRestos.Current;
          i--;
        }

        numero = string.Empty;
        //ahora devuelvo el numero convertido a binario
        for (int j = 0; j < ret.Length; j++)
        {
          numero += ret[j];
        }
      }

      return isNumber ? numero : "Valor Inválido";
    }

    double ValidarNumero(string strNumero)
    {
      double ret = 0;

      return double.TryParse(strNumero, out ret) ? double.Parse(strNumero) : ret;
    }

    public static double operator +(Numero numero1, Numero numero2)
    {
      return numero1.numero + numero2.numero;
    }

    public static double operator -(Numero numero1, Numero numero2)
    {
      return numero1.numero - numero2.numero;
    }

    public static double operator *(Numero numero1, Numero numero2)
    {
      return numero1.numero * numero2.numero;
    }

    public static double operator /(Numero numero1, Numero numero2)
    {
      return numero2.numero == 0 ? double.MinValue : numero1.numero / numero2.numero;
    }
  }
}
