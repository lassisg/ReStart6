using Microsoft.EntityFrameworkCore;

namespace D02_EF6_CF;

internal class BlogContext : DbContext
{

    public BlogContext()
    {
    }
    public BlogContext(DbContextOptions<BlogContext> options) 
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Blog");

    public DbSet<Blog> Blog { get; set; }
    public DbSet<Post> Post { get; set; }

}