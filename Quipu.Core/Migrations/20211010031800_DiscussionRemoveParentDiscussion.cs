using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class DiscussionRemoveParentDiscussion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Discussions_ParentID",
                table: "Discussions");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "Discussions",
                newName: "DiscussionID");

            migrationBuilder.RenameIndex(
                name: "IX_Discussions_ParentID",
                table: "Discussions",
                newName: "IX_Discussions_DiscussionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Discussions_DiscussionID",
                table: "Discussions",
                column: "DiscussionID",
                principalTable: "Discussions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Discussions_DiscussionID",
                table: "Discussions");

            migrationBuilder.RenameColumn(
                name: "DiscussionID",
                table: "Discussions",
                newName: "ParentID");

            migrationBuilder.RenameIndex(
                name: "IX_Discussions_DiscussionID",
                table: "Discussions",
                newName: "IX_Discussions_ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Discussions_ParentID",
                table: "Discussions",
                column: "ParentID",
                principalTable: "Discussions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
