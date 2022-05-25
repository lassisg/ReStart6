using System;

namespace E02_NomeCompleto
{

    class Employee
    {

        #region Properties

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        #endregion

        #region Methods

        public void ReadNames()
        {

            Console.Write("Digite seu 1º nome: ");
            FirstName = Console.ReadLine();

            Console.Write("Digite seu nome do meio: ");
            MiddleName = Console.ReadLine();

            Console.Write("Digite seu último nome: ");
            LastName = Console.ReadLine();

        }

        public void CreateFullName()
        {

            FullName = $"{FirstName} {MiddleName} {LastName}";

        }

        public void WriteFullName()
        {

            Console.Write($"\nSeu nome completo é: {FullName}");

        }

        #endregion

    }

}
