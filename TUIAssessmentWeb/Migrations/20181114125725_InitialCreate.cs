using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TUIAssessment.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartureAirportId = table.Column<int>(nullable: false),
                    ArrivalAirportId = table.Column<int>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    TimeOfFlight = table.Column<double>(nullable: false),
                    FuelQuantity = table.Column<double>(nullable: false),
                    Creation = table.Column<DateTime>(nullable: false),
                    Update = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 1, "CDG", 49.009642, 2.547885, "Paris-Charles De Gaulle" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 18, "HND", 35.554993, 139.780258, "Tokyo Haneda Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 17, "ICN", 37.471603, 126.455666, "Seoul Incheon Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 16, "PVG", 31.144997, 121.811371, "Shanghai Pudong International Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 15, "DOH", 25.261309, 51.562614, "Doha International Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 14, "RUH", 24.954332, 46.700993, "Riyad King Kahild International Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 13, "GIG", -22.910809, -43.163223, "Rio De Janeiro International Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 12, "SJO", 9.957228, -84.139236, "San Jose Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 11, "EZE", -34.812111, -58.539619, "Buenos Aires-Pistarini" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 10, "YVR", 49.192398, -123.179596, "Vancouver Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 9, "YUL", 45.470604, -73.744354, "Montreal-Trudeau" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 8, "ATL", 33.635899, -84.428719, "Atlanta-Hartsfield-Jackson" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 7, "LAX", 33.941154, -118.409447, "Los Angeles International Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 6, "JFK", 40.64444, -73.778, "New-York-John F. Kennedy" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 5, "FRA", 50.035313, 8.559723, "Frankfurt-Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 4, "AMS", 52.31488, 4.757767, "Amsterdam-Schipol" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 3, "LHR", 51.472401, -0.467262, "London-Heathrow" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 2, "MXP", 45.629646, 8.724174, "Milan-Malpensa" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 19, "SYD", -33.94997, 151.178482, "Sydney Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Latitude", "Longitude", "Name" },
                values: new object[] { 20, "JNB", -26.12314, 28.243365, "Johanesburg- OR Tambo International Airport" });

            migrationBuilder.CreateIndex(
                name: "IDX_Airport_Code",
                table: "Airports",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IDX_Airport_Id",
                table: "Airports",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IDX_Flight_ID",
                table: "Flights",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IDX_Flight_Departure_Arrival",
                table: "Flights",
                columns: new[] { "DepartureAirportId", "ArrivalAirportId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
