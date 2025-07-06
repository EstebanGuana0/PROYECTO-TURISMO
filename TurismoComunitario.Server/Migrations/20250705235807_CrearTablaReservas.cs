using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoComunitario.Server.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaReservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LugarSeleccionado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    DiscapacidadGeneral = table.Column<bool>(type: "bit", nullable: false),
                    TiempoInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoFin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonasJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
