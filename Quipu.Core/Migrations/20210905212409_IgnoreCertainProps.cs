using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class IgnoreCertainProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamUser_Users_UsersID",
                table: "TeamUser");

            migrationBuilder.DropTable(
                name: "ProjectTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamUser",
                table: "TeamUser");

            migrationBuilder.DropIndex(
                name: "IX_TeamUser_UsersID",
                table: "TeamUser");

            migrationBuilder.RenameColumn(
                name: "UsersID",
                table: "TeamUser",
                newName: "MembersID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamUser",
                table: "TeamUser",
                columns: new[] { "MembersID", "TeamsID" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamUser_TeamsID",
                table: "TeamUser",
                column: "TeamsID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUser_Users_MembersID",
                table: "TeamUser",
                column: "MembersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamUser_Users_MembersID",
                table: "TeamUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamUser",
                table: "TeamUser");

            migrationBuilder.DropIndex(
                name: "IX_TeamUser_TeamsID",
                table: "TeamUser");

            migrationBuilder.RenameColumn(
                name: "MembersID",
                table: "TeamUser",
                newName: "UsersID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamUser",
                table: "TeamUser",
                columns: new[] { "TeamsID", "UsersID" });

            migrationBuilder.CreateTable(
                name: "ProjectTeam",
                columns: table => new
                {
                    ProjectsID = table.Column<int>(type: "int", nullable: false),
                    TeamsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeam", x => new { x.ProjectsID, x.TeamsID });
                    table.ForeignKey(
                        name: "FK_ProjectTeam_Projects_ProjectsID",
                        column: x => x.ProjectsID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTeam_Teams_TeamsID",
                        column: x => x.TeamsID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamUser_UsersID",
                table: "TeamUser",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeam_TeamsID",
                table: "ProjectTeam",
                column: "TeamsID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUser_Users_UsersID",
                table: "TeamUser",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
