using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklari.DataAccess.Migrations
{
    public partial class Expense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfExpense",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfExpense",
                table: "Expenses");
        }
    }
}
