using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_LINQ
{

    internal partial class LINQ
    {

        internal class ShorterNames
        {

            private List<string> listNames;

            internal void CreateList()
            {

                listNames = new List<string>()
                {
                    "João",
                    "Pedro",
                    "António",
                    "Maria",
                    "Carlos",
                    "Mateus",
                    "José"
                };

            }

            internal void FilterListQuery()
            {

                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from name in listNames
                                   where name.Length == (
                                       from name2 in listNames
                                       orderby name2.Length 
                                       select name2.Length).First()
                                   select name;

                WriteList(filteredList);

            }

            internal void FilterListMethod()
            {

                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listNames
                    .Where(n => n.Length == listNames
                    .OrderBy(n2 => n2.Length)
                    .Select(n2 => n2.Length).First());

                WriteList(filteredList);

            }

            private void WriteList(IEnumerable<string> filteredList)
            {
                foreach (var item in filteredList)
                {
                    Console.WriteLine(item);
                }
            }

        }

    }

}
