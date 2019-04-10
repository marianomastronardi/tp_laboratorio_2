namespace Entidades
{
   public static class Calculadora
    {

    /*
    1. El método ValidarOperador será privado y estático. Deberá validar que el operador
    recibido sea +, -, / o *. Caso contrario retornará +.
    2. El método Operar será de clase:
    a. Validará y realizará la operación pedida entre ambos números.
    b. Si se tratara de una división por 0, retornará double.MinValue.
    */
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
            else  //division
            {
               /* if (numero2 == 0)
                    ret = double.MinValue;
                else
                 */   ret = (numero1 / numero2);
                
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
