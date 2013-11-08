using System.Data.Entity;
using TvArchiving.Domain.Entities;

namespace TvArchiving.Domain
{
    public class TvArchivingDbContext : DbContext
    {
        public TvArchivingDbContext() : base("TvArchivingDbContext") { }


        public virtual IDbSet<Shot> Shots { get; set; }
        public virtual IDbSet<Tag> Tags { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<VideoFile> VideoFiles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shot>().Property(p => p.ThumbnailImage).HasColumnType("image");

        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
