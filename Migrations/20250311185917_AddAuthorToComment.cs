using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloginterior.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorToComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "author",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "author",
                table: "Comment");
        }
    }
}
