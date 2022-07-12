using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E01_EF6_CF
{

    internal class LibraryContext : DbContext
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

    }

}
