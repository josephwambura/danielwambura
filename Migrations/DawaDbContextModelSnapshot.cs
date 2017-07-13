using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DanielWambura.Data;

namespace DanielWambura.Migrations
{
    [DbContext(typeof(DawaDbContext))]
    partial class DawaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:Sequence:.dawaimage_brand_hilo", "'dawaimage_brand_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:Sequence:.dawaimage_hilo", "'dawaimage_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:Sequence:.dawaimage_type_hilo", "'dawaimage_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DanielWambura.Models.ContactMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("TblContactMessage");
                });

            modelBuilder.Entity("DanielWambura.Models.Entities.DawaImageBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "dawaimage_brand_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("DawaImageBrand");
                });

            modelBuilder.Entity("DanielWambura.Models.Entities.DawaImageItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "dawaimage_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime?>("DateTaken")
                        .IsRequired();

                    b.Property<int>("DawaImageBrandId");

                    b.Property<int>("DawaImageTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PictureUri");

                    b.HasKey("Id");

                    b.HasIndex("DawaImageBrandId");

                    b.HasIndex("DawaImageTypeId");

                    b.ToTable("DawaImage");
                });

            modelBuilder.Entity("DanielWambura.Models.Entities.DawaImageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "dawaimage_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("DawaImageType");
                });

            modelBuilder.Entity("DanielWambura.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("TblFeedback");
                });

            modelBuilder.Entity("DanielWambura.Models.VisitorMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("TblVisitorMessage");
                });

            modelBuilder.Entity("DanielWambura.Models.Entities.DawaImageItem", b =>
                {
                    b.HasOne("DanielWambura.Models.Entities.DawaImageBrand", "DawaImageBrand")
                        .WithMany()
                        .HasForeignKey("DawaImageBrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DanielWambura.Models.Entities.DawaImageType", "DawaImageType")
                        .WithMany()
                        .HasForeignKey("DawaImageTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
