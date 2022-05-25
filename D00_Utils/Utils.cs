using System;
using System.Text;

namespace D00_Utils
{

    public class Utils
    {

        public static void PrintHeader(string title, string newLines = "")
        {

            string border = new string ('-', 70);
            StringBuilder sb = new StringBuilder();

            sb.Append(newLines);
            sb.AppendLine(border);
            sb.AppendLine(title.ToUpper());
            sb.AppendLine(border);

            Console.Clear();
            Console.Write(sb.ToString());

        }

        public static void PrintSubHeader(string subTitle)
        {

            Console.WriteLine($"\n{subTitle}");
            Console.WriteLine(new string('-', 43));

        }

        public static void CleanConsole()
        {

            Console.ReadLine();
            Console.Clear();

        }

    }

}
