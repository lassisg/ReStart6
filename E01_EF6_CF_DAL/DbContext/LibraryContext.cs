using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E01_EF6_CF_DAL
{

    public class LibraryContext : DbContext
    {

        public LibraryContext()
            : base("name=LibraryContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Desativar a pluralidade das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Book> Book { get; set; }

    }

}
