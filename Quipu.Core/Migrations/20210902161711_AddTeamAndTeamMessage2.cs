using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class AddTeamAndTeamMessage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TeamMessages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMessages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeamMessages_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMessages_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMessages_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamID",
                table: "Users",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamID",
                table: "Projects",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMessages_CreatorID",
                table: "TeamMessages",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMessages_ProjectID",
                table: "TeamMessages",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMessages_TeamID",
                table: "TeamMessages",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamID",
                table: "Projects",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamID",
                table: "Users",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TeamMessages");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeamID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TeamID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Projects");
        }
    }
}
