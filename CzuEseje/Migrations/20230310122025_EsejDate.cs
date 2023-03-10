using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CzuEseje.Migrations
{
    public partial class EsejDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateC",
                table: "Eseje",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateC",
                table: "Eseje");
        }
    }
}
