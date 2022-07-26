using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public class GymDbContext : DbContext
    {

        public GymDbContext()
            : base("RSGymDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Status> Status { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Trainner> Trainner { get; set; }

        public DbSet<Request> Request { get; set; }

    }

}
