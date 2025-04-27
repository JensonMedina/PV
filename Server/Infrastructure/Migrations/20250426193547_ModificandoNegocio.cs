using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "MediosPagos",
                newName: "TipoMedioPago");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "MediosPagos",
                newName: "NombreTitular");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "MediosPagos",
                newName: "FechaAlta");

            migrationBuilder.AlterColumn<string>(
                name: "UltimosDigitos",
                table: "MediosPagos",
                type: "varchar(4)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PlanesSaas",
                columns: new[] { "Id", "AccesoFacturacion", "AccesoPersonalizacion", "AccesoReportes", "AccesoSoportePrioritario", "Activo", "Costo", "Descripcion", "LimiteAlmacenamientoMB", "LimiteProductos", "LimiteUsuarios", "LimiteVentasMensuales", "Nombre", "Periodo" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, 5000.0, "Para pequeños negocios o emprendimientos.", null, 1000, 2, null, "Plan Básico", 1 },
                    { 2, null, null, null, null, true, 7000.0, "Para negocios medianos.", null, 1200, 5, null, "Plan Profesional", 1 },
                    { 3, null, null, null, null, true, 8000.0, "Para negocios grandes o cadenas de tiendas.", null, null, null, null, "Plan Premium", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanesSaas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlanesSaas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlanesSaas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "TipoMedioPago",
                table: "MediosPagos",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "NombreTitular",
                table: "MediosPagos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "FechaAlta",
                table: "MediosPagos",
                newName: "FechaCreacion");

            migrationBuilder.AlterColumn<string>(
                name: "UltimosDigitos",
                table: "MediosPagos",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
