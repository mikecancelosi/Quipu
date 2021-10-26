using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quipu.Core.Migrations
{
    public partial class DBSetRenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PriorityType_PriorityID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_StatusType_StatusID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_PriorityType_PriorityID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusType_StatusID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatusCategory_StatusCategoryID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Changes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatusCategory",
                table: "TaskStatusCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusType",
                table: "StatusType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriorityType",
                table: "PriorityType");

            migrationBuilder.RenameTable(
                name: "TaskStatusCategory",
                newName: "TaskStatusCategories");

            migrationBuilder.RenameTable(
                name: "StatusType",
                newName: "StatusTypes");

            migrationBuilder.RenameTable(
                name: "PriorityType",
                newName: "PriorityTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatusCategories",
                table: "TaskStatusCategories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusTypes",
                table: "StatusTypes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriorityTypes",
                table: "PriorityTypes",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "TaskRevisions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskRevisions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaskRevisions_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskRevisions_TaskID",
                table: "TaskRevisions",
                column: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_PriorityTypes_PriorityID",
                table: "Projects",
                column: "PriorityID",
                principalTable: "PriorityTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_StatusTypes_StatusID",
                table: "Projects",
                column: "StatusID",
                principalTable: "StatusTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_PriorityTypes_PriorityID",
                table: "Tasks",
                column: "PriorityID",
                principalTable: "PriorityTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusTypes_StatusID",
                table: "Tasks",
                column: "StatusID",
                principalTable: "StatusTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatusCategories_StatusCategoryID",
                table: "Tasks",
                column: "StatusCategoryID",
                principalTable: "TaskStatusCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PriorityTypes_PriorityID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_StatusTypes_StatusID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_PriorityTypes_PriorityID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StatusTypes_StatusID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatusCategories_StatusCategoryID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskRevisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatusCategories",
                table: "TaskStatusCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusTypes",
                table: "StatusTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriorityTypes",
                table: "PriorityTypes");

            migrationBuilder.RenameTable(
                name: "TaskStatusCategories",
                newName: "TaskStatusCategory");

            migrationBuilder.RenameTable(
                name: "StatusTypes",
                newName: "StatusType");

            migrationBuilder.RenameTable(
                name: "PriorityTypes",
                newName: "PriorityType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatusCategory",
                table: "TaskStatusCategory",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusType",
                table: "StatusType",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriorityType",
                table: "PriorityType",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Changes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssociatedField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Changes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Changes_UserID",
                table: "Changes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_PriorityType_PriorityID",
                table: "Projects",
                column: "PriorityID",
                principalTable: "PriorityType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_StatusType_StatusID",
                table: "Projects",
                column: "StatusID",
                principalTable: "StatusType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_PriorityType_PriorityID",
                table: "Tasks",
                column: "PriorityID",
                principalTable: "PriorityType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StatusType_StatusID",
                table: "Tasks",
                column: "StatusID",
                principalTable: "StatusType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatusCategory_StatusCategoryID",
                table: "Tasks",
                column: "StatusCategoryID",
                principalTable: "TaskStatusCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
