using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiciosAdicionales.Migrations
{
    /// <inheritdoc />
    public partial class pedidodeservicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaFinalizado",
                table: "PedidosDeServicios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaSolicitado",
                table: "PedidosDeServicios",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinalizado",
                table: "PedidosDeServicios");

            migrationBuilder.DropColumn(
                name: "FechaSolicitado",
                table: "PedidosDeServicios");
        }
    }
}
