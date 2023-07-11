namespace D02_Algoritmia;

public static class E01_MediaAritmetica
{
    public static void CalcularMediaAritmetica()
    {
        // 1. Declarar variáveis (camelCase)          
        double nota01, nota02, media;

        // 2. Manipular a 1ª nota
        Console.Write("Nota 1: ");
        // Atribuir a um double o que vem da consola (string), convertendo com Convert
        nota01 = Convert.ToDouble(Console.ReadLine());

        // 3. Manipular a 2ª nota
        Console.Write("Nota 2: ");
        nota02 = Convert.ToDouble(Console.ReadLine());

        // 4. Calcular a média
        media = (nota01 + nota02) / 2;

        // Mostrar a média
        Console.WriteLine("\nMédia: " + Convert.ToString(media));
        Console.WriteLine();

        // 6. Avaliar a média
        if (media >= 9.5) // true
            Console.WriteLine("Aprovado!");
        else // false
            Console.WriteLine("Reprovado!");

        // 7. Pausar a consola
        Console.ReadLine();
    }
}
