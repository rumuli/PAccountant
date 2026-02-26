using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class _4mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetName",
                table: "ExpensePlannings");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseTypeId",
                table: "ExpensePlannings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "ExpensePlannings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExpensePlannings_BudgetId",
                table: "ExpensePlannings",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensePlannings_ExpenseTypeId",
                table: "ExpensePlannings",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensePlannings_Budgets_BudgetId",
                table: "ExpensePlannings",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensePlannings_ExpenseTypes_ExpenseTypeId",
                table: "ExpensePlannings",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpensePlannings_Budgets_BudgetId",
                table: "ExpensePlannings");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpensePlannings_ExpenseTypes_ExpenseTypeId",
                table: "ExpensePlannings");

            migrationBuilder.DropIndex(
                name: "IX_ExpensePlannings_BudgetId",
                table: "ExpensePlannings");

            migrationBuilder.DropIndex(
                name: "IX_ExpensePlannings_ExpenseTypeId",
                table: "ExpensePlannings");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "ExpensePlannings");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseTypeId",
                table: "ExpensePlannings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BudgetName",
                table: "ExpensePlannings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
