using D00_Utils;
using System;
using System.Linq;

namespace E02_LINQ
{

    internal partial class LINQ
    {

        internal class HelloWorld
        {

            internal static void HelloWorldMethodSyntax()
            {

                Utils.PrintSubHeader("Method Syntax");

                // 1. Array de strings
                string[] words =
                {
                    "t-sql",
                    "hello",
                    "wonderful",
                    "linq",
                    "beautiful",
                    "world"
                };

                // 2. Filtrar palavras de comprimento diferente de 5
                var shortWords = words.Where(word => word.Length == 5);

                // 3. Listar o array filtrado
                foreach (var word in shortWords)
                {
                    Console.WriteLine(word.ToUpper());
                }

            }

            internal static void HelloWorldQuerySyntax()
            {

                Utils.PrintSubHeader("Query Syntax");

                // 1. Array de strings
                string[] words =
                {
                    "t-sql",
                    "hello",
                    "wonderful",
                    "linq",
                    "beautiful",
                    "world"
                };
                
                // 2. Filtrar palavras de comprimento 5
                var shortWords = from word in words
                                 where word.Length == 5
                                 select word;
            
                // 3. Listar o array filtrado
                foreach (var word in shortWords)
                {
                    Console.WriteLine(word.ToUpper());
                }
            }

        }

    }

}
