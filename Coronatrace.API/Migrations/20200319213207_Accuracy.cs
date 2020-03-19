using Microsoft.EntityFrameworkCore.Migrations;

namespace Coronatrace.API.Migrations
{
    public partial class Accuracy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HorizontalAccuracy",
                table: "GeoTimeRecords",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VerticalAccuracy",
                table: "GeoTimeRecords",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorizontalAccuracy",
                table: "GeoTimeRecords");

            migrationBuilder.DropColumn(
                name: "VerticalAccuracy",
                table: "GeoTimeRecords");
        }
    }
}
