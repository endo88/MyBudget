using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.Migrations
{
    public partial class BoolFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Received",
                table: "Incomes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Expenses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "BankAccounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Received",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "BankAccounts");
        }
    }
}
