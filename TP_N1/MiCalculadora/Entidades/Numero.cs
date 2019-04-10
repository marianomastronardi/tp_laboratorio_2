using System;
using System.Collections.Specialized;

namespace Entidades
{
  /*
3.  El atributo numero es privado.
4. El constructor por defecto (sin parámetros) asignará valor 0 al atributo numero.
5. ValidarNumero comprobará que el valor recibido sea numérico, y lo retornará en
formato double. Caso contrario, retornará 0.
6. La propiedad SetNumero asignará un valor al atributo número, previa validación.
En este lugar será el único en todo el código que llame al método ValidarNumero.
7. Los métodos BinarioDecimal y DecimalBinario trabajaran con enteros positivos,
quedándose para esto con el valor absoluto y entero del double recibido:
a. El método BinarioDecimal convertirá un número binario a decimal, en caso
de ser posible. Caso contrario retornará "Valor inválido".
b. Ambas opciones del método DecimalBinario convertirán un número decimal
a binario, en caso de ser posible. Caso contrario retornará "Valor inválido".
Reutilizar código.
8. Los operadores realizarán las operaciones correspondientes entre dos números.
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
      //Numero n;
      //n.numero = numero;
      //return Math.Abs((double)numero).ToString();

      //Declaro un array can tantos elementos como carateres tenga el parametro numero
      int ret = 0;
      bool isNumber = true;
      int bit = 0;
      int i = 0;

      while (isNumber && i < numero.Length)
      {
        isNumber = int.TryParse(numero.Substring(i, 1), out bit);
        if (!isNumber)
          break;
        ret += (bit * (int)Math.Pow(2, i));
        i++;
      }

      return isNumber ? ret.ToString() : "Valor Inválido";
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
      double ret = double.MinValue;

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
