using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCB_Clone.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddLegislatorChamber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Chamber",
                table: "Legislators",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chamber",
                table: "Legislators");
        }
    }
}
