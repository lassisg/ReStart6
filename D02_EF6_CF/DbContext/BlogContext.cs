using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF
{

    internal class BlogContext : DbContext
    {

        public BlogContext() 
            : base("name=BlogContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Desativar a pluralidade das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }

    }

}
