using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Debts",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrincipalAmount",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingAmount",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Debts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "PrincipalAmount",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "RemainingAmount",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Debts");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Debts",
                newName: "Amount");
        }
    }
}
