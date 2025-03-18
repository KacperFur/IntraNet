using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntraNet.Migrations
{
    /// <inheritdoc />
    public partial class relationOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_TaskAuthorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskAuthorId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskAuthorId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_AuthorId",
                table: "Tasks",
                column: "AuthorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_AuthorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskAuthorId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskAuthorId",
                table: "Tasks",
                column: "TaskAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_TaskAuthorId",
                table: "Tasks",
                column: "TaskAuthorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
