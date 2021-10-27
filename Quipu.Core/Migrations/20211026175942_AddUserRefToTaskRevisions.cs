using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class AddUserRefToTaskRevisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "TaskRevisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskRevisions_UserID",
                table: "TaskRevisions",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskRevisions_Users_UserID",
                table: "TaskRevisions",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskRevisions_Users_UserID",
                table: "TaskRevisions");

            migrationBuilder.DropIndex(
                name: "IX_TaskRevisions_UserID",
                table: "TaskRevisions");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "TaskRevisions");
        }
    }
}
