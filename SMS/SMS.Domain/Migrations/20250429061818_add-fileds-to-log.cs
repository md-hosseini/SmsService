using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addfiledstolog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedAt",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RetryCount",
                table: "Logs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedAt",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "RetryCount",
                table: "Logs");
        }
    }
}
