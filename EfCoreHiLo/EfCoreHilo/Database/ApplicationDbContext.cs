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
            // User
            modelBuilder.HasSequence<int>("sq_User", schema: "Application")
                .StartsAt(38187)
                .IncrementsBy(1);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Application");

                entity.HasKey(e => e.Id);

                entity.Property(x => x.Id)
                    .HasColumnType("INT")
                    .HasColumnName("UserID")
                    .UseHiLo("sq_User", "Application")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FullName)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("FullName")
                    .IsRequired(true)
                    .HasMaxLength(50);

                entity.Property(e => e.PreferredName)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("PreferredName")
                    .IsRequired(true)
                    .HasMaxLength(50);
                
                entity.Property(e => e.PreferredName)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("PreferredName")
                    .IsRequired(true)
                    .HasMaxLength(50);

                entity.Property(e => e.IsPermittedToLogon)
                    .HasColumnType("BIT")
                    .HasColumnName("IsPermittedToLogon")
                    .IsRequired(true)
                    .HasMaxLength(50);

                entity.Property(e => e.LogonName)
                    .HasColumnType("NVARCHAR(256)")
                    .HasColumnName("LogonName")
                    .IsRequired(false)
                    .HasMaxLength(50);

                entity.Property(e => e.HashedPassword)
                    .HasColumnType("NVARCHAR(MAX)")
                    .HasColumnName("HashedPassword")
                    .IsRequired(false);

                entity.Property(e => e.RowVersion)
                    .HasColumnType("ROWVERSION")
                    .HasColumnName("RowVersion")
                    .IsRequired(false)
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

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

                entity.Property(e => e.LastEditedBy)
                    .HasColumnType("INT")
                    .HasColumnName("LastEditedBy")
                    .IsRequired(true);
            });


            // Person
            modelBuilder.HasSequence<int>("sq_Person", schema: "Application")
                .StartsAt(38187)
                .IncrementsBy(1);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Application");

                entity.HasKey(e => e.Id);

                entity.Property(x => x.Id)
                    .HasColumnType("INT")
                    .HasColumnName("PersonID")
                    .UseHiLo("sq_Person", "Application")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FullName)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("FullName")
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.PreferredName)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("PreferredName")
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("PreferredName")
                    .IsRequired(false)
                    .HasMaxLength(255);

                entity.Property(e => e.FullName)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("Name")
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.RowVersion)
                    .HasColumnType("ROWVERSION")
                    .HasColumnName("RowVersion")
                    .IsRequired(false)
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

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

                entity.Property(e => e.LastEditedBy)
                    .HasColumnType("INT")
                    .HasColumnName("LastEditedBy")
                    .IsRequired(true);
            });

            // Address
            modelBuilder.HasSequence<int>("sq_Address", schema: "Application")
                .StartsAt(38187)
                .IncrementsBy(1);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Application");

                entity.HasKey(e => e.Id);

                entity.Property(x => x.Id)
                    .HasColumnType("INT")
                    .HasColumnName("AddressID")
                    .UseHiLo("sq_Address", "Application")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddressLine1)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("AddressLine1")
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.AddressLine2)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("AddressLine2")
                    .IsRequired(true)
                    .HasMaxLength(255);
                
                entity.Property(e => e.PostalCode)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("PostalCode")
                    .IsRequired(false)
                    .HasMaxLength(255);
                
                entity.Property(e => e.City)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("PostalCode")
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.RowVersion)
                    .HasColumnType("ROWVERSION")
                    .HasColumnName("RowVersion")
                    .IsRequired(false)
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

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

                entity.Property(e => e.LastEditedBy)
                    .HasColumnType("INT")
                    .HasColumnName("LastEditedBy")
                    .IsRequired(true);
            });
            
            // AddressType
            modelBuilder.HasSequence<int>("sq_AddressType", schema: "Application")
                .StartsAt(38187)
                .IncrementsBy(1);

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.ToTable("AddressType", "Application");

                entity.HasKey(e => e.Id);

                entity.Property(x => x.Id)
                    .HasColumnType("INT")
                    .HasColumnName("AddressTypeID")
                    .UseHiLo("sq_AddressType", "Application")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnType("NVARCHAR(255)")
                    .HasColumnName("Name")
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.RowVersion)
                    .HasColumnType("ROWVERSION")
                    .HasColumnName("RowVersion")
                    .IsRequired(false)
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

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

                entity.Property(e => e.LastEditedBy)
                    .HasColumnType("INT")
                    .HasColumnName("LastEditedBy")
                    .IsRequired(true);
            });


            // AddressType
            modelBuilder.HasSequence<int>("sq_PersonAddress", schema: "Application")
                .StartsAt(38187)
                .IncrementsBy(1);

            modelBuilder.Entity<PersonAddress>(entity =>
            {
                entity.ToTable("PersonAddress", "Application");

                entity.HasKey(e => e.Id);

                entity.Property(x => x.Id)
                    .HasColumnType("INT")
                    .HasColumnName("PersonAddressID")
                    .UseHiLo("sq_PersonAddress", "Application")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonId)
                    .HasColumnType("INT")
                    .HasColumnName("PersonID")
                    .IsRequired(true)
                    .HasMaxLength(255);
                
                entity.Property(e => e.AddressId)
                    .HasColumnType("INT")
                    .HasColumnName("AddressID")
                    .IsRequired(true)
                    .HasMaxLength(255);
                
                entity.Property(e => e.AddressType)
                    .HasColumnType("INT")
                    .HasColumnName("AddressTypeID")
                    .HasConversion(v => (int)v, v => (AddressTypeEnum)v) // Maps between the Enumeration and Integer
                    .IsRequired(true)
                    .HasMaxLength(255);

                entity.Property(e => e.RowVersion)
                    .HasColumnType("ROWVERSION")
                    .HasColumnName("RowVersion")
                    .IsRequired(false)
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

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

                entity.Property(e => e.LastEditedBy)
                    .HasColumnType("INT")
                    .HasColumnName("LastEditedBy")
                    .IsRequired(true);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
