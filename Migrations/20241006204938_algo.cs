using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiciosAdicionales.Migrations
{
    /// <inheritdoc />
    public partial class algo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "TiposAdicional",
                newName: "Activo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "TiposAdicional",
                newName: "IsActive");
        }
    }
}
