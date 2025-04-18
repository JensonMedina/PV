using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionRelacionClienteNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NegocioId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_NegocioId",
                table: "Clientes",
                column: "NegocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Negocios_NegocioId",
                table: "Clientes",
                column: "NegocioId",
                principalTable: "Negocios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "NegocioId",
               table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_NegocioId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Negocios_NegocioId",
                table: "Clientes");
        }
    }
}
