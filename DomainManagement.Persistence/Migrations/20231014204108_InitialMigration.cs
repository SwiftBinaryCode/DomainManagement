using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomainTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DomainTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "DomainName", "Ip", "OwnerName" },
                values: new object[] { 1, new DateTime(2023, 10, 14, 22, 41, 8, 184, DateTimeKind.Local).AddTicks(1741), new DateTime(2023, 10, 14, 22, 41, 8, 184, DateTimeKind.Local).AddTicks(1781), "example.com", "127.0.0.1", "example" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainTypes");
        }
    }
}
