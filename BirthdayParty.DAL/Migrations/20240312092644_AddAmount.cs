using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayParty.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "BookingServices",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BookingServices");
        }
    }
}
