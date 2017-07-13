using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DanielWambura.Migrations
{
    public partial class GallerySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "dawaimage_brand_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "dawaimage_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "dawaimage_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "TblContactMessage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContactMessage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DawaImageBrand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DawaImageBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DawaImageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DawaImageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblFeedback",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFeedback", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblVisitorMessage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVisitorMessage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DawaImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DawaImageBrandId = table.Column<int>(nullable: false),
                    DawaImageTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PictureUri = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DawaImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DawaImage_DawaImageBrand_DawaImageBrandId",
                        column: x => x.DawaImageBrandId,
                        principalTable: "DawaImageBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DawaImage_DawaImageType_DawaImageTypeId",
                        column: x => x.DawaImageTypeId,
                        principalTable: "DawaImageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DawaImage_DawaImageBrandId",
                table: "DawaImage",
                column: "DawaImageBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DawaImage_DawaImageTypeId",
                table: "DawaImage",
                column: "DawaImageTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblContactMessage");

            migrationBuilder.DropTable(
                name: "DawaImage");

            migrationBuilder.DropTable(
                name: "TblFeedback");

            migrationBuilder.DropTable(
                name: "TblVisitorMessage");

            migrationBuilder.DropTable(
                name: "DawaImageBrand");

            migrationBuilder.DropTable(
                name: "DawaImageType");

            migrationBuilder.DropSequence(
                name: "dawaimage_brand_hilo");

            migrationBuilder.DropSequence(
                name: "dawaimage_hilo");

            migrationBuilder.DropSequence(
                name: "dawaimage_type_hilo");
        }
    }
}
