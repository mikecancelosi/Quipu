using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class TaskRemoveDiscussionReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Tasks_TaskID",
                table: "Discussions");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_TaskID",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "TaskID",
                table: "Discussions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskID",
                table: "Discussions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_TaskID",
                table: "Discussions",
                column: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Tasks_TaskID",
                table: "Discussions",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
