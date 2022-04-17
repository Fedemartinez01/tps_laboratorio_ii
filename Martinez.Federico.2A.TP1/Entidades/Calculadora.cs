using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida si el operador ingresado es válido
        /// </summary>
        /// <param name="operador">Operador ingresado</param>
        /// <returns>Retorna el operador o '+'</returns>
        static char ValidarOperador(char operador)
        {
            char retorno = '+';

            if(operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                retorno = operador;
            }
            return retorno;
        }

        /// <summary>
        /// Realiza la operacion seleccionada
        /// </summary>
        /// <param name="num1">Numero 1</param>
        /// <param name="num2">Numero 2</param>
        /// <param name="operador">Operador</param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            switch(ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;

                case '-':
                    resultado = num1 - num2;
                    break;

                case '*':
                    resultado = num1 * num2;
                    break;

                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}
