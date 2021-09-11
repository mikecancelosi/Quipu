using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class RemovedEnumsForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "PriorityID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriorityID",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PriorityType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityID",
                table: "Tasks",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusID",
                table: "Tasks",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PriorityID",
                table: "Projects",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusID",
                table: "Projects",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_PriorityType_PriorityID",
                table: "Projects",
                column: "PriorityID",
                principalTable: "PriorityType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_StatusType_StatusID",
                table: "Projects",
                column: "StatusID",
                principalTable: "StatusType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_PriorityType_PriorityID",
                table: "Tasks",
                column: "PriorityID",
                principalTable: "PriorityType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusType_StatusID",
                table: "Tasks",
                column: "StatusID",
                principalTable: "StatusType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PriorityType_PriorityID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_StatusType_StatusID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_PriorityType_PriorityID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusType_StatusID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "PriorityType");

            migrationBuilder.DropTable(
                name: "StatusType");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PriorityID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PriorityID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_StatusID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PriorityID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PriorityID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
