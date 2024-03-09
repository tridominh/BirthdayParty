using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayParty.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ServicePrice",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PartyDateTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PartyDateTime",
                table: "Bookings");
        }
    }
}
