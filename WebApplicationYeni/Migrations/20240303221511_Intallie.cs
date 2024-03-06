using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationYeni.Migrations
{
    /// <inheritdoc />
    public partial class Intallie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Writers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Publishers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Books");
        }
    }
}
