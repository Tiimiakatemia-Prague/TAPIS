using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CzuEseje.Migrations
{
    public partial class addedEseje2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Eseje");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eseje",
                table: "Eseje",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Eseje",
                table: "Eseje");

            migrationBuilder.RenameTable(
                name: "Eseje",
                newName: "Cars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");
        }
    }
}
