using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            /*Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }

        public DbSet<Membership> memberships { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Publication> publications { get; set; }

        public DbSet<Subscriber> subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Publication>().HasMany<Category>(s => s.Categories).WithMany(c => c.Publications).UsingEntity(e => e.ToTable("PublicationCategoryRelations"));
            builder.Entity<Publication>().Property(e => e.TotalViews).HasDefaultValue(1);
            builder.Entity<Publication>().Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Entity<Subscriber>().Property(e => e.Date).HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(builder);
        }
    }
}
