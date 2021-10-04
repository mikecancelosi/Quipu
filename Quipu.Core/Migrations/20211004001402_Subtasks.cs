using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class Subtasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentTaskID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ParentTaskID",
                table: "Tasks",
                column: "ParentTaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_ParentTaskID",
                table: "Tasks",
                column: "ParentTaskID",
                principalTable: "Tasks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_ParentTaskID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ParentTaskID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ParentTaskID",
                table: "Tasks");
        }
    }
}
