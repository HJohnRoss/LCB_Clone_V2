using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCB_Clone.Api.Migrations
{
    /// <inheritdoc />
    public partial class legislatorModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Legislators",
                table: "Legislators");

            migrationBuilder.RenameTable(
                name: "Legislators",
                newName: "Legislator");

            migrationBuilder.AddColumn<string>(
                name: "Affiliations",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CCOffice",
                table: "Legislator",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CCPhone",
                table: "Legislator",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HonorsRewards",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "LVOffice",
                table: "Legislator",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LegService",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Legislator",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MilitaryService",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OtherAchivements",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OtherPublicService",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Party",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Personal",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Proffesional",
                table: "Legislator",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TermEnd",
                table: "Legislator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Legislator",
                table: "Legislator",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Social",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Icon = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WebsiteLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LegislatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Social_Legislator_LegislatorId",
                        column: x => x.LegislatorId,
                        principalTable: "Legislator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Social_LegislatorId",
                table: "Social",
                column: "LegislatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Social");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Legislator",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "Affiliations",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "CCOffice",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "CCPhone",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "HonorsRewards",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "LVOffice",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "LegService",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "MilitaryService",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "OtherAchivements",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "OtherPublicService",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "Party",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "Personal",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "Proffesional",
                table: "Legislator");

            migrationBuilder.DropColumn(
                name: "TermEnd",
                table: "Legislator");

            migrationBuilder.RenameTable(
                name: "Legislator",
                newName: "Legislators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Legislators",
                table: "Legislators",
                column: "Id");
        }
    }
}
