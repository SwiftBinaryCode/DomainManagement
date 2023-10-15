using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DomainTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 15, 14, 15, 19, 438, DateTimeKind.Local).AddTicks(5547), new DateTime(2023, 10, 15, 14, 15, 19, 438, DateTimeKind.Local).AddTicks(5587) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DomainTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 15, 10, 32, 1, 523, DateTimeKind.Local).AddTicks(4078), new DateTime(2023, 10, 15, 10, 32, 1, 523, DateTimeKind.Local).AddTicks(4117) });
        }
    }
}
