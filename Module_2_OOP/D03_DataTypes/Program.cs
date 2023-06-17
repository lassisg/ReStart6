using D03_DataTypes;

#region 1. Declarar variáveis e instanciar objetos

// Value types
byte idade;
bool inscrito;
double altura;
DateTime data;
DateTime hora;
DateTime agora;     // timestamp
DateTime dataAtual;
DateTime dataVazia;

// Reference types
string nome;

Curso curso01 = new Curso();
Curso curso02 = new Curso();

#endregion

#region 2. Atribuir valores às variáveis e às propriedades

idade = 54;
inscrito = false;
altura = 1.6;

data = new DateTime(2022, 12, 25);
hora = new DateTime(2022, 05, 04, 20, 35, 0);
agora = DateTime.Now;
dataAtual = DateTime.Today;
dataVazia = DateTime.MinValue;

nome = "John Doe";

curso01.Nome = "C# Foundations";
curso01.DataInicio = new DateTime(2022, 05, 03);

curso02.CursoID = 2;
curso02.numeroHoras = 30;

#endregion

#region 3. Lista as variáveis e as propriedades da classe

Console.WriteLine($"Byte: {idade}");
Console.WriteLine($"Boolean: {inscrito}");
Console.WriteLine($"Double: {altura}");

Console.WriteLine($"\nDateTime - date: {data}");
Console.WriteLine($"DateTime - short date: {data.ToShortDateString()}");
Console.WriteLine($"DateTime - long date: {data.ToLongDateString()}");
Console.WriteLine($"DateTime - time: {hora}");
Console.WriteLine($"DateTime - short time: {hora.ToShortTimeString()}");
Console.WriteLine($"DateTime - long time: {hora.ToLongTimeString()}");
Console.WriteLine($"DateTime - timestamp: {agora}");
Console.WriteLine($"DateTime - today: {dataAtual}");
Console.WriteLine($"DateTime - empty: {dataVazia}");

Console.WriteLine($"\nString: {nome}");

Console.WriteLine($"\nAno atual: {agora.Year}");
Console.WriteLine($"Mês atual: {agora.Month}");
Console.WriteLine($"Dia atual: {dataAtual.Day}");
Console.WriteLine($"Hora atual: {agora.Hour}");
Console.WriteLine($"Minuto atual: {agora.Minute}");
Console.WriteLine($"Segundo atual: {agora.Second}");

Console.WriteLine($"\nCurso 01 - mome: {curso01.Nome}");
Console.WriteLine($"Curso 01 - data de início: {curso01.DataInicio.ToShortDateString()}");
Console.WriteLine($"Curso 02 - ID: {curso02.CursoID}");
Console.WriteLine($"Curso 02 - nº horas: {curso02.numeroHoras}");

#endregion

Console.ReadLine();