#region Variáveis

string s1 = "1";
string s2 = "2";
int i1 = 10;
int i2 = 20;
long l1 = 2000000;
double d1 = 10.5;
float f1 = 30.5F;

#endregion

#region Operações sem conversão

Console.WriteLine(s1 + i1);     // 110, 11 ???  --> 110 (concatenou)

#endregion

#region Conversão implícita

Console.WriteLine("");
Console.WriteLine(i2 + l1);     // 2000020
Console.WriteLine(d1 + f1);     // 41

#endregion

#region Conversão explícita

Console.WriteLine("");

// ToString() method: data type extension method
Console.WriteLine(s2 + i2.ToString());          // 220

// Convert class: métodos de conversão dos diferentes tipos de dados
Console.WriteLine(Convert.ToInt16(s2) + i2);    // 22

// Parse() method: método do tipo de dado para converter um numero em string
Console.WriteLine(i1 + int.Parse(s1));
Console.WriteLine(l1 + long.Parse(s1));
Console.WriteLine(d1 + double.Parse(s1));       // 11.5
Console.WriteLine(f1 + float.Parse(s1));

// Cast operator: para numéricos
Console.WriteLine((long)i2 + l1);               // 2000020
Console.WriteLine((double)f1 + d1);             // 41
// Console.WriteLine((string)f1 + s1);             // ERROR. Não pode!!!

#endregion

Console.ReadLine();