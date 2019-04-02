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

        //Numero(string numero)
        //{
        //    this.numero = this.SetNumero;
        //}

        string BinarioDecimal(double numero)
        {
            return Math.Abs((double)numero).ToString();
        }

        string BinarioDecimal(string numero)
        {
            //Numero n;
            //n.numero = numero;
            //return Math.Abs((double)numero).ToString();
            return numero;
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
