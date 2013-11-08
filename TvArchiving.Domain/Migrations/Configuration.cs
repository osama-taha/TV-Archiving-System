using TvArchiving.Domain.Entities;

namespace TvArchiving.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TvArchiving.Domain.TvArchivingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TvArchiving.Domain.TvArchivingDbContext context)
        {
            context.Categories.AddOrUpdate(
              p => p.Name,
              new Category() { Name = "Sport" },
              new Category() { Name = "Drama" },
              new Category() { Name = "Songs" },
              new Category() { Name = "History" },
              new Category() { Name = "News" },
              new Category() { Name = "Arts" }
            );
            
        }
    }
}
