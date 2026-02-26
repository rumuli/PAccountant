using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EndMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebtType",
                table: "Debts");

            migrationBuilder.AddColumn<int>(
                name: "DebtTypeId",
                table: "Debts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DebtTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debts_DebtTypeId",
                table: "Debts",
                column: "DebtTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_DebtTypes_DebtTypeId",
                table: "Debts",
                column: "DebtTypeId",
                principalTable: "DebtTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_DebtTypes_DebtTypeId",
                table: "Debts");

            migrationBuilder.DropTable(
                name: "DebtTypes");

            migrationBuilder.DropIndex(
                name: "IX_Debts_DebtTypeId",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "DebtTypeId",
                table: "Debts");

            migrationBuilder.AddColumn<string>(
                name: "DebtType",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
