using System;

namespace E01_Calculadora
{

    class Program
    {

        static void Main(string[] args)
        {

            // Instanciar a calculadora
            CalculadoraSimples calculadora = new CalculadoraSimples();

            // Invocar os métodos
            calculadora.LerNumeros();

            calculadora.Somar();
            calculadora.EscreverResultado();

            calculadora.Subtrair();
            calculadora.EscreverResultado();

            calculadora.Multiplicar();
            calculadora.EscreverResultado();

            calculadora.Dividir();
            calculadora.EscreverResultado();

            Console.ReadLine();

        }

    }

}
