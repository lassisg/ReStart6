using System;

namespace D06_EstruturasCondicionais
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
