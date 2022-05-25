using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09_Classes
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Colaborador c = new Colaborador();
            Console.WriteLine(c.Nome);

            // sets
            c.ColaboradorID = 1;
            c.Nome = "L";

            // gets
            Console.WriteLine(c.ColaboradorID);
            Console.WriteLine(c.Nome);

            Console.ReadLine();

        }

    }

}
