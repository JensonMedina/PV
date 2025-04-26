using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProveedorModificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2025, 4, 26, 11, 57, 58, 309, DateTimeKind.Local).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 26, 11, 57, 58, 309, DateTimeKind.Local).AddTicks(5833));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 26, 11, 57, 58, 309, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 26, 11, 57, 58, 309, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 26, 11, 57, 58, 309, DateTimeKind.Local).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 26, 11, 57, 58, 309, DateTimeKind.Local).AddTicks(5841));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Negocios_NegocioId",
                table: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Proveedores_NegocioId",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "NegocioId",
                table: "Proveedores");

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
