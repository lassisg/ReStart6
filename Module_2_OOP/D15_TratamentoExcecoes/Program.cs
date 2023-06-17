using D00_Utils;

Utils.SetUtf8Encoding();

#region Try... Catch...Finally

Utils.PrintHeader("Try... Catch...Finally");

try
{

    int valor01, valor02;
    string texto;

    valor01 = 10;
    valor02 = 0;
    texto = "Erro";

    Console.WriteLine(10 / 2);

    // Console.WriteLine(10 / 0);   // Erro de sintaxe!!! Mas com variáveis é possível contornar

    Console.WriteLine(valor01 * int.Parse(texto));          // System.FormatException

    //Console.WriteLine(valor01 * Convert.ToInt16(texto));    // System.FormatException

    Console.WriteLine(valor01 / valor02);   // Exception: System.DivideByZeroException

    Console.WriteLine(valor01 * valor02);   // 0

}
catch (FormatException)
{
    Console.WriteLine("Erro! Formato errado!");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Erro! Divisão por zero!");
}
catch (Exception)
{
    Console.WriteLine("Erro!");
    // throw;    // Útil para saber o tipo de erro
}
finally
{
                
    Utils.CleanConsole();

}

#endregion