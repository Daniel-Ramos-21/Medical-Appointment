using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class TablaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Doctors",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Doctors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 1,
                column: "Id_Usuario",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 2,
                column: "Id_Usuario",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 3,
                column: "Id_Usuario",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 4,
                column: "Id_Usuario",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 5,
                column: "Id_Usuario",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 6,
                column: "Id_Usuario",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 7,
                column: "Id_Usuario",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 8,
                column: "Id_Usuario",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 3,
                column: "Nombre_especialidad",
                value: "Pediatría");

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 6,
                column: "Nombre_especialidad",
                value: "Oftalmología");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Usuarios_Id_Usuario",
                table: "Doctors",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Usuarios_Id_Usuario",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Id_Usuario",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Doctors",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Doctors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Doctors",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Doctors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 1,
                columns: new[] { "Apellido", "Nombre" },
                values: new object[] { "Martínez", "Carlos" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 2,
                columns: new[] { "Apellido", "Nombre" },
                values: new object[] { "Fernández", "Lucía" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 3,
                columns: new[] { "Apellido", "Nombre" },
                values: new object[] { "Rivas", "Elena" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 4,
                columns: new[] { "Apellido", "Nombre" },
                values: new object[] { "Orellana", "Samuel" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 5,
                columns: new[] { "Apellido", "Nombre" },
                values: new object[] { "Zelaya", "Beatriz" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 6,
                columns: new[] { "Apellido", "Nombre" },
                values: new object[] { "Arias", "Patricia" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 7,
                columns: new[] { "Apellido", "Nombre" },
                values: new object[] { "Méndez", "Gustavo" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id_Doctor",
                keyValue: 8,
                columns: new[] { "Apellido", "Nombre" },
                values: new object[] { "Valle", "Ricardo" });

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 3,
                column: "Nombre_especialidad",
                value: "Pedriatría");

            migrationBuilder.UpdateData(
                table: "Especialidades",
                keyColumn: "Id_Especialidad",
                keyValue: 6,
                column: "Nombre_especialidad",
                value: "Oftalmologia");
        }
    }
}
