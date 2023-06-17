using D00_Utils;

Utils.PrintHeader("LINQ");

#region Query Syntax

Utils.PrintSubHeader("Query Syntax");

List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// Query #1.
// IEnumerable --> interface
IEnumerable<int> filteringQuery =
    from num in numbers
    where num < 3 || num >= 7
    select num;

foreach (var item in filteringQuery)
{
    Console.WriteLine(item);
}

Console.WriteLine();

// Query #2.
var orderingQuery =
    from num in numbers
    where num < 3 || num > 7
    orderby num ascending
    select num;

foreach (var item in orderingQuery)
{
    Console.WriteLine(item);
}
            
Utils.CleanConsole();

#endregion

#region Method Syntax

Utils.PrintSubHeader("Method Syntax");

List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };

// Query #3.
double average = numbers1.Average();

Console.WriteLine(average);

Console.WriteLine();

// Query #4.
IEnumerable<int> numbersConcatenated = numbers1.Concat(numbers2);

foreach (var item in numbersConcatenated)
{
    Console.WriteLine(item);
}

Console.WriteLine();

// Query #5.
var numbersGreaterThan15 = numbers2.Where(c => c > 15).OrderBy(c => c);

foreach (var item in numbersGreaterThan15)
{
    Console.WriteLine(item);
}

Utils.CleanConsole();

#endregion