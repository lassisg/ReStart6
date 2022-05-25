using System;

namespace E01_Calculadora
{
    public class CalculadoraSimples
    {

        #region Properties

        public double Numero01 { get; set; }
        public double Numero02 { get; set; }
        public double Resultado { get; set; }
        public string Operacao { get; set; }
        public string Simbolo { get; set; }

        #endregion

        #region Methods

        public void LerNumeros()
        {

            Console.Write("Digite o número 1: ");
            Numero01 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número 2: ");
            Numero02 = Convert.ToDouble(Console.ReadLine());

        }

        public void Somar()
        {

            Operacao = "adição";
            Simbolo = "+";
            Resultado = Numero01 + Numero02;

            // EscreverResultado();     // Não chamar aqui porque já foge de sua responsabilidade ! ! !

        }

        public void Subtrair()
        {

            Operacao = "subtração";
            Simbolo = "-";
            Resultado = Numero01 - Numero02;

        }

        public void Multiplicar()
        {

            Operacao = "multiplicação";
            Simbolo = "*";
            Resultado = Numero01 * Numero02;

        }

        public void Dividir()
        {

            Operacao = "divisão";
            Simbolo = "/";
            Resultado = Numero01 / Numero02;

        }

        public void EscreverResultado()
        {

            Console.WriteLine($"\nResultado da operação de {Operacao}: {Numero01} {Simbolo} {Numero02} = {Resultado}");

        }

        #endregion

    }

}
