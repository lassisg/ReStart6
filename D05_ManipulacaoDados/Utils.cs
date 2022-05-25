using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05_ManipulacaoDados
{

    public static class Utils
    {

        public static void PrintHeader(string title, string newLines = "")
        {

            Console.WriteLine($"{newLines}----------------------------------------------------------------------");
            Console.WriteLine($"{title}");
            Console.WriteLine("----------------------------------------------------------------------");

        }

    }

}
