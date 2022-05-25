using System;

namespace E01_Calculadora
{

    internal class Program
    {

        static void Main(string[] args)
        {

            #region Calculadora Simples v01 (Main)

            /*
            CalculadoraSimples.LerNumeros();

            CalculadoraSimples.Somar();

            CalculadoraSimples.Subtrair();

            CalculadoraSimples.Multiplicar();

            CalculadoraSimples.Dividir();

            Console.ReadLine();
            */

            #endregion

            #region Calculadora Simples v02 (main)

            CalculadoraSimples.LerNumeros();

            CalculadoraSimples.Somar();
            CalculadoraSimples.EscreverResultado();

            CalculadoraSimples.Subtrair();
            CalculadoraSimples.EscreverResultado();

            CalculadoraSimples.Multiplicar();
            CalculadoraSimples.EscreverResultado();

            CalculadoraSimples.Dividir();
            CalculadoraSimples.EscreverResultado();

            Console.ReadLine();

            #endregion

        }

    }

}
