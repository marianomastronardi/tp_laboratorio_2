namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Reliza la operacion matematica segun los parametros ingresados
        /// </summary>
        /// <param name="numero1"> primer valor a operar</param>
        /// <param name="numero2"> segundo valor a operar</param>
        /// <param name="operador"> operador matematico, puede ser suma, resta, producto o division</param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double ret;

            operador = ValidarOperador(operador);

            if (operador == "+")
            {
                ret = numero1 + numero2;
            }
            else if (operador == "-")
            {
                ret = numero1 - numero2;
            }
            else if (operador == "*")
            {
                ret = numero1 * numero2;
            }
            else
            {
                ret = ((double)numero2 == 0 ? double.MinValue : (numero1 / numero2));
            }
            return ret;
        }

        /// <summary>
        /// Verifica si el operador es valido
        /// en caso de no ser suma, resta, producto o division, devuleve el operador +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            if (!(operador == "+" || operador == "-" || operador == "*" || operador == "/"))
                operador = "+";

            return operador;
        }
    }
}
