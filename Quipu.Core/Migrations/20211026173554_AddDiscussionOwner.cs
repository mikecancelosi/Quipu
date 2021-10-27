using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class AddDiscussionOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordID",
                table: "Discussions");

            migrationBuilder.AddColumn<int>(
                name: "DiscussionOwnerID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Discussions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiscussionOwners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionOwners", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DiscussionOwnerID",
                table: "Tasks",
                column: "DiscussionOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_OwnerID",
                table: "Discussions",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_DiscussionOwners_OwnerID",
                table: "Discussions",
                column: "OwnerID",
                principalTable: "DiscussionOwners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_DiscussionOwners_DiscussionOwnerID",
                table: "Tasks",
                column: "DiscussionOwnerID",
                principalTable: "DiscussionOwners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_DiscussionOwners_OwnerID",
                table: "Discussions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_DiscussionOwners_DiscussionOwnerID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "DiscussionOwners");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_DiscussionOwnerID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_OwnerID",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "DiscussionOwnerID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Discussions");

            migrationBuilder.AddColumn<int>(
                name: "RecordID",
                table: "Discussions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
