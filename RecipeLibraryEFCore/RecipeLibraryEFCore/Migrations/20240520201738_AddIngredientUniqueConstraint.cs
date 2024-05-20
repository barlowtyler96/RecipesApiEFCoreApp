﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeLibraryEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients");
        }
    }
}
