using System;
using System.Text;

namespace D07_EstruturasCiclicas
{

    public static class Utils
    {

        public static void PrintHeader(string title, string newLines = "")
        {

            string border = "----------------------------------------------------------------------";
            StringBuilder sb = new StringBuilder();

            sb.Append(newLines);
            sb.AppendLine(border);
            sb.AppendLine(title);
            sb.AppendLine(border);

            Console.Write(sb.ToString());

        }

    }

}
