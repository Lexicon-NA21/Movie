using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Genre", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 3, 5f, new DateTime(1997, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic" },
                    { 2, 0, 2.3f, new DateTime(2005, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Screem" },
                    { 3, 0, 4.4f, new DateTime(1997, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shining" },
                    { 4, 4, 4.1f, new DateTime(2000, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "300" },
                    { 5, 3, 4.8f, new DateTime(2014, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { 6, 4, 4.4f, new DateTime(2008, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
