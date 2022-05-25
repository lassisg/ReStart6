using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_Calculadora
{

    internal class Program
    {

        static void Main(string[] args)
        {

            // Instanciar a calculadora
            CalculadoraSimples calculadora = new CalculadoraSimples();

            // Invocar os métodos
            calculadora.ShowMenu();

            if (calculadora.Operacao != 4)
            {

                calculadora.ReadNumbers();
                calculadora.ExecuteOperation();
                calculadora.ShowResult();

            }
            
            Console.WriteLine("\nA terminar...");

            Console.ReadLine();

        }

    }

}
