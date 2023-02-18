using System;

namespace D02_Algoritmia
{
    public static class E02_MaiorIdade
    {

        public static void AnalisarMaioridade01()
        {

            int idade;

            Console.Write("Idade: ");
            idade = Convert.ToInt16(Console.ReadLine());

            if (idade >= 18)
            {
                Console.WriteLine($"\nA tua idade é {idade} anos. És maior de idade.");
            }
            else
            {
                Console.WriteLine($"\nA tua idade é {idade} anos. És menor de idade.");
            }

            Console.ReadLine();

        }

        public static void AnalisarMaioridade02()
        {

            int idade;

            Console.Write("Idade: ");
            idade = Convert.ToInt16(Console.ReadLine());

            if (idade >= 18)
            {
                Console.WriteLine($"\nA tua idade é {idade} anos. És maior de idade.");
            }
            else
            {
                Console.WriteLine($"\nA tua idade é {idade} anos. És menor de idade.");
            }

            Console.ReadLine();
            
        }

    }

}
