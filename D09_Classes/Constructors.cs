using System;
using D00_Utils;

namespace D09_Classes
{

    internal class Constructors
    {

        #region Fields: variáveis privadas à classe que suportam as propriedades clássicas

        private string nome;

        #endregion

        #region Properties

        // Propriedades auto-implemented
        public int ColaboradorID { get; set; }
        public string Email { get; set; }
        public string Localidade { get; set; }

        // Propriedades clássicas
        public string Nome          // usa-se o correspondente field/atributo
        { 
            get { return nome; }
            set { nome = value; }
        }

        // Expression bodied: Avançado, não utilizaremos
        // public string LastName => "Nome";

        #endregion

        #region Constructors

        public Constructors()
        {
            ColaboradorID = 0;
            Nome = "";
            Email = "";
            Localidade = string.Empty;
        }

        public Constructors(int colaboradorID, string nome, string email)
        {
            ColaboradorID = colaboradorID;
            Nome = nome;
            Email = email;
            Localidade = "Porto";
        }

        public Constructors(int colaboradorID, string nome, string email, string localidade)
        {
            ColaboradorID= colaboradorID;
            Nome = nome;
            Email = email;
            Localidade = localidade;
        }

        #endregion

        #region Methods

        public static void ConstructorsCall()
        {

            #region 1º constructor

            Utils4.PrintHeader("1º constructor");

            Constructors colaborador01 = new Constructors();  // Usa o 1º construtor
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

            Utils4.CleanConsole();

            #endregion

            #region 2º constructor

            Utils4.PrintHeader("2º constructor");

            Constructors colaborador02 = new Constructors(2, "Milena", "milena@mail.com", "Porto");

            // Gets
            Console.WriteLine(colaborador02.ColaboradorID);
            Console.WriteLine(colaborador02.Nome);
            Console.WriteLine(colaborador02.Email);
            Console.WriteLine(colaborador02.Localidade);

            Utils4.CleanConsole();

            #endregion

            #region 3º constructor

            Utils4.PrintHeader("3º constructor");
            Utils4.PrintSubHeader("Usa valor \'default\' de Loacalidade");

            Constructors colaborador03 = new Constructors(3, "Amélia", "amelia@mail.com");

            // Gets
            Console.WriteLine(colaborador03.ColaboradorID);
            Console.WriteLine(colaborador03.Nome);
            Console.WriteLine(colaborador03.Email);
            Console.WriteLine(colaborador03.Localidade);

            Utils4.PrintSubHeader("Atribuo novo valor de Loacalidade");

            Constructors colaborador04 = new Constructors(4, "Reis", "reis@mail.com");
            colaborador04.Localidade = "Braga";

            // Gets
            Console.WriteLine(colaborador04.ColaboradorID);
            Console.WriteLine(colaborador04.Nome);
            Console.WriteLine(colaborador04.Email);
            Console.WriteLine(colaborador04.Localidade);

            Utils4.CleanConsole();

            #endregion

        }

        #endregion

    }

}
