using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiciosAdicionales.Migrations
{
    /// <inheritdoc />
    public partial class Modelsdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidosDeServicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SolicitanteId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SitioId = table.Column<int>(type: "INTEGER", nullable: false),
                    tipoPedido = table.Column<int>(type: "INTEGER", nullable: false),
                    estadoPedido = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDeServicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    IGG = table.Column<string>(type: "TEXT", nullable: false),
                    SectorId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Solicitante = table.Column<bool>(type: "INTEGER", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PedidoDeServicioId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoAdicionalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Justificacion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "TEXT", nullable: true),
                    HoraFin = table.Column<TimeOnly>(type: "TEXT", nullable: true),
                    CantidadDias = table.Column<int>(type: "INTEGER", nullable: true),
                    CantidadHoras = table.Column<int>(type: "INTEGER", nullable: true),
                    PedidoDeServiciosId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_PedidosDeServicios_PedidoDeServiciosId",
                        column: x => x.PedidoDeServiciosId,
                        principalTable: "PedidosDeServicios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_PedidoDeServiciosId",
                table: "Servicios",
                column: "PedidoDeServiciosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "PedidosDeServicios");
        }
    }
}
