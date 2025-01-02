using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedingregionanddificulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dificulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("047ac5c3-ff02-4843-b378-01ccbd237444"), "Medium" },
                    { new Guid("2512c7f7-d46b-4328-9a9c-57aa6ca7e1c5"), "Easy" },
                    { new Guid("5359fa24-b74c-475f-9f64-d3cfeb40e436"), "Nigeria" },
                    { new Guid("605f416a-44dc-467e-bc95-5400c26bb0de"), "Hard" },
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), "United States" },
                    { new Guid("b2c3d4e5-f678-9012-3456-7890abcdef01"), "Canada" },
                    { new Guid("c3d4e5f6-7890-1234-5678-90abcdef0123"), "United Kingdom" },
                    { new Guid("d4e5f678-9012-3456-7890-abcdef012345"), "Japan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("047ac5c3-ff02-4843-b378-01ccbd237444"));

            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("2512c7f7-d46b-4328-9a9c-57aa6ca7e1c5"));

            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("5359fa24-b74c-475f-9f64-d3cfeb40e436"));

            migrationBuilder.DeleteData(
                table: "dificulties",
                keyColumn: "Id",
                keyValue: new Guid("605f416a-44dc-467e-bc95-5400c26bb0de"));

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
        }
    }
}
