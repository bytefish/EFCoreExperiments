// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EfCoreAudit.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreAudit.Context
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("PersonID", schema: "Sequences")
                .StartsAt(1000)
                .IncrementsBy(1);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Application");

                entity.HasKey(e => e.Id)
                  ;

                entity.Property(x => x.Id)
                    .HasColumnType("INT")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[PersonID]")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FullName)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("FullName")
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("DATETIME2(7)")
                    .HasColumnName("CreatedDateTime")
                    .IsRequired(false);

                entity.Property(e => e.ModifiedDateTime)
                    .HasColumnType("DATETIME2(7)")
                    .HasColumnName("ModifiedDateTime")
                    .IsRequired(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
