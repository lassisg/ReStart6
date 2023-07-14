using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_LINQ
{

    internal partial class LINQ
    {

        internal class GreaterOrEqualToTen
        {

            private List<int> listNumbers = new List<int>();

            internal void CreateList()
            {

                Random random = new Random();

                for (int i = 0; i < 10; i++)
			    {
                    int randomNumber = random.Next(0, 50);
                    listNumbers.Add(randomNumber);
			    }

            }

            internal void FilterListMethod()
            {

                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listNumbers.Where(n => n >= 10);

                foreach (var number in filteredList)
                {
                    Console.WriteLine(number);
                }

            }

            internal void FilterListQuery()
            {

                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from number in listNumbers
                                   where number >= 10
                                   select number;

                foreach (var number in filteredList)
                {
                    Console.WriteLine(number);
                }

            }

        }

    }

}
