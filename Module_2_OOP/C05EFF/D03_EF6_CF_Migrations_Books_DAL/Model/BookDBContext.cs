using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace D03_EF6_CF_Migrations_Books_DAL
{

    public class BooksDBContext : DbContext
    {

        public BooksDBContext() : base("BooksDBContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BooksDBContext>());
        }

        // DbModelBuilder --> atua como a Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book> Book { get; set; }

    }

}
