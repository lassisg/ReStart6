using D00_Utils;
using System;

namespace D09_Classes
{

    internal class Program
    {

        static void Main(string[] args)
        {

            #region 1º constructor

            Utils.PrintHeader("1º constructor");

            Colaborador colaborador01 = new Colaborador();  // Usa o 1º construtor
            Console.WriteLine($"Nome antes dos Sets: {colaborador01.Nome}\n");

            // Sets
            colaborador01.ColaboradorID = 1;
            colaborador01.Nome = "Ana";
            colaborador01.Email = "ana@mail.com";
            colaborador01.Localidade = "Gaia";

            // Gets
            Console.WriteLine(colaborador01.ColaboradorID);
            Console.WriteLine(colaborador01.Nome);
            Console.WriteLine(colaborador01.Email);
            Console.WriteLine(colaborador01.Localidade);

            Utils.CleanConsole();

            #endregion

            #region 2º constructor

            Utils.PrintHeader("2º constructor");

            Colaborador colaborador02 = new Colaborador(2, "Milena", "milena@mail.com", "Porto");

            // Gets
            Console.WriteLine(colaborador02.ColaboradorID);
            Console.WriteLine(colaborador02.Nome);
            Console.WriteLine(colaborador02.Email);
            Console.WriteLine(colaborador02.Localidade);

            Utils.CleanConsole();

            #endregion

            #region 3º constructor

            Utils.PrintHeader("3º constructor");
            Utils.PrintSubHeader("Usa valor \'default\' de Loacalidade");

            Colaborador colaborador03 = new Colaborador(3, "Amélia", "amelia@mail.com");

            // Gets
            Console.WriteLine(colaborador03.ColaboradorID);
            Console.WriteLine(colaborador03.Nome);
            Console.WriteLine(colaborador03.Email);
            Console.WriteLine(colaborador03.Localidade);

            Utils.PrintSubHeader("Atribuo novo valor de Loacalidade");

            Colaborador colaborador04 = new Colaborador(4, "Reis", "reis@mail.com");
            colaborador04.Localidade = "Braga";

            // Gets
            Console.WriteLine(colaborador04.ColaboradorID);
            Console.WriteLine(colaborador04.Nome);
            Console.WriteLine(colaborador04.Email);
            Console.WriteLine(colaborador04.Localidade);

            Utils.CleanConsole();

            #endregion

        }

    }

}
