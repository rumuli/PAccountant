using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class CreateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SupportTickets");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "SupportTickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SupportTickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SupportTickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "SupportTickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Leads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Leads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Leads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Leads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Deals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Deals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDate",
                table: "Deals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Deals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Deals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Campaigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Campaigns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Campaigns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Campaigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Campaigns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Activities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_CreatedById",
                table: "SupportTickets",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_UpdatedById",
                table: "SupportTickets",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatedById",
                table: "Notes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UpdatedById",
                table: "Notes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CreatedById",
                table: "Leads",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_UpdatedById",
                table: "Leads",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CreatedById",
                table: "Deals",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_UpdatedById",
                table: "Deals",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CreatedById",
                table: "Campaigns",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_UpdatedById",
                table: "Campaigns",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatedById",
                table: "Activities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UpdatedById",
                table: "Activities",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_CreatedById",
                table: "Activities",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_UpdatedById",
                table: "Activities",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_CreatedById",
                table: "Campaigns",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_UpdatedById",
                table: "Campaigns",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Users_CreatedById",
                table: "Deals",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Users_UpdatedById",
                table: "Deals",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Users_CreatedById",
                table: "Leads",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Users_UpdatedById",
                table: "Leads",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_CreatedById",
                table: "Notes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UpdatedById",
                table: "Notes",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportTickets_Users_CreatedById",
                table: "SupportTickets",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportTickets_Users_UpdatedById",
                table: "SupportTickets",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_CreatedById",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_UpdatedById",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_CreatedById",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_UpdatedById",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Users_CreatedById",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Users_UpdatedById",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Users_CreatedById",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Users_UpdatedById",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_CreatedById",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UpdatedById",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportTickets_Users_CreatedById",
                table: "SupportTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportTickets_Users_UpdatedById",
                table: "SupportTickets");

            migrationBuilder.DropIndex(
                name: "IX_SupportTickets_CreatedById",
                table: "SupportTickets");

            migrationBuilder.DropIndex(
                name: "IX_SupportTickets_UpdatedById",
                table: "SupportTickets");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CreatedById",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UpdatedById",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Leads_CreatedById",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_UpdatedById",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Deals_CreatedById",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_UpdatedById",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_CreatedById",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_UpdatedById",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CreatedById",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UpdatedById",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SupportTickets");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SupportTickets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SupportTickets");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "SupportTickets");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "OpenDate",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SupportTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
