using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShirtStorm.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreCustomersFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "Customers",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityEmail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IdentityEmail",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Customers",
                newName: "IdentityId");
        }
    }
}
