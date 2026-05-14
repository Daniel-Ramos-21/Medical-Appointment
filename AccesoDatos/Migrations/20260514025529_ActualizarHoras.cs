using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarHoras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 1,
                columns: new[] { "Foto", "HoraSalida" },
                values: new object[] { "/img/Doctor/doc1.png", new TimeSpan(0, 15, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 2,
                column: "HoraSalida",
                value: new TimeSpan(0, 16, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 3,
                column: "HoraSalida",
                value: new TimeSpan(0, 17, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 4,
                column: "HoraSalida",
                value: new TimeSpan(0, 19, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 5,
                column: "HoraSalida",
                value: new TimeSpan(0, 18, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 6,
                column: "HoraSalida",
                value: new TimeSpan(0, 15, 30, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 7,
                column: "HoraSalida",
                value: new TimeSpan(0, 16, 30, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 1,
                columns: new[] { "Foto", "HoraSalida" },
                values: new object[] { "/img/doctores/doc1.png", new TimeSpan(0, 3, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 2,
                column: "HoraSalida",
                value: new TimeSpan(0, 4, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 3,
                column: "HoraSalida",
                value: new TimeSpan(0, 5, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 4,
                column: "HoraSalida",
                value: new TimeSpan(0, 7, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 5,
                column: "HoraSalida",
                value: new TimeSpan(0, 7, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 6,
                column: "HoraSalida",
                value: new TimeSpan(0, 3, 30, 0, 0));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 7,
                column: "HoraSalida",
                value: new TimeSpan(0, 4, 30, 0, 0));
        }
    }
}
