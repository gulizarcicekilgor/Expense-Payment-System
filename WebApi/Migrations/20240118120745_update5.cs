using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpencesId",
                table: "Expenses",
                newName: "ExpenceId");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ExpenseId",
                table: "Employees",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Expenses_ExpenseId",
                table: "Employees",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Expenses_ExpenseId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ExpenseId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ExpenceId",
                table: "Expenses",
                newName: "ExpencesId");
        }
    }
}
