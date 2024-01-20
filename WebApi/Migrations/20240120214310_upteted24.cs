using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class upteted24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EftTransactionId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    EftTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverIban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.EftTransactionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AccountId",
                table: "Employees",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EftTransactionId",
                table: "Accounts",
                column: "EftTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Transactions_EftTransactionId",
                table: "Accounts",
                column: "EftTransactionId",
                principalTable: "Transactions",
                principalColumn: "EftTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Accounts_AccountId",
                table: "Employees",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Transactions_EftTransactionId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Accounts_AccountId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AccountId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_EftTransactionId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "EftTransactionId",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromAccountNumber = table.Column<int>(type: "int", nullable: false),
                    ToAccountNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.TransferId);
                });
        }
    }
}
