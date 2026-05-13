using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOdontologia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 5,
                column: "Perfil",
                value: "Odontóloga integral con énfasis en rehabilitación oral y estética dental. Graduada de la Universidad de El Salvador, es experta en tratamientos preventivos y restaurativos, enfocada en devolver la funcionalidad y armonía estética a la sonrisa.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 5,
                column: "Perfil",
                value: "Odontóloga integral con énfasis en rehabilitación oral...");
        }
    }
}
