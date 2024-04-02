using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class v3yousef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "NonHotels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 4,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 5,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 6,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 7,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 8,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 9,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 10,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 11,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 12,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 13,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 14,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 15,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 16,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 1,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 2,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 3,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 4,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 5,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 6,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "NonHotels",
                keyColumn: "NonHotelId",
                keyValue: 7,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 1,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 2,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 3,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 4,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 5,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 6,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 7,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 8,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 9,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 10,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 11,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 12,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 13,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 14,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 15,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 16,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 17,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 18,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 19,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 20,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 21,
                column: "Rate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 22,
                column: "Rate",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "NonHotels");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Hotels");
        }
    }
}
