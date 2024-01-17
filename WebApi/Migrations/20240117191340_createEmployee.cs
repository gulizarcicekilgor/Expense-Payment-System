using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class createEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeType",
                table: "Employees",
                newName: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeRole",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdentityNumber",
                table: "Employees",
                type: "int",
                maxLength: 11,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenEndDate",
                table: "Employees",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeRole",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RefreshTokenEndDate",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "Employees",
                newName: "EmployeeType");
        }
    }
}
