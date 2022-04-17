using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        double numero;


        /// <summary>
        /// Constructor de operando
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor de operando
        /// </summary>
        /// <param name="numero">Numero para asignar</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de operando
        /// </summary>
        /// <param name="strNumero">Numero en formato string para asignar</param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }


        /// <summary>
        /// Valida si lo ingresado es un número
        /// </summary>
        /// <param name="strNumero">Número ingresado</param>
        /// <returns>Retorna el numero si es correcto, 0 si no lo es</returns>
        double ValidarOperando(string strNumero)
        {
            double numero;

            bool esNumero = double.TryParse(strNumero, out numero);

            if(esNumero)
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Agrega un valor al número, previa validacion
        /// </summary>
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Valida que solo sean 0 y 1
        /// </summary>
        /// <param name="binario">Número binario</param>
        /// <returns>true si es binario, 0 si no lo es</returns>
        static bool EsBinario(string binario)
        {
            bool retorno = true;
            int largoCadena;
            largoCadena = binario.Length;

            for(int i = 0; i < largoCadena; i++)
            {
                if(binario[i] != '0' && binario [i] != '1')
                {
                    retorno = false;
                }
            }
            return retorno;           
        }

        // CONVERSIONES

        /// <summary>
        /// Convierte el resultado en binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Binario</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int numeroDecimal = (int)numero;

            numeroDecimal = Math.Abs(numeroDecimal);

            if (numeroDecimal > 0)
            {
                while (numeroDecimal > 0)
                {
                    if(numeroDecimal % 2 == 1)
                    {
                        binario = "1" + binario;
                    }
                    else
                    {
                        binario = "0" + binario;
                    }
                    numeroDecimal /= 2;
                }
            }
            else
            {
                binario = "Valor inválido";
            }
            return binario;
        }

        /// <summary>
        /// Convierte el resultado en binario
        /// </summary>
        /// <param name="numero">Numero a convertir en formato string</param>
        /// <returns>Binario</returns>
        public string DecimalBinario(string numero)
        {
            string binario = "";
            double numeroDecimal;

            if(double.TryParse(numero, out numeroDecimal))
            {
                binario = DecimalBinario(numeroDecimal);
            }
            else
            {
                binario = "Valor inválido";
            }
            return binario;
        }

        /// <summary>
        /// Convierte el resultado en decimal
        /// </summary>
        /// <param name="numero">Numero binario a convertir</param>
        /// <returns>Numero decimal</returns>
        public string BinarioDecimal(string numero)
        {
            double exponente = numero.Length - 1;
            double numeroDecimal = 0;
           
            if (EsBinario(numero))
            {               
               for(int i = 0; i < numero.Length; i++)
                {
                    if(numero[i] == '1')
                    {
                        numeroDecimal += Math.Pow(2, exponente);
                    }
                    exponente--;
                }
                return numeroDecimal.ToString();
            }
            else
            {
                return "Valor inválido";
            }         
        }
        // OPERADORES

        /// <summary>
        /// Suma
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>El resultado</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>El resultado</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplicacion
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>El resultado</returns>
     
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Division
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>El resultado si es posible, double.MinValue si no lo es</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }          
        }


    }
}
