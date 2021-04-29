using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePregledi.API.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfDocument",
                table: "Diagnoses");

            migrationBuilder.AddColumn<byte[]>(
                name: "PdfDocument",
                table: "Recipes",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfDocument",
                table: "Recipes");

            migrationBuilder.AddColumn<byte[]>(
                name: "PdfDocument",
                table: "Diagnoses",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
