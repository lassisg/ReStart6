using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RSGym_DAL
{

    public class GymDbContext : DbContext
    {

        public GymDbContext() : base("RSGymDBContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<User> User { get; set; }

        public DbSet<Trainer> Trainer { get; set; }

        public DbSet<Request> Request { get; set; }

    }

}
