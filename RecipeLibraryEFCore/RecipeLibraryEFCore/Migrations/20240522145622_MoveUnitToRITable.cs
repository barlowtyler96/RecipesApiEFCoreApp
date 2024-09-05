using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeLibraryEFCore.Migrations
{
    /// <inheritdoc />
    public partial class MoveUnitToRITable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "RecipeIngredients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "RecipeIngredients");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
