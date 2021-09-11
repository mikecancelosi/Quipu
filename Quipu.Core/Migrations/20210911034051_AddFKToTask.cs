using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class AddFKToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusType_StatusID",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusType_StatusID",
                table: "Tasks",
                column: "StatusID",
                principalTable: "StatusType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusType_StatusID",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusType_StatusID",
                table: "Tasks",
                column: "StatusID",
                principalTable: "StatusType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
