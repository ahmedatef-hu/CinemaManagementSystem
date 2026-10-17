using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ahmed@example.com", "Ahmed Ali", "01012345678" },
                    { 2, "omar@example.com", "Omar Hassan", "01112345678" },
                    { 3, "mariam@example.com", "Mariam Mohamed", "01212345678" },
                    { 4, "youssef@example.com", "Youssef Adel", "01098765432" },
                    { 5, "sara@example.com", "Sara Mahmoud", "01198765432" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Horror" },
                    { 4, "Drama" },
                    { 5, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AvailableSeats", "Director", "Duration", "GenreId", "Rating", "ReleaseYear", "TicketPrice", "Title" },
                values: new object[,]
                {
                    { 1, 50, "Christopher Nolan", 148, 1, 8.8000000000000007, 2010, 100m, "Inception" },
                    { 2, 40, "Christopher Nolan", 152, 1, 9.0, 2008, 120m, "The Dark Knight" },
                    { 3, 60, "Chuck Russell", 101, 2, 6.9000000000000004, 1994, 80m, "The Mask" },
                    { 4, 35, "Christopher Nolan", 169, 5, 8.6999999999999993, 2014, 150m, "Interstellar" },
                    { 5, 45, "James Wan", 112, 3, 7.5, 2013, 90m, "The Conjuring" },
                    { 6, 55, "James Cameron", 195, 4, 7.9000000000000004, 1997, 110m, "Titanic" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CustomerId", "MovieId", "NumberOfTickets", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, 200m },
                    { 2, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 3, 360m },
                    { 3, new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 1, 80m },
                    { 4, new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 2, 300m },
                    { 5, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, 4, 360m },
                    { 6, new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1, 100m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
