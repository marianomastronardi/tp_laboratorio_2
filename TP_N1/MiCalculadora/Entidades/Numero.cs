using System;

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

            while(isNumber && i < numero.Length)
            {
                isNumber = int.TryParse(numero.Substring(i, 1), out bit);
                ret += (bit * (int)Math.Pow(2, i));
                i++;
            }
           
            return ret.ToString();
        }

        string DecimalBinario(double numero)
        {
            return Math.Abs((double)numero).ToString();
        }

        string DecimalBinario(string numero)
        {
            //Numero n;
            //n.numero = numero;
            //return Math.Abs((double)numero).ToString();
            return numero;
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
