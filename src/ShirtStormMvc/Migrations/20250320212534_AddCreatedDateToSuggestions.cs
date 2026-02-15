using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShirtStormMvc.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedDateToSuggestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Suggestions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Suggestions");
        }
    }
}
