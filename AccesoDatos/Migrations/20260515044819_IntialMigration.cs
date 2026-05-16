using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id_Especialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_especialidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id_Especialidad);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DUI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsDoctor = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id_Doctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    AlmaMater = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HoraEntrada = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraSalida = table.Column<TimeSpan>(type: "time", nullable: false),
                    Id_Especialidad = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id_Doctor);
                    table.ForeignKey(
                        name: "FK_Doctors_Especialidades_Id_Especialidad",
                        column: x => x.Id_Especialidad,
                        principalTable: "Especialidades",
                        principalColumn: "Id_Especialidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id_Citas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Paciente = table.Column<int>(type: "int", nullable: false),
                    Id_doctor = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doctor = table.Column<int>(type: "int", nullable: false),
                    paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id_Citas);
                    table.ForeignKey(
                        name: "FK_Citas_Doctors_Id_doctor",
                        column: x => x.Id_doctor,
                        principalTable: "Doctors",
                        principalColumn: "Id_Doctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_Id_Paciente",
                        column: x => x.Id_Paciente,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id_Especialidad", "Nombre_especialidad" },
                values: new object[,]
                {
                    { 1, "Medicina General" },
                    { 2, "Odontología" },
                    { 3, "Pediatría" },
                    { 4, "Ginecología" },
                    { 5, "Psicología" },
                    { 6, "Oftalmología" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id_Usuario", "Apellido", "DUI", "Email", "IsDoctor", "Nombre", "password" },
                values: new object[,]
                {
                    { 1, "Martínez", "10000000-1", "carlos.martinez@clinica.com", true, "Carlos", "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG" },
                    { 2, "Fernández", "10000001-2", "lucia.fernandez@clinica.com", true, "Lucía", "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG" },
                    { 3, "Rivas", "10000002-3", "elena.rivas@clinica.com", true, "Elena", "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG" },
                    { 4, "Orellana", "10000003-4", "samuel.orellana@clinica.com", true, "Samuel", "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG" },
                    { 5, "Zelaya", "10000004-5", "beatriz.zelaya@clinica.com", true, "Beatriz", "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG" },
                    { 6, "Arias", "10000005-6", "patricia.arias@clinica.com", true, "Patricia", "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG" },
                    { 7, "Méndez", "10000006-7", "gustavo.mendez@clinica.com", true, "Gustavo", "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG" },
                    { 8, "Valle", "10000007-8", "ricardo.valle@clinica.com", true, "Ricardo", "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id_Doctor", "AlmaMater", "Foto", "HoraEntrada", "HoraSalida", "Id_Especialidad", "Id_Usuario", "Perfil" },
                values: new object[,]
                {
                    { 1, "Universidad de El Salvador", "/img/doctores/doc1.png", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 1, 1, "Médico general con enfoque en atención primaria y medicina preventiva. Graduado de la Universidad de El Salvador, cuenta con amplia experiencia en el manejo de enfermedades crónicas y seguimiento integral del paciente adulto." },
                    { 2, "Universidad Dr. José Matías Delgado", "/img/doctores/doc2.png", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0), 1, 2, "Especialista en medicina comunitaria con formación en la Universidad Dr. José Matías Delgado. Experta en diagnósticos clínicos tempranos, promoción de la salud y atención de urgencias menores en el ámbito clínico privado." },
                    { 3, "Universidad Evangélica", "/img/doctores/doc3.png", new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), 5, 3, "Psicóloga clínica con maestría en terapia cognitivo-conductual. Se especializa en el tratamiento de trastornos de ansiedad, depresión y manejo del estrés, brindando un enfoque humano y empático en cada sesión terapéutica." },
                    { 4, "Universidad de El Salvador", "/img/doctores/doc4.png", new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 19, 0, 0, 0), 5, 4, "Profesional de la salud mental graduado de la UES, con experticia en psicología organizacional y apoyo psicopedagógico. Enfocado en el desarrollo de resiliencia y salud mental en entornos laborales y académicos." },
                    { 5, "Universidad de El Salvador", "/img/doctores/doc6.png", new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0), 2, 5, "Odontóloga integral con énfasis en rehabilitación oral y estética dental. Graduada de la Universidad de El Salvador, es experta en tratamientos preventivos y restaurativos, enfocada en devolver la funcionalidad y armonía estética a la sonrisa." },
                    { 6, "Universidad Dr. José Matías Delgado", "/img/doctores/doc7.png", new TimeSpan(0, 7, 30, 0, 0), new TimeSpan(0, 15, 30, 0, 0), 3, 6, "Especialista en el cuidado integral de la infancia y adolescencia. Con formación en la Universidad Dr. José Matías Delgado, destaca por su paciencia y precisión en el control de niño sano y desarrollo infantil." },
                    { 7, "Universidad de El Salvador", "/img/doctores/doc8.png", new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 16, 30, 0, 0), 4, 7, "Ginecólogo y obstetra dedicado a la salud integral de la mujer en todas sus etapas. Experto en control prenatal, planificación familiar y cirugía ginecológica mínimamente invasiva." },
                    { 8, "Universidad Alberto Masferrer", "/img/doctores/doc5.png", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), 6, 8, "Médico cirujano oftalmólogo con especialización en el diagnóstico de patologías oculares, corrección de errores refractivos y prevención del glaucoma. Comprometido con la salud visual de sus pacientes." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_doctor",
                table: "Citas",
                column: "Id_doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Id_Paciente",
                table: "Citas",
                column: "Id_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Id_Especialidad",
                table: "Doctors",
                column: "Id_Especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Id_Usuario",
                table: "Doctors",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DUI",
                table: "Usuarios",
                column: "DUI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
