using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PDVS19crudnegocios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPlanSaas",
                table: "Negocios");

            migrationBuilder.AlterColumn<int>(
                name: "TipoFacturacion",
                table: "Negocios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Negocios",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<bool>(
                name: "DebitoAutomaticoActivo",
                table: "Negocios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaProximoDebito",
                table: "Negocios",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediosPagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    TipoMedioPago = table.Column<int>(type: "int", nullable: false),
                    NombreTitular = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TokenProveedor = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UltimosDigitos = table.Column<string>(type: "varchar(4)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaExpiracion = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaUltimoUso = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediosPagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediosPagos_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PlanesSaas",
                columns: new[] { "Id", "AccesoFacturacion", "AccesoPersonalizacion", "AccesoReportes", "AccesoSoportePrioritario", "Activo", "Costo", "Descripcion", "LimiteAlmacenamientoMB", "LimiteProductos", "LimiteUsuarios", "LimiteVentasMensuales", "Nombre", "Periodo" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, 5000.0, "Para pequeños negocios o emprendimientos.", null, 1000, 2, null, "Plan Básico", 1 },
                    { 2, null, null, null, null, true, 7000.0, "Para negocios medianos.", null, 1200, 5, null, "Plan Profesional", 1 },
                    { 3, null, null, null, null, true, 8000.0, "Para negocios grandes o cadenas de tiendas.", null, null, null, null, "Plan Premium", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_MediosPagos_NegocioId",
                table: "MediosPagos",
                column: "NegocioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediosPagos");

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

            migrationBuilder.DropColumn(
                name: "DebitoAutomaticoActivo",
                table: "Negocios");

            migrationBuilder.DropColumn(
                name: "FechaProximoDebito",
                table: "Negocios");

            migrationBuilder.AlterColumn<int>(
                name: "TipoFacturacion",
                table: "Negocios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Negocios",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<int>(
                name: "IdPlanSaas",
                table: "Negocios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 23, 10, 43, 4, 853, DateTimeKind.Local).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 23, 10, 43, 4, 853, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 23, 10, 43, 4, 853, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 23, 10, 43, 4, 853, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 23, 10, 43, 4, 853, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 23, 10, 43, 4, 853, DateTimeKind.Local).AddTicks(6523));
        }
    }
}
