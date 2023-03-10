using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CzuEseje.Migrations
{
    public partial class nextModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Eseje",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eseje_UserId",
                table: "Eseje",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eseje_AspNetUsers_UserId",
                table: "Eseje",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eseje_AspNetUsers_UserId",
                table: "Eseje");

            migrationBuilder.DropIndex(
                name: "IX_Eseje_UserId",
                table: "Eseje");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Eseje");
        }
    }
}
