using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMM.Data.Migrations
{
    public partial class _61976 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Reservations_ReservationDataModelId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ReservationDataModelId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ReservationDataModelId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ClientsRId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientsRId",
                table: "Reservations",
                column: "ClientsRId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientsRId",
                table: "Reservations",
                column: "ClientsRId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientsRId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientsRId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientsRId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "ReservationDataModelId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ReservationDataModelId",
                table: "Clients",
                column: "ReservationDataModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Reservations_ReservationDataModelId",
                table: "Clients",
                column: "ReservationDataModelId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
