using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class DiscussionRemoveChildrenDiscussion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Discussions_DiscussionID",
                table: "Discussions");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_DiscussionID",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "DiscussionID",
                table: "Discussions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscussionID",
                table: "Discussions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_DiscussionID",
                table: "Discussions",
                column: "DiscussionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Discussions_DiscussionID",
                table: "Discussions",
                column: "DiscussionID",
                principalTable: "Discussions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
