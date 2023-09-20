using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Core.Entities;

namespace Smartwyre.DeveloperTest.Core
{
    public class SWContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<RebateEntity> Rebates { get; set; }

        public SWContext(DbContextOptions<SWContext> options)
                : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uom)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<RebateEntity>(entity =>
            {
                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasKey(e => e.Identifier);
            });
        }
    }
}
