using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class MyFirstMigration56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Facilities");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_Id",
                table: "Facilities",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Facilities_Id",
                table: "Facilities");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
