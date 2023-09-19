using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntregaFinalAcademia.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    job_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_date = table.Column<DateTime>(type: "date", nullable: false),
                    CodProyecto = table.Column<int>(type: "int", nullable: false),
                    CodServicio = table.Column<int>(type: "int", nullable: false),
                    job_cantHoras = table.Column<int>(type: "int", nullable: false),
                    job_valorHora = table.Column<double>(type: "float", nullable: false),
                    job_costo = table.Column<double>(type: "float", nullable: false),
                    job_estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.job_id);
                });

            migrationBuilder.CreateTable(
                name: "Proyects",
                columns: table => new
                {
                    proyect_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proyect_nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    proyect_direccion = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    proyect_estado = table.Column<int>(type: "int", nullable: false),
                    proyect_estadoActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyects", x => x.proyect_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_descr = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    service_estado = table.Column<bool>(type: "bit", nullable: false),
                    service_valorHora = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.service_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_dni = table.Column<double>(type: "float", nullable: false),
                    user_nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    user_tipo = table.Column<int>(type: "int", nullable: false),
                    user_clave = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    user_estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "role_id");
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "job_id", "job_cantHoras", "CodProyecto", "CodServicio", "job_costo", "job_estado", "job_date", "job_valorHora" },
                values: new object[] { 1, 20, 1, 1, 2000.0, true, new DateTime(2023, 9, 19, 13, 23, 24, 132, DateTimeKind.Local).AddTicks(9848), 100.0 });

            migrationBuilder.InsertData(
                table: "Proyects",
                columns: new[] { "proyect_id", "proyect_direccion", "proyect_estado", "proyect_estadoActivo", "proyect_nombre" },
                values: new object[] { 1, "Santa Fe 29475", 1, true, "Proyecto 1" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_activo", "role_description", "role_name" },
                values: new object[,]
                {
                    { 1, true, "Admin", "Admin" },
                    { 2, true, "Consulta", "Consulta" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "service_id", "service_descr", "service_estado", "service_valorHora" },
                values: new object[] { 1, "Reparacion", true, 100.0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "user_clave", "user_dni", "user_estado", "user_nombre", "RoleId", "user_tipo" },
                values: new object[] { 1, "1234", 40951295.0, true, "Pedro", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Proyects");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
