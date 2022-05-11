using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklari.DataAccess.Migrations
{
    public partial class DebitConfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorfirmed",
                table: "Debits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorfirmed",
                table: "Debits");
        }
    }
}
