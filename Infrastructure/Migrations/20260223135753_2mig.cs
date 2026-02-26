using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class _2mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetName",
                table: "IncomePlannings");

            migrationBuilder.AlterColumn<int>(
                name: "IncomeTypeId",
                table: "IncomePlannings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "IncomePlannings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IncomePlannings_BudgetId",
                table: "IncomePlannings",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomePlannings_IncomeTypeId",
                table: "IncomePlannings",
                column: "IncomeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomePlannings_Budgets_BudgetId",
                table: "IncomePlannings",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomePlannings_IncomeTypes_IncomeTypeId",
                table: "IncomePlannings",
                column: "IncomeTypeId",
                principalTable: "IncomeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomePlannings_Budgets_BudgetId",
                table: "IncomePlannings");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomePlannings_IncomeTypes_IncomeTypeId",
                table: "IncomePlannings");

            migrationBuilder.DropIndex(
                name: "IX_IncomePlannings_BudgetId",
                table: "IncomePlannings");

            migrationBuilder.DropIndex(
                name: "IX_IncomePlannings_IncomeTypeId",
                table: "IncomePlannings");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "IncomePlannings");

            migrationBuilder.AlterColumn<string>(
                name: "IncomeTypeId",
                table: "IncomePlannings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BudgetName",
                table: "IncomePlannings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
