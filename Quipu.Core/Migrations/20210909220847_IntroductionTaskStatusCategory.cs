using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class IntroductionTaskStatusCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusCategoryID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskStatusCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatusCategory", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusCategoryID",
                table: "Tasks",
                column: "StatusCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatusCategory_StatusCategoryID",
                table: "Tasks",
                column: "StatusCategoryID",
                principalTable: "TaskStatusCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatusCategory_StatusCategoryID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskStatusCategory");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusCategoryID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StatusCategoryID",
                table: "Tasks");
        }
    }
}
