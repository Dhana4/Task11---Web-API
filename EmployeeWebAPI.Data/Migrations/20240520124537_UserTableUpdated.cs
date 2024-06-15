using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeWebAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2024, 5, 20, 18, 15, 36, 897, DateTimeKind.Local).AddTicks(188));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 2,
                column: "JoiningDate",
                value: new DateTime(2024, 5, 20, 18, 15, 36, 897, DateTimeKind.Local).AddTicks(207));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2024, 5, 16, 18, 25, 23, 843, DateTimeKind.Local).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 2,
                column: "JoiningDate",
                value: new DateTime(2024, 5, 16, 18, 25, 23, 843, DateTimeKind.Local).AddTicks(8350));
        }
    }
}
