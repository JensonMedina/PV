using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionPropiedadIdPlanSaasDuplicadaEnNegocios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "IdMedioPagoDefault");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebitoAutomaticoActivo",
                table: "Negocios");

            migrationBuilder.DropColumn(
                name: "FechaProximoDebito",
                table: "Negocios");

            migrationBuilder.RenameColumn(
                name: "IdRubro",
                table: "Negocios",
                newName: "RubroId");

            migrationBuilder.RenameColumn(
                name: "IdMedioPagoDefault",
                table: "Negocios",
                newName: "PlanSaasId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Negocios",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

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
    }
}
