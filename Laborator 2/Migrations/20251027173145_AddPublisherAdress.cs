using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laborator_2.Migrations
{
    /// <inheritdoc />
    public partial class AddPublisherAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublisherAdress",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublisherAdress",
                table: "Publisher");
        }
    }
}
