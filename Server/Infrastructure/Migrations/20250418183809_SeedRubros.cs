using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRubros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Activo", "Descripcion", "FechaAlta", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Productos comestibles, bebidas alcohólicas y no alcohólicas", new DateTime(2025, 4, 18, 15, 38, 8, 64, DateTimeKind.Local).AddTicks(4715), "Alimentos y Bebidas" },
                    { 2, true, "Artículos eléctricos para el hogar", new DateTime(2025, 4, 18, 15, 38, 8, 64, DateTimeKind.Local).AddTicks(4717), "Electrodomésticos" },
                    { 3, true, "Ropa y accesorios de moda", new DateTime(2025, 4, 18, 15, 38, 8, 64, DateTimeKind.Local).AddTicks(4718), "Indumentaria" },
                    { 4, true, "Productos de higiene y limpieza", new DateTime(2025, 4, 18, 15, 38, 8, 64, DateTimeKind.Local).AddTicks(4720), "Limpieza" },
                    { 5, true, "Herramientas y artículos de construcción", new DateTime(2025, 4, 18, 15, 38, 8, 64, DateTimeKind.Local).AddTicks(4722), "Ferretería" },
                    { 6, true, "Equipos informáticos, celulares, accesorios", new DateTime(2025, 4, 18, 15, 38, 8, 64, DateTimeKind.Local).AddTicks(4723), "Tecnología" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
