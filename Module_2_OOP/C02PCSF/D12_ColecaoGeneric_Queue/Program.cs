using D00_Utils;

Utils.SetUtf8Encoding();

#region Queue

Utils.PrintHeader("Queue");

// Criar um Queue de inteiros
Queue<int> filaInteiros = new Queue<int>();

// Adicionar 1 a 1
filaInteiros.Enqueue(1);
filaInteiros.Enqueue(2);
filaInteiros.Enqueue(3);

// Adicionar 3 valores, duma só vez
for (int i = 4; i < 7; i++)
{
    filaInteiros.Enqueue(i);
}

Console.WriteLine("filaInteiros antes do Dequeuing:");
foreach (int item in filaInteiros)
{
    Console.WriteLine(item);
}

// Eliminar itens da lista e mostrar o item eliminado
Console.WriteLine("\nDequeuing:");
Console.WriteLine($"Dequeuing {filaInteiros.Dequeue()}");   // 1
Console.WriteLine($"Dequeuing {filaInteiros.Dequeue()}");   // 2
Console.WriteLine($"Dequeuing {filaInteiros.Dequeue()}");   // 3

Console.WriteLine("\nfilaInteiros após o Dequeuing:");
foreach (int item in filaInteiros)
{
    Console.WriteLine(item);
}

Utils.CleanConsole();

#endregion