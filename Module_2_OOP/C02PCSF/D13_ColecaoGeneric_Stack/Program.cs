using D00_Utils;

Utils.SetUtf8Encoding();

#region Stack

Utils.PrintHeader("Stack");

// Criar ums Stack de inteiros
Stack<int> pilhaInteiros = new Stack<int>();

// Adicionar 1 a 1
pilhaInteiros.Push(1);
pilhaInteiros.Push(2);
pilhaInteiros.Push(3);

// Adicionar 3 valores, duma só vez
for (int i = 4; i < 7; i++)
{
    pilhaInteiros.Push(i);
}

Console.WriteLine("pilhaInteiros antes do Dequeuing:");
foreach (int item in pilhaInteiros)
{
    Console.WriteLine(item);
}

// Eliminar itens da lista e mostrar o item eliminado
Console.WriteLine("\nPoping:");
Console.WriteLine($"Poping {pilhaInteiros.Pop()}");   // 6
Console.WriteLine($"Poping {pilhaInteiros.Pop()}");   // 5
Console.WriteLine($"Poping {pilhaInteiros.Pop()}");   // 4

Console.WriteLine("\npilhaInteiros após o Dequeuing:");
foreach (int item in pilhaInteiros)
{
    Console.WriteLine(item);
}

Utils.CleanConsole();

#endregion