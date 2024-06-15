using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeWebAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2024, 5, 21, 17, 14, 34, 387, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 2,
                column: "JoiningDate",
                value: new DateTime(2024, 5, 21, 17, 14, 34, 387, DateTimeKind.Local).AddTicks(29));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
