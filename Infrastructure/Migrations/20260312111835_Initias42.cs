using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initias42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Persons_PersonId",
                table: "Accounts",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Persons_PersonId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Accounts");
        }
    }
}
