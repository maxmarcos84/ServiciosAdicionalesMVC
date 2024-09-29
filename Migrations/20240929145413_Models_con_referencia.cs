using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiciosAdicionales.Migrations
{
    /// <inheritdoc />
    public partial class Models_con_referencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_PedidosDeServicios_PedidoDeServiciosId",
                table: "Servicios");

            migrationBuilder.RenameColumn(
                name: "PedidoDeServiciosId",
                table: "Servicios",
                newName: "pedidoDeServiciosId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_PedidoDeServiciosId",
                table: "Servicios",
                newName: "IX_Servicios_pedidoDeServiciosId");

            migrationBuilder.AlterColumn<int>(
                name: "pedidoDeServiciosId",
                table: "Servicios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SectorId",
                table: "Usuarios",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_TipoAdicionalId",
                table: "Servicios",
                column: "TipoAdicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeServicios_EmpleadoId",
                table: "PedidosDeServicios",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeServicios_SolicitanteId",
                table: "PedidosDeServicios",
                column: "SolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeServicios_Usuarios_EmpleadoId",
                table: "PedidosDeServicios",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeServicios_Usuarios_SolicitanteId",
                table: "PedidosDeServicios",
                column: "SolicitanteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_PedidosDeServicios_pedidoDeServiciosId",
                table: "Servicios",
                column: "pedidoDeServiciosId",
                principalTable: "PedidosDeServicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_TiposAdicional_TipoAdicionalId",
                table: "Servicios",
                column: "TipoAdicionalId",
                principalTable: "TiposAdicional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Empresas_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Sector_SectorId",
                table: "Usuarios",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeServicios_Usuarios_EmpleadoId",
                table: "PedidosDeServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeServicios_Usuarios_SolicitanteId",
                table: "PedidosDeServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_PedidosDeServicios_pedidoDeServiciosId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_TiposAdicional_TipoAdicionalId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Empresas_EmpresaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Sector_SectorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SectorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_TipoAdicionalId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDeServicios_EmpleadoId",
                table: "PedidosDeServicios");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDeServicios_SolicitanteId",
                table: "PedidosDeServicios");

            migrationBuilder.RenameColumn(
                name: "pedidoDeServiciosId",
                table: "Servicios",
                newName: "PedidoDeServiciosId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_pedidoDeServiciosId",
                table: "Servicios",
                newName: "IX_Servicios_PedidoDeServiciosId");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoDeServiciosId",
                table: "Servicios",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_PedidosDeServicios_PedidoDeServiciosId",
                table: "Servicios",
                column: "PedidoDeServiciosId",
                principalTable: "PedidosDeServicios",
                principalColumn: "Id");
        }
    }
}
