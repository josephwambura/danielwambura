using Microsoft.EntityFrameworkCore;
using DanielWambura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanielWambura.Models.Entities;
using DanielWambura.Models.DawaViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanielWambura.Data
{
    public class DawaDbContext : DbContext
    {
        public DawaDbContext(DbContextOptions<DawaDbContext> options) : base(options)
        {

        }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<VisitorMessage> VisitorMessages { get; set; }

        //The Gallery Model Tables
        public DbSet<DawaImageItem> DawaImageItems { get; set; }
        public DbSet<DawaImageBrand> DawaImageBrands { get; set; }
        public DbSet<DawaImageType> DawaImageTypes { get; set; }
        //The Gallery Model Tables

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactMessage>().ToTable("TblContactMessage");
            modelBuilder.Entity<Feedback>().ToTable("TblFeedback");
            modelBuilder.Entity<VisitorMessage>().ToTable("TblVisitorMessage");

            //modelBuilder.Entity<DawaImageBrand>().ToTable("DawaImageBrand");
            //modelBuilder.Entity<DawaImageType>().ToTable("DawaImageType");
            //modelBuilder.Entity<DawaImageItem>().ToTable("DawaImage");

            //The Gallery Model Tables
            modelBuilder.Entity<DawaImageBrand>(ConfigureDawaImageBrand);
            modelBuilder.Entity<DawaImageType>(ConfigureDawaImageType);
            modelBuilder.Entity<DawaImageItem>(ConfigureDawaImageItem);
            //The Gallery Model Tables

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(modelBuilder);
        }

        void ConfigureDawaImageItem(EntityTypeBuilder<DawaImageItem> modelBuilder)
        {
            modelBuilder.ToTable("DawaImage");

            modelBuilder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("dawaimage_hilo")
                .IsRequired();

            modelBuilder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            modelBuilder.Property(ci => ci.DateTaken)
                .IsRequired(true);

            modelBuilder.Property(ci => ci.PictureUri)
                .IsRequired(false);

            modelBuilder.HasOne(ci => ci.DawaImageBrand)
                .WithMany()
                .HasForeignKey(ci => ci.DawaImageBrandId);

            modelBuilder.HasOne(ci => ci.DawaImageType)
                .WithMany()
                .HasForeignKey(ci => ci.DawaImageTypeId);
        }

        void ConfigureDawaImageBrand(EntityTypeBuilder<DawaImageBrand> modelBuilder)
        {
            modelBuilder.ToTable("DawaImageBrand");

            modelBuilder.HasKey(ci => ci.Id);

            modelBuilder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("dawaimage_brand_hilo")
               .IsRequired();

            modelBuilder.Property(cb => cb.Brand)
                .IsRequired()
                .HasMaxLength(100);
        }

        void ConfigureDawaImageType(EntityTypeBuilder<DawaImageType> modelBuilder)
        {
            modelBuilder.ToTable("DawaImageType");

            modelBuilder.HasKey(ci => ci.Id);

            modelBuilder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("dawaimage_type_hilo")
               .IsRequired();

            modelBuilder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
