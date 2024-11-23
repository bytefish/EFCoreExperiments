// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EfCoreAudit.Temporal.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreAudit.Temporal.Database
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
            modelBuilder.HasSequence<int>("sq_Person", schema: "Application")
                .StartsAt(1000)
                .IncrementsBy(1);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Application");

                entity.HasKey(e => e.Id)
                  ;

                entity.Property(x => x.Id)
                    .HasColumnType("INT")
                    .HasColumnName("PersonID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Application].[sq_Person]")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FullName)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("FullName")
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("DATETIME2(7)")
                    .HasColumnName("ValidFrom")
                    .IsRequired(false)
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ValidTo)
                    .HasColumnType("DATETIME2(7)")
                    .HasColumnName("ValidTo")
                    .IsRequired(false)
                    .ValueGeneratedOnAddOrUpdate();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
