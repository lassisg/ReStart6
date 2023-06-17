using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_LINQ
{

    internal partial class LINQ
    {

        internal class ExtensionMethods
        {
    
            internal void UseExtentionMethodConcatenar()
            {
                string hello = "Hello";
                string world = "World";

                string helloWorld = hello.Concatenar(world, ", ");
                Console.WriteLine(helloWorld);
            }

            internal void UseExtentionMethodFormatarParaEuro()
            {
                
                Random rand = new Random();
                var number = 10 * rand.NextDouble();

                string numberInEuro = number.ToString().FormatarParaEuro(0);
                Console.WriteLine(numberInEuro);
            }

        }

    }

    internal static class ExtensionHelper
    {

        internal static string Concatenar(this string firstString, string secondString, string separator = " ")
        {
            string merged = $"{firstString}{separator}{secondString}";
            return merged;
        }

        internal static string FormatarParaEuro(this string firstString, int posicaoSimbolo = 3)
        {
            NumberFormatInfo numberInfo = NumberFormatInfo.CurrentInfo.Clone() as NumberFormatInfo;
            numberInfo.CurrencyPositivePattern = posicaoSimbolo;

            var res = double.TryParse(firstString, out double stringValue);
            string result = stringValue.ToString("C", numberInfo);

            return result;
        }

    }

}
