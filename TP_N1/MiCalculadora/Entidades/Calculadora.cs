namespace Entidades
{
    static class Calculadora
    {

        static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double ret;

            operador = ValidarOperador(operador);

            if (operador == "+")
            {
                ret = (double)numero1 + (double)numero2;
            }
            else if (operador == "-")
            {
                ret = (double)numero1 - (double)numero2;
            }
            else if (operador == "*")
            {
                ret = (double)numero1 * (double)numero2;
            }
            else  //division
            {
                if ((double)numero2 == 0)
                    ret = double.MinValue;
                else
                    ret = ((double)numero1 / (double)numero2);
                
            }
            return ret;
        }

        private static string ValidarOperador(string operador)
        {
            if (!(operador == "+" || operador == "-" || operador == "*" || operador == "/"))
                operador = "+";

            return operador;
        }
    }
}
