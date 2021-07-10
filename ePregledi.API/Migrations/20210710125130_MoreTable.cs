using Microsoft.EntityFrameworkCore.Migrations;

namespace ePregledi.API.Migrations
{
    public partial class MoreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmbulanceId",
                table: "Examinations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ambulance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ambulance_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_AmbulanceId",
                table: "Examinations",
                column: "AmbulanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ambulance_DepartmentId",
                table: "Ambulance",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_RoomId",
                table: "Department",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Ambulance_AmbulanceId",
                table: "Examinations",
                column: "AmbulanceId",
                principalTable: "Ambulance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Ambulance_AmbulanceId",
                table: "Examinations");

            migrationBuilder.DropTable(
                name: "Ambulance");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_AmbulanceId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "AmbulanceId",
                table: "Examinations");
        }
    }
}
