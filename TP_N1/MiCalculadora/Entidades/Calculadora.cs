namespace Entidades
{
    static class Calculadora
    {

        static double Operar(Numero numero1, Numero numero2, string operador)
        {
            //double ret;

            //if(operador == "+")
            //{
            //  ret = (double)numero1 + numero2;
            //}
            //else if(operador == "-")
            //{

            //}
            return double.MinValue;
        }

        private static string ValidarOperador(string operador)
        {
            if (!(operador == "+" || operador == "-" || operador == "*" || operador == "/"))
                operador = "+";

            return operador;
        }
    }
}
