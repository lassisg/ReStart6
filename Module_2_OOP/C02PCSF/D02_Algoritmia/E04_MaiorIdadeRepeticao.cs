namespace D02_Algoritmia;

public static  class E04_MaiorIdadeRepeticao
{

    public static void AnalisarMaioridade()
    {

        int idade;

        Console.Write("Digite sua idade: ");
        idade = Convert.ToInt16(Console.ReadLine());

        while (idade >= 18)
        {
            Console.WriteLine($"\nTens {idade} anos. És maior de idade");

            Console.Write("\nDigite sua idade: ");
            idade = Convert.ToInt16(Console.ReadLine());
        }

        Console.WriteLine($"\nTens {idade} anos. És menor de idade");

        Console.ReadLine();

    }

}