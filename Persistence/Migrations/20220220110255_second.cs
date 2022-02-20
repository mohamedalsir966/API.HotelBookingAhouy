using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BedType",
                table: "Booking",
                newName: "NumOfBed");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitesHotel_hotelId",
                table: "FacilitesHotel",
                column: "hotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilitesHotel_Hotel_hotelId",
                table: "FacilitesHotel",
                column: "hotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilitesHotel_Hotel_hotelId",
                table: "FacilitesHotel");

            migrationBuilder.DropIndex(
                name: "IX_FacilitesHotel_hotelId",
                table: "FacilitesHotel");

            migrationBuilder.RenameColumn(
                name: "NumOfBed",
                table: "Booking",
                newName: "BedType");
        }
    }
}
