using Microsoft.EntityFrameworkCore.Migrations;

namespace ePregledi.API.Migrations
{
    public partial class MoreTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ambulance_Department_DepartmentId",
                table: "Ambulance");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Room_RoomId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_RoomId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Ambulance_DepartmentId",
                table: "Ambulance");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Ambulance");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Examinations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Examinations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_DepartmentId",
                table: "Examinations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_RoomId",
                table: "Examinations",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Department_DepartmentId",
                table: "Examinations",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Room_RoomId",
                table: "Examinations",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Department_DepartmentId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Room_RoomId",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_DepartmentId",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_RoomId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Examinations");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Ambulance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Department_RoomId",
                table: "Department",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Ambulance_DepartmentId",
                table: "Ambulance",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ambulance_Department_DepartmentId",
                table: "Ambulance",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Room_RoomId",
                table: "Department",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
