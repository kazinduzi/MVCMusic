using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GigHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("MyDefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Gig> Gigs { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Following> Followings { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany()
                .WillCascadeOnDelete(false);
           
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(f => f.Followees)
                .WithRequired(f => f.Follower)                
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(f => f.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

        }
    }
}