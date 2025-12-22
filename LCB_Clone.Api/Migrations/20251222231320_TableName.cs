using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCB_Clone.Api.Migrations
{
    /// <inheritdoc />
    public partial class TableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Social_Legislator_LegislatorId",
                table: "Social");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Social",
                table: "Social");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Legislator",
                table: "Legislator");

            migrationBuilder.RenameTable(
                name: "Social",
                newName: "Socials");

            migrationBuilder.RenameTable(
                name: "Legislator",
                newName: "Legislators");

            migrationBuilder.RenameIndex(
                name: "IX_Social_LegislatorId",
                table: "Socials",
                newName: "IX_Socials_LegislatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Socials",
                table: "Socials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Legislators",
                table: "Legislators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Legislators_LegislatorId",
                table: "Socials",
                column: "LegislatorId",
                principalTable: "Legislators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Legislators_LegislatorId",
                table: "Socials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Socials",
                table: "Socials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Legislators",
                table: "Legislators");

            migrationBuilder.RenameTable(
                name: "Socials",
                newName: "Social");

            migrationBuilder.RenameTable(
                name: "Legislators",
                newName: "Legislator");

            migrationBuilder.RenameIndex(
                name: "IX_Socials_LegislatorId",
                table: "Social",
                newName: "IX_Social_LegislatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Social",
                table: "Social",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Legislator",
                table: "Legislator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Social_Legislator_LegislatorId",
                table: "Social",
                column: "LegislatorId",
                principalTable: "Legislator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
