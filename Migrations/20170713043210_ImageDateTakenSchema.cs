using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DanielWambura.Migrations
{
    public partial class ImageDateTakenSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "DawaImage");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTaken",
                table: "DawaImage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTaken",
                table: "DawaImage");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "DawaImage",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
