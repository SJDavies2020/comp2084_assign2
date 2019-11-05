using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assign1.Models
{
    public partial class Assign1Context : IdentityDbContext <ApplicationUser, ApplicationRole, string>
    {
        public Assign1Context()
        {
        }

        public Assign1Context(DbContextOptions<Assign1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cmake> Cmake { get; set; }
        public virtual DbSet<Cmodel> Cmodel { get; set; }
        public virtual DbSet<Cutomers> Cutomers { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Warrenty> Warrenty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=comp2084a1.database.windows.net;Initial Catalog=Assign1;Persist Security Info=True;User ID=stevenjdavies2013;Password=Bonnied029$");
         }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add for bug fix in identity.
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cmake>(entity =>
            {
                entity.Property(e => e.CarMake).IsUnicode(false);
            });

            modelBuilder.Entity<Cmodel>(entity =>
            {
                entity.Property(e => e.CarModel).IsUnicode(false);
            });

            modelBuilder.Entity<Cutomers>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.CarYear).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.VIN).IsUnicode(false);

                entity.HasOne(d => d.CarMake)
                    .WithMany(p => p.Cutomers)
                    .HasForeignKey(d => d.CarMakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cutomers_CMake");

                entity.HasOne(d => d.CarModel)
                    .WithMany(p => p.Cutomers)
                    .HasForeignKey(d => d.CarModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cutomers_CModel");

                entity.HasOne(d => d.Prov)
                    .WithMany(p => p.Cutomers)
                    .HasForeignKey(d => d.ProvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cutomers_Province");

                entity.HasOne(d => d.Warrenty)
                    .WithMany(p => p.Cutomers)
                    .HasForeignKey(d => d.WarrentyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cutomers_Warrenty");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Province1).IsUnicode(false);
            });

            modelBuilder.Entity<Warrenty>(entity =>
            {
                entity.Property(e => e.WarrentyTerm).IsUnicode(false);
            });
        }
    }
}
