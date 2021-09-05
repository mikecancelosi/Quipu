using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class AddProjectTeamRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TeamID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Projects");

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

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    MembersID = table.Column<int>(type: "int", nullable: false),
                    ProjectsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.MembersID, x.ProjectsID });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectsID",
                        column: x => x.ProjectsID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_MembersID",
                        column: x => x.MembersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeam_TeamsID",
                table: "ProjectTeam",
                column: "TeamsID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_ProjectsID",
                table: "ProjectUser",
                column: "ProjectsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTeam");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamID",
                table: "Projects",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamID",
                table: "Projects",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
