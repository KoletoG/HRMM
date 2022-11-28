using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMM.Data.Migrations
{
    public partial class _31267123678 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationID",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
