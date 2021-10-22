using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class DiscussionIDRevise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discussion_Parent_ID",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Discussions");

            migrationBuilder.RenameColumn(
                name: "Record_ID",
                table: "Discussions",
                newName: "RecordID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecordID",
                table: "Discussions",
                newName: "Record_ID");

            migrationBuilder.AddColumn<int>(
                name: "Discussion_Parent_ID",
                table: "Discussions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Discussions",
                type: "int",
                nullable: true);
        }
    }
}
