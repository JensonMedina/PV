using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionConModificacionModeloDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CodigoBarras",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "FechaVencimiento",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "GestionaStock",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IncluyeImpuestos",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Margen",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Moneda",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PrecioCosto",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PrecioVenta",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "StockMaximo",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "TieneVencimiento",
                table: "Productos",
                newName: "EsPrivado");

            migrationBuilder.RenameColumn(
                name: "StockMinimo",
                table: "Productos",
                newName: "NegocioId");

            migrationBuilder.RenameColumn(
                name: "StockActual",
                table: "Productos",
                newName: "RubroId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_NegocioId",
                table: "Productos",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_RubroId",
                table: "Productos",
                column: "RubroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Negocios_NegocioId",
                table: "Productos",
                column: "NegocioId",
                principalTable: "Negocios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Rubros_RubroId",
                table: "Productos",
                column: "RubroId",
                principalTable: "Rubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Negocios_NegocioId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Rubros_RubroId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_NegocioId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_RubroId",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "RubroId",
                table: "Productos",
                newName: "StockActual");

            migrationBuilder.RenameColumn(
                name: "NegocioId",
                table: "Productos",
                newName: "StockMinimo");

            migrationBuilder.RenameColumn(
                name: "EsPrivado",
                table: "Productos",
                newName: "TieneVencimiento");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Productos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Productos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CodigoBarras",
                table: "Productos",
                type: "varchar(50)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimiento",
                table: "Productos",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GestionaStock",
                table: "Productos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncluyeImpuestos",
                table: "Productos",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Margen",
                table: "Productos",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Moneda",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioCosto",
                table: "Productos",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioVenta",
                table: "Productos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowVersion",
                table: "Productos",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<int>(
                name: "StockMaximo",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }
    }
}
