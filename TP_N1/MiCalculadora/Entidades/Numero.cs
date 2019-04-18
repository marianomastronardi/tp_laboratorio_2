using System;
using System.Collections.Specialized;

namespace Entidades
{

    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad que setea el valor del atributo numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                numero = this.ValidarNumero(value);
            }
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Numero() :this(0)
        {
            
        }

        /// <summary>
        /// constructor que setea el atributo numero
        /// </summary>
        /// <param name="numero"> parametro que asignara su valor al atributo numero</param>
        public Numero(double numero) :this(numero.ToString())
        {
            
        }

        /// <summary>
        /// constructor que setea el atributo numero
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// operador double explicito que devuelve el atributo numero
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator double(Numero n)
        {
            return n.numero;
        }

        /// <summary>
        /// operador int explicito que devuelve el atributo numero casteado a int
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator int(Numero n)
        {
            return (int)n.numero;
        }

        /// <summary>
        /// operador string explicito que devuelve el atributo numero casteado a string
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator string(Numero n)
        {
            return n.numero.ToString();
        }
        
        /// <summary>
        /// Convierte un numero binario a Decimal
        /// </summary>
        /// <param name="numero"> parametro q recibe un numero binario</param>
        /// <returns>decimal en formato string</returns>
        public string BinarioDecimal(string numero)
        {
            //Declaro un array can tantos elementos como carateres tenga el parametro numero
            int ret = 0;
            bool isNumber = true;
            bool isBinary = numero.Replace("0", "").Replace("1", "").Length == 0;
            int bit = 0;
            int i = 0;
            int j = numero.Length - 1;

            if (isNumber && isBinary)
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

            return (isNumber && isBinary) ? ret.ToString() : "Valor inválido";
        }

        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero"> parametro double con el valor del numero a convertir </param>
        /// <returns> string convertido a binario </returns>
        public string DecimalBinario(double numero)
        {
            return this.DecimalBinario(((int)Math.Abs(numero)).ToString());
        }

        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero"> parametro string con el valor del numero a convertir </param>
        /// <returns> string convertido a binario </returns>
        public string DecimalBinario(string numero)
        {
            int cociente;
            StringCollection restos = new StringCollection();
            bool isNumber = int.TryParse(numero, out cociente);
            int rescociente = 0;
            if (isNumber)
            {
                if (cociente == 0)
                {
                    restos.Add("0");
                }
                else
                {
                    //guardo en la coleccion los restos
                    while (cociente >= 2)
                    {
                        rescociente = cociente % 2;
                        restos.Add((rescociente).ToString());
                        cociente = cociente / 2;
                    }
                    restos.Add("1");
                }


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

        /// <summary>
        /// valida que el string recibido pueda convertirse a numero
        /// </summary>
        /// <param name="strNumero"> parametro string con el valor del numero a validar </param>
        /// <returns> si es un numero valido, numero recibido en formato double, sino 0 </returns>
        double ValidarNumero(string strNumero)
        {
            double ret = 0;

            return double.TryParse(strNumero, out ret) ? double.Parse(strNumero) : ret;
        }

        /// <summary>
        /// suma dos clases Numero mediante su atributo numero
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <returns> la suma de dos numeros </returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.numero + numero2.numero;
        }

        /// <summary>
        /// resta dos clases Numero mediante su atributo numero
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <returns> la resta de dos numeros </returns>
        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.numero - numero2.numero;
        }

        /// <summary>
        /// multiplica dos clases Numero mediante su atributo numero
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <returns> el producto de dos numeros </returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.numero * numero2.numero;
        }

        /// <summary>
        /// divide dos clases Numero mediante su atributo numero
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <returns> el cociente de dos numeros </returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            return numero2.numero == 0 ? double.MinValue : numero1.numero / numero2.numero;
        }
    }
}
