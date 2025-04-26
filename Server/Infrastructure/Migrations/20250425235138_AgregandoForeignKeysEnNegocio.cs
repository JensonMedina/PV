using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoForeignKeysEnNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 51, 38, 191, DateTimeKind.Local).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 51, 38, 191, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 51, 38, 191, DateTimeKind.Local).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 51, 38, 191, DateTimeKind.Local).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 51, 38, 191, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 51, 38, 191, DateTimeKind.Local).AddTicks(4619));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 28, 32, 94, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 28, 32, 94, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 28, 32, 94, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 28, 32, 94, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 28, 32, 94, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaAlta",
                value: new DateTime(2025, 4, 25, 20, 28, 32, 94, DateTimeKind.Local).AddTicks(7457));
        }
    }
}
