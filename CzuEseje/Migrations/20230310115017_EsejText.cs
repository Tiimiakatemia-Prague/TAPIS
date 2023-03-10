using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CzuEseje.Migrations
{
    public partial class EsejText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Eseje",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TextRaw",
                table: "Eseje",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Eseje");

            migrationBuilder.DropColumn(
                name: "TextRaw",
                table: "Eseje");
        }
    }
}
