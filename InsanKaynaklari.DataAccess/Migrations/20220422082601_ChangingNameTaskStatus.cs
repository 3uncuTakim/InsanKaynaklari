using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklari.DataAccess.Migrations
{
    public partial class ChangingNameTaskStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "Leaves",
                newName: "ConfirmStatus");

            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "Expenses",
                newName: "ConfirmStatus");

            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "AdvancePayments",
                newName: "ConfirmStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmStatus",
                table: "Leaves",
                newName: "TaskStatus");

            migrationBuilder.RenameColumn(
                name: "ConfirmStatus",
                table: "Expenses",
                newName: "TaskStatus");

            migrationBuilder.RenameColumn(
                name: "ConfirmStatus",
                table: "AdvancePayments",
                newName: "TaskStatus");
        }
    }
}
