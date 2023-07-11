namespace D02_Algoritmia;

public static class E03_MaiorNumero
{
    public static void CalcularMaiorNumero()
    {
        double numero01;
        double numero02;

        Console.Write("Numero 1: ");
        numero01 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Numero 2: ");
        numero02 = Convert.ToDouble(Console.ReadLine());

        if (numero01 > numero02)
        {
            Console.WriteLine($"\nNúmero 1 ({numero01}) é maior que o número 2 ({numero02}).");
        }
        else
        {
            if (numero02 > numero01)
                Console.WriteLine($"\nNúmero 2 ({numero02}) é maior que o número 1 ({numero01}).");
            else
                Console.WriteLine($"\nOs números {numero01} {numero02} são iguais.");
        }

        Console.ReadLine();
    }
}