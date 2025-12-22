using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCB_Clone.Api.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Affiliations",
                table: "Legislators");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Legislators");

            migrationBuilder.DropColumn(
                name: "HonorsRewards",
                table: "Legislators");

            migrationBuilder.DropColumn(
                name: "LegService",
                table: "Legislators");

            migrationBuilder.DropColumn(
                name: "MilitaryService",
                table: "Legislators");

            migrationBuilder.DropColumn(
                name: "OtherAchivements",
                table: "Legislators");

            migrationBuilder.DropColumn(
                name: "OtherPublicService",
                table: "Legislators");

            migrationBuilder.DropColumn(
                name: "Personal",
                table: "Legislators");

            migrationBuilder.DropColumn(
                name: "Proffesional",
                table: "Legislators");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Affiliations",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HonorsRewards",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LegService",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MilitaryService",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OtherAchivements",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OtherPublicService",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Personal",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Proffesional",
                table: "Legislators",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
