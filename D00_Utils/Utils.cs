using System;
using System.Collections;
using System.Text;

namespace D00_Utils
{

    public class Utils
    {

        public static void SetUTF8Encoding()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

        }

        public static void PrintHeader(string title, string newLines = "", bool clearConsole = true)
        {

            string border = new string ('-', 70);
            StringBuilder sb = new StringBuilder();

            sb.Append(newLines);
            sb.AppendLine(border);
            sb.AppendLine(title.ToUpper());
            sb.AppendLine(border);

            if (clearConsole)
            {
                Console.Clear();
            }

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

        public static void PrintArrayList(ArrayList arrayList)
        {
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }

    }

}
