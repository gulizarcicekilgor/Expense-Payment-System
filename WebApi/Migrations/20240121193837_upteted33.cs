using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class upteted33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Transactions_EftTransactionId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "EftTransactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EftTransactions",
                table: "EftTransactions",
                column: "EftTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_EftTransactions_EftTransactionId",
                table: "Accounts",
                column: "EftTransactionId",
                principalTable: "EftTransactions",
                principalColumn: "EftTransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_EftTransactions_EftTransactionId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EftTransactions",
                table: "EftTransactions");

            migrationBuilder.RenameTable(
                name: "EftTransactions",
                newName: "Transactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "EftTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Transactions_EftTransactionId",
                table: "Accounts",
                column: "EftTransactionId",
                principalTable: "Transactions",
                principalColumn: "EftTransactionId");
        }
    }
}
