using System;
using System.Text;

namespace D05_ManipulacaoDados
{

    internal class Program
    {

        static void Main(string[] args)
        {

            #region Variáveis e objetos

            string area = "Informática";
            string categoria = "Linguagem de programação";
            string curso = "Microsoft C# Iniciação";
            // string cursoCompleto1, cursoCompleto2;
            string cursoCompleto1 = String.Join("; ", area, categoria, curso);
            string cursoCompleto2 = String.Concat(area, "/", categoria, "-", curso);


            StringBuilder sb01 = new StringBuilder();     // overload
            sb01.Append(area);
            sb01.Append(" ");
            sb01.Append(categoria);
            sb01.Append(" ");
            sb01.Append(curso);
            

            int valor01 = 10;
            int valor02 = 100;
            double valor03 = 2.3;
            double valor04 = -12.1;

            DateTime timestamp = DateTime.Now;

            #endregion

            #region Manipulação strings

            Utils.PrintHeader("STRING");

            Console.WriteLine($"Curso em maiusculas: {curso.ToUpper()}");
            Console.WriteLine($"1ª palavra do curso: {curso.Substring(0, 9)}");
            Console.WriteLine($"String join: {cursoCompleto1}");
            Console.WriteLine($"String concat: {cursoCompleto2}");

            #endregion

            #region Manipulação strings - StringBuilder

            Utils.PrintHeader("STRING BUILDER", "\n\n");

            Console.WriteLine($"StringBuilder: {sb01}");

            #endregion

            #region Manipulação numérica

            Utils.PrintHeader("NUMBER - MATH()", "\n\n");

            Console.WriteLine($"Valor mínimo: {Math.Min(valor02, valor01)}");
            Console.WriteLine($"Valor máximo: {Math.Max(valor02, valor01)}");
            Console.WriteLine($"Valor absoluto: {Math.Abs(valor04)}");
            Console.WriteLine($"Valor arredondado: {Math.Round(valor03)}");
            Console.WriteLine($"Raiz quadrada de 64: {Math.Sqrt(64)}");

            #endregion

            #region Manipulação Datetime

            Utils.PrintHeader("DATETIME", "\n\n");

            Console.WriteLine($"Hora atual + 10 min: {timestamp.AddMinutes(10).Minute}");
            Console.WriteLine($"Hora atual + 10 min: {timestamp.AddMinutes(10).ToString("mm")}");
            Console.WriteLine($"Hora atual + 10 min: {timestamp.AddMinutes(10):mm}");
            Console.WriteLine($"Hora futura: {timestamp.AddHours(1).Hour}");

            #endregion

            Console.ReadLine();

        }

    }

}
