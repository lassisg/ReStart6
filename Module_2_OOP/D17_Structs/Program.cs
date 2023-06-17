#region Struct Book
Book book01;
Book book02;

book01.BookId = 1;
book01.Title = "C#";
book01.Author = "Xpto";

book02.BookId = 2;
book02.Title = "OOP";
book02.Author = "Qaz";

Console.WriteLine("Book nº 1: {0} - {1}, {2}", book01.BookId, book01.Title, book01.Author);
Console.WriteLine("\nBook nº 2: {0} - {1}, {2}", book02.BookId, book02.Title, book02.Author);
#endregion

struct Book
{
    public int BookId;
    public string Title;
    public string Author;
};