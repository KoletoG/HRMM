using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMM.Data.Migrations
{
    public partial class _156126 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomRId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomRId",
                table: "Reservations",
                column: "RoomRId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomRId",
                table: "Reservations",
                column: "RoomRId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomRId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomRId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RoomRId",
                table: "Reservations");
        }
    }
}
