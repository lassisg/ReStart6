namespace D02_Algoritmia;

public static class E05_InscricaoCurso
{

    public static void InscreverCurso01()
    {

        bool programador;
        string curso;

        Console.Write("Sabes programar? (true/false) ");
        programador = Convert.ToBoolean(Console.ReadLine());

        if (programador)
        {
            curso = "C# Foundations";
        }
        else
        {
            curso = "Programming Fundamentals";
        }

        Console.WriteLine($"\nAluno inscrito no curso " + curso);

        Console.ReadLine();

    }

    public static void InscreverCurso02()
    {

        string programador;
        string curso;

        Console.Write("Sabes programar? (S/N) ");
        programador = Console.ReadLine();

        if (programador == "S")
        {
            curso = "C# Foundations";
        }
        else
        {
            curso = "Programming Fundamentals";
        }

        // Console.WriteLine("\nAluno inscrito no curso " + curso);

        // String interpolation
        Console.WriteLine($"\nAluno inscrito no curso {curso}");

        Console.ReadLine();

    }

}