using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class update21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Expenses_ExpenseId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenEndDate",
                table: "Employees",
                newName: "RefreshTokenExpirationDate");

            migrationBuilder.RenameColumn(
                name: "ExpenseId",
                table: "Employees",
                newName: "ExpenseExpenceId");

            migrationBuilder.RenameColumn(
                name: "EmployeeRole",
                table: "Employees",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ExpenseId",
                table: "Employees",
                newName: "IX_Employees_ExpenseExpenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Expenses_ExpenseExpenceId",
                table: "Employees",
                column: "ExpenseExpenceId",
                principalTable: "Expenses",
                principalColumn: "ExpenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Expenses_ExpenseExpenceId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "Employees",
                newName: "EmployeeRole");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpirationDate",
                table: "Employees",
                newName: "RefreshTokenEndDate");

            migrationBuilder.RenameColumn(
                name: "ExpenseExpenceId",
                table: "Employees",
                newName: "ExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ExpenseExpenceId",
                table: "Employees",
                newName: "IX_Employees_ExpenseId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Expenses_ExpenseId",
                table: "Employees",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenceId");
        }
    }
}
