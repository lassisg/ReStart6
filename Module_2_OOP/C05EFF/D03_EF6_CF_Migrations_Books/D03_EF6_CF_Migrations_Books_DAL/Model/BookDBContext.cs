using Microsoft.EntityFrameworkCore;

namespace D03_EF6_CF_Migrations_Books_DAL;

public class BooksDBContext : DbContext
{
    public BooksDBContext()
    {
    }
    public BooksDBContext(DbContextOptions<BooksDBContext> options) 
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BooksDB");

    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<Book> Book { get; set; }
}