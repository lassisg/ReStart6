using System;

namespace D03_EF6_CF_Migrations_Books_Client
{

    internal static class Utility
    {

        internal static void WriteTitle(string text, string initialTerminator = "", string finishTerminator = "")
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{initialTerminator}{text}{finishTerminator}");
            Console.ForegroundColor = ConsoleColor.White;

        }

        internal static void WriteSubtitle(string text, string initialTerminator = "", string finishTerminator = "")
        {

            Console.WriteLine($"{initialTerminator}{text}{finishTerminator}");

        }

    }

}
