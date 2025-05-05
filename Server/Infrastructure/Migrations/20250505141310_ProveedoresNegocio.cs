using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProveedoresNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Negocios_NegocioId",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Rubros_RubroId",
                table: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Proveedores_NegocioId",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "NegocioId",
                table: "Proveedores");

            migrationBuilder.AlterColumn<int>(
                name: "RubroId",
                table: "Proveedores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProveedoresNegocios",
                columns: table => new
                {
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaAgregado = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedoresNegocios", x => new { x.ProveedorId, x.NegocioId });
                    table.ForeignKey(
                        name: "FK_ProveedoresNegocios_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProveedoresNegocios_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 5, 11, 13, 10, 53, DateTimeKind.Local).AddTicks(6124));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 5, 11, 13, 10, 53, DateTimeKind.Local).AddTicks(6126));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 5, 11, 13, 10, 53, DateTimeKind.Local).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 5, 11, 13, 10, 53, DateTimeKind.Local).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 5, 11, 13, 10, 53, DateTimeKind.Local).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 5, 11, 13, 10, 53, DateTimeKind.Local).AddTicks(6134));

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresNegocios_NegocioId",
                table: "ProveedoresNegocios",
                column: "NegocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Rubros_RubroId",
                table: "Proveedores",
                column: "RubroId",
                principalTable: "Rubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Rubros_RubroId",
                table: "Proveedores");

            migrationBuilder.DropTable(
                name: "ProveedoresNegocios");

            migrationBuilder.AlterColumn<int>(
                name: "RubroId",
                table: "Proveedores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NegocioId",
                table: "Proveedores",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 3, 14, 46, 41, 412, DateTimeKind.Local).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 3, 14, 46, 41, 412, DateTimeKind.Local).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 3, 14, 46, 41, 412, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 3, 14, 46, 41, 412, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 3, 14, 46, 41, 412, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaAlta",
                value: new DateTime(2025, 5, 3, 14, 46, 41, 412, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_NegocioId",
                table: "Proveedores",
                column: "NegocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Negocios_NegocioId",
                table: "Proveedores",
                column: "NegocioId",
                principalTable: "Negocios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Rubros_RubroId",
                table: "Proveedores",
                column: "RubroId",
                principalTable: "Rubros",
                principalColumn: "Id");
        }
    }
}
