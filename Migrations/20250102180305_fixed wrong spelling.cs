using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixedwrongspelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_dificulties_DificultyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dificulties",
                table: "dificulties");

            migrationBuilder.RenameTable(
                name: "dificulties",
                newName: "Dificulties");

            migrationBuilder.RenameColumn(
                name: "lenghtInKm",
                table: "Walks",
                newName: "LenghtInKm");

            migrationBuilder.AlterColumn<string>(
                name: "LenghtInKm",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dificulties",
                table: "Dificulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Dificulties_DificultyId",
                table: "Walks",
                column: "DificultyId",
                principalTable: "Dificulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Dificulties_DificultyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dificulties",
                table: "Dificulties");

            migrationBuilder.RenameTable(
                name: "Dificulties",
                newName: "dificulties");

            migrationBuilder.RenameColumn(
                name: "LenghtInKm",
                table: "Walks",
                newName: "lenghtInKm");

            migrationBuilder.AlterColumn<string>(
                name: "lenghtInKm",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dificulties",
                table: "dificulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_dificulties_DificultyId",
                table: "Walks",
                column: "DificultyId",
                principalTable: "dificulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
