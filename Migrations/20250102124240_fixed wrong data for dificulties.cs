using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixedwrongdatafordificulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("5359fa24-b74c-475f-9f64-d3cfeb40e436"));

            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"));

            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f678-9012-3456-7890abcdef01"));

            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-7890-1234-5678-90abcdef0123"));

            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f678-9012-3456-7890-abcdef012345"));

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("5359fa24-b74c-475f-9f64-d3cfeb40e436"), "NGR", "Nigeria", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Flag_of_Nigeria.svg/1200px-Flag_of_Nigeria.svg.png" },
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), "USA", "United States", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Flag_of_the_United_States.svg/1200px-Flag_of_the_United_States.svg.png" },
                    { new Guid("b2c3d4e5-f678-9012-3456-7890abcdef01"), "CAN", "Canada", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cf/Flag_of_Canada.svg/1200px-Flag_of_Canada.svg.png" },
                    { new Guid("c3d4e5f6-7890-1234-5678-90abcdef0123"), "GBR", "United Kingdom", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Flag_of_the_United_Kingdom.svg/1200px-Flag_of_the_United_Kingdom.svg.png" },
                    { new Guid("d4e5f678-9012-3456-7890-abcdef012345"), "JPN", "Japan", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Flag_of_Japan.svg/1200px-Flag_of_Japan.svg.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5359fa24-b74c-475f-9f64-d3cfeb40e436"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f678-9012-3456-7890abcdef01"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-7890-1234-5678-90abcdef0123"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f678-9012-3456-7890-abcdef012345"));

            migrationBuilder.InsertData(
                table: "dificulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5359fa24-b74c-475f-9f64-d3cfeb40e436"), "Nigeria" },
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), "United States" },
                    { new Guid("b2c3d4e5-f678-9012-3456-7890abcdef01"), "Canada" },
                    { new Guid("c3d4e5f6-7890-1234-5678-90abcdef0123"), "United Kingdom" },
                    { new Guid("d4e5f678-9012-3456-7890-abcdef012345"), "Japan" }
                });
        }
    }
}
