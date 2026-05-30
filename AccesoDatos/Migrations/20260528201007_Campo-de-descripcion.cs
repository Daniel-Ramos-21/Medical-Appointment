using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Campodedescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "Especialidades",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 1,
                column: "descripcion",
                value: "Consultas generales y chequeos médicos completos.");

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 2,
                column: "descripcion",
                value: "Cuidado dental, limpieza y salud bucal integral.");

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 3,
                column: "descripcion",
                value: "Atención médica y control del desarrollo infantil");

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 4,
                column: "descripcion",
                value: "Salud reproductiva femenina, control y embarazo.");

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 5,
                column: "descripcion",
                value: "Terapia emocional, apoyo mental y bienestar integral.");

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 6,
                column: "descripcion",
                value: "Exámenes de la vista y tratamiento de problemas oculares.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "Especialidades");
        }
    }
}
