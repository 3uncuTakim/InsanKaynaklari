using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklari.DataAccess.Migrations
{
    public partial class AddBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "PersonelDetails",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "PersonelDetails");
        }
    }
}
