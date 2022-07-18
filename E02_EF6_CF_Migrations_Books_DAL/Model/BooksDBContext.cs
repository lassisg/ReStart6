using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E02_EF6_CF_Migrations_Books_DAL
{

    public class BooksDBContext : DbContext
    {

        public BooksDBContext()
            : base("BooksDBConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Book> Book { get; set; }

    }

}
