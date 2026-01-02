using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class AddName2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name2",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Name2",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name2",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Name2",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
