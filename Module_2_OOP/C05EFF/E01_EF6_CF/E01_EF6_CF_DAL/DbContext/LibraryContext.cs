using Microsoft.EntityFrameworkCore;

namespace E01_EF6_CF_DAL;

public class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }
    
    public LibraryContext(DbContextOptions<LibraryContext> options) 
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB_EF6CodeFirst");


    public DbSet<Publisher> Publisher { get; set; }

    public DbSet<Book> Book { get; set; }

}