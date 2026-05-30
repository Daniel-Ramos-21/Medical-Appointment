using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Actulizarfinaltablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 1,
                column: "password",
                value: "Admin123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 2,
                column: "password",
                value: "Admin123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 3,
                column: "password",
                value: "Admin123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 4,
                column: "password",
                value: "Admin123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 5,
                column: "password",
                value: "Admin123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 6,
                column: "password",
                value: "Admin123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 7,
                column: "password",
                value: "Admin123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 8,
                column: "password",
                value: "Admin123");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 1,
                column: "password",
                value: "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 2,
                column: "password",
                value: "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 3,
                column: "password",
                value: "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 4,
                column: "password",
                value: "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 5,
                column: "password",
                value: "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 6,
                column: "password",
                value: "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 7,
                column: "password",
                value: "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 8,
                column: "password",
                value: "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG");
        }
    }
}
