using System;
using System.Collections.Specialized;

namespace Entidades
{

    class Numero
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
        Numero()
        {
            this.numero = 0;
        }

        Numero(double numero)
        {
            this.numero = numero;
        }

        Numero(string numero)
        {
            //this.numero = numero;
            //como puedo entrar por SetNumero????
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

        string BinarioDecimal(string numero)
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

        string DecimalBinario(double numero)
        {
            return this.DecimalBinario(numero.ToString());
        }

        string DecimalBinario(string numero)
        {
            int cociente;
            StringCollection restos = new StringCollection();
            bool isNumber = int.TryParse(numero, out cociente);

            if (isNumber)
            {
                //guardo en la coleccion los restos
                while (cociente < 2)
                {
                    restos.Add((cociente % 2).ToString());
                }

                //recorro el stringCollection de atras para adelante
                StringEnumerator eRestos = restos.GetEnumerator();
                int i = restos.Count - 1;
                string[] ret = new string[i];

                //dejo los items en mi array
                while (eRestos.MoveNext())
                {
                    ret[i] = eRestos.Current;
                    i--;
                }

                //ahora devuelvo el numero convertido a binario
                for (int j = 0; i < ret.Length; j++)
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
            return numero1 + numero2;
        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1 - numero2;
        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1 * numero2;
        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            return numero1 / numero2;
        }
    }
}
