using Microsoft.EntityFrameworkCore.Migrations;

namespace ePregledi.API.Migrations
{
    public partial class AddedDepartmentIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Referrals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_DepartmentId",
                table: "Referrals",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Referrals_Department_DepartmentId",
                table: "Referrals",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Referrals_Department_DepartmentId",
                table: "Referrals");

            migrationBuilder.DropIndex(
                name: "IX_Referrals_DepartmentId",
                table: "Referrals");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Referrals");
        }
    }
}
