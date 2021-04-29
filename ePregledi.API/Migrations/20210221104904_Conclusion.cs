using Microsoft.EntityFrameworkCore.Migrations;

namespace ePregledi.API.Migrations
{
    public partial class Conclusion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conclusion",
                table: "Examinations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Conclusion",
                table: "Examinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
