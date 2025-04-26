using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdRubro",
                table: "Negocios",
                newName: "RubroId");

            migrationBuilder.RenameColumn(
                name: "IdPlanSaas",
                table: "Negocios",
                newName: "PlanSaasId");

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
                name: "IX_Negocios_PlanSaasId",
                table: "Negocios",
                column: "PlanSaasId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_RubroId",
                table: "Negocios",
                column: "RubroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Negocios_PlanesSaas_PlanSaasId",
                table: "Negocios",
                column: "PlanSaasId",
                principalTable: "PlanesSaas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Negocios_Rubros_RubroId",
                table: "Negocios",
                column: "RubroId",
                principalTable: "Rubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocios_PlanesSaas_PlanSaasId",
                table: "Negocios");

            migrationBuilder.DropForeignKey(
                name: "FK_Negocios_Rubros_RubroId",
                table: "Negocios");

            migrationBuilder.DropIndex(
                name: "IX_Negocios_PlanSaasId",
                table: "Negocios");

            migrationBuilder.DropIndex(
                name: "IX_Negocios_RubroId",
                table: "Negocios");

            migrationBuilder.RenameColumn(
                name: "RubroId",
                table: "Negocios",
                newName: "IdRubro");

            migrationBuilder.RenameColumn(
                name: "PlanSaasId",
                table: "Negocios",
                newName: "IdPlanSaas");

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
    }
}
