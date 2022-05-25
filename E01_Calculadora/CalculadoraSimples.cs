using System;

namespace E01_Calculadora
{
    internal class CalculadoraSimples
    {

        #region Calculadora Simples v01

        /*
        static double numero01;
        static double numero02;
        static double resultado;

        public static void LerNumeros()
        {
            Console.Write("Digite o número 1: ");
            numero01 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número 2: ");
            numero02 = Convert.ToDouble(Console.ReadLine());
        }

        public static void Somar()
        {

            resultado = numero01 + numero02;
            Console.WriteLine($"\nResultado da operação de adição: {numero01} + {numero02} = {resultado}");

        }

        public static void Subtrair()
        {

            resultado = numero01 - numero02;
            Console.WriteLine($"\nResultado da operação de subtração: {numero01} - {numero02} = {resultado}");

        }

        public static void Multiplicar()
        {

            resultado = numero01 * numero02;
            Console.WriteLine($"\nResultado da operação de multiplicação: {numero01} * {numero02} = {resultado}");

        }

        public static void Dividir()
        {

            resultado = numero01 / numero02;
            Console.WriteLine($"\nResultado da operação de divisão: {numero01} / {numero02} = {resultado}");

        }
        */

        #endregion


        #region Calculadora Simples v02

        static double numero01, numero02, resultado;
        static string operacao, simbolo;

        public static void LerNumeros()
        {
            Console.Write("Digite o número 1: ");
            numero01 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número 2: ");
            numero02 = Convert.ToDouble(Console.ReadLine());
        }

        public static void Somar()
        {

            operacao = "adição";
            simbolo = "+";
            resultado = numero01 + numero02;

            // EscreverResultado();     // Não chamar aqui porque já foge de sua responsabilidade

        }

        public static void Subtrair()
        {

            operacao = "subtração";
            simbolo = "-";
            resultado = numero01 - numero02;

        }

        public static void Multiplicar()
        {

            operacao = "multiplicação";
            simbolo = "*";
            resultado = numero01 * numero02;

        }

        public static void Dividir()
        {

            operacao = "divisão";
            simbolo = "/";
            resultado = numero01 / numero02;

        }

        public static void EscreverResultado()
        {

            Console.WriteLine($"\nResultado da operação de {operacao}: {numero01} {simbolo} {numero02} = {resultado}");

        }

        #endregion

    }

}
