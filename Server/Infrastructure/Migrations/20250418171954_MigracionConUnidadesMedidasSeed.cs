using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionConUnidadesMedidasSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UnidadesMedidas",
                columns: new[] { "Id", "Abreviatura", "Activo", "Nombre", "TipoUnidadMedida" },
                values: new object[,]
                {
                    { 1, "u", true, "Unidad", 0 },
                    { 2, "pr", true, "Par", 1 },
                    { 3, "dz", true, "Docena", 2 },
                    { 4, "g", true, "Gramo", 3 },
                    { 5, "kg", true, "Kilogramo", 4 },
                    { 6, "mg", true, "Miligramo", 5 },
                    { 7, "t", true, "Tonelada", 6 },
                    { 8, "ml", true, "Mililitro", 7 },
                    { 9, "l", true, "Litro", 8 },
                    { 10, "m³", true, "Metro Cúbico", 9 },
                    { 11, "cm³", true, "Centímetro Cúbico", 10 },
                    { 12, "mm", true, "Milímetro", 11 },
                    { 13, "cm", true, "Centímetro", 12 },
                    { 14, "m", true, "Metro", 13 },
                    { 15, "km", true, "Kilómetro", 14 },
                    { 16, "m²", true, "Metro Cuadrado", 15 },
                    { 17, "cm²", true, "Centímetro Cuadrado", 16 },
                    { 18, "min", true, "Minuto", 17 },
                    { 19, "h", true, "Hora", 18 },
                    { 20, "d", true, "Día", 19 },
                    { 21, "sem", true, "Semana", 20 },
                    { 22, "mes", true, "Mes", 21 },
                    { 23, "caja", true, "Caja", 22 },
                    { 24, "paq", true, "Paquete", 23 },
                    { 25, "blst", true, "Blíster", 24 },
                    { 26, "fras", true, "Frasco", 25 },
                    { 27, "rll", true, "Rollo", 26 },
                    { 28, "tira", true, "Tira", 27 },
                    { 29, "serv", true, "Servicio", 28 },
                    { 30, "MB", true, "Megabyte", 29 },
                    { 31, "GB", true, "Gigabyte", 30 },
                    { 32, "TB", true, "Terabyte", 31 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
