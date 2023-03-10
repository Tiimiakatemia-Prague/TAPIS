using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CzuEseje.Migrations
{
    public partial class esejSource21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Eseje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eseje_SourceId",
                table: "Eseje",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eseje_Source_SourceId",
                table: "Eseje",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eseje_Source_SourceId",
                table: "Eseje");

            migrationBuilder.DropIndex(
                name: "IX_Eseje_SourceId",
                table: "Eseje");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Eseje");
        }
    }
}
