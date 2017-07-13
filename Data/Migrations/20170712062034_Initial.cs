using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielWambura.Data.Migrations
{
    public partial class Initial : Migration
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
                name: "DawaImage");

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
