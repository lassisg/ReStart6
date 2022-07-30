namespace RSGym_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RSGym_DAL.GymDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RSGym_DAL.GymDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.User.AddOrUpdate(
              p => p.Username,
              new User { Username = "leandro", Password = "pass" },
              new User { Username = "milena", Password = "12345" }
            );

            context.Trainner.AddOrUpdate(
              t => t.Code,
              new Trainner { Code = "PT_01", Name = "José Maria" },
              new Trainner { Code = "PT_02", Name = "Maria José" },
              new Trainner { Code = "PT_03", Name = "Luis Miguel" }
            );

        }
    }
}
