using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id_Especialidad", "Nombre_especialidad" },
                values: new object[,]
                {
                    { 1, "Medicina General" },
                    { 2, "Odontología" },
                    { 3, "Pedriatría" },
                    { 4, "Ginecología" },
                    { 5, "Psicología" },
                    { 6, "Oftalmologia" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id_Doctor", "AlmaMater", "Apellido", "Foto", "HoraEntrada", "HoraSalida", "Id_Especialidad", "Nombre", "Perfil" },
                values: new object[,]
                {
                    { 1, "Universidad de El Salvador", "Martínez", "/img/doctores/doc1.png", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 3, 0, 0, 0), 1, "Carlos", "Médico general con enfoque en atención primaria y medicina preventiva. Graduado de la Universidad de El Salvador, cuenta con amplia experiencia en el manejo de enfermedades crónicas y seguimiento integral del paciente adulto." },
                    { 2, "Universidad Dr. José Matías Delgado", "Fernández", "/img/doctores/doc2.png", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 4, 0, 0, 0), 1, "Lucía", "Especialista en medicina comunitaria con formación en la Universidad Dr. José Matías Delgado. Experta en diagnósticos clínicos tempranos, promoción de la salud y atención de urgencias menores en el ámbito clínico privado." },
                    { 3, "Universidad Evangélica", "Rivas", "/img/doctores/doc3.png", new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 5, 0, 0, 0), 5, "Elena", "Psicóloga clínica con maestría en terapia cognitivo-conductual. Se especializa en el tratamiento de trastornos de ansiedad, depresión y manejo del estrés, brindando un enfoque humano y empático en cada sesión terapéutica." },
                    { 4, "Universidad de El Salvador", "Orellana", "/img/doctores/doc4.png", new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 5, "Samuel", "Profesional de la salud mental graduado de la UES, con experticia en psicología organizacional y apoyo psicopedagógico. Enfocado en el desarrollo de resiliencia y salud mental en entornos laborales y académicos." },
                    { 5, "Universidad de El Salvador", "Zelaya", "/img/doctores/doc6.png", new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 2, "Beatriz", "Odontóloga integral con énfasis en rehabilitación oral..." },
                    { 6, "Universidad Dr. José Matías Delgado", "Arias", "/img/doctores/doc7.png", new TimeSpan(0, 7, 30, 0, 0), new TimeSpan(0, 3, 30, 0, 0), 3, "Patricia", "Especialista en el cuidado integral de la infancia y adolescencia. Con formación en la Universidad Dr. José Matías Delgado, destaca por su paciencia y precisión en el control de niño sano y desarrollo infantil." },
                    { 7, "Universidad de El Salvador", "Méndez", "/img/doctores/doc8.png", new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 4, 30, 0, 0), 4, "Gustavo", "Ginecólogo y obstetra dedicado a la salud integral de la mujer en todas sus etapas. Experto en control prenatal, planificación familiar y cirugía ginecológica mínimamente invasiva." },
                    { 8, "Universidad Alberto Masferrer", "Valle", "/img/doctores/doc5.png", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), 6, "Ricardo", "Médico cirujano oftalmólogo con especialización en el diagnóstico de patologías oculares, corrección de errores refractivos y prevención del glaucoma. Comprometido con la salud visual de sus pacientes." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 6);
        }
    }
}
