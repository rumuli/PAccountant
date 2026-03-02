using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Properties",
                newName: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PersonId",
                table: "Properties",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Persons_PersonId",
                table: "Properties",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Persons_PersonId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PersonId",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Properties",
                newName: "CategoryId");
        }
    }
}
