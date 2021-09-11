using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class TaskFKAdd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatusCategory_StatusCategoryID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssignedToUserID",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusCategoryID",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToUserID",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatusCategory_StatusCategoryID",
                table: "Tasks",
                column: "StatusCategoryID",
                principalTable: "TaskStatusCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssignedToUserID",
                table: "Tasks",
                column: "AssignedToUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatusCategory_StatusCategoryID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssignedToUserID",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusCategoryID",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToUserID",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatusCategory_StatusCategoryID",
                table: "Tasks",
                column: "StatusCategoryID",
                principalTable: "TaskStatusCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssignedToUserID",
                table: "Tasks",
                column: "AssignedToUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
