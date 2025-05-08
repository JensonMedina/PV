using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comprobante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MotivoAnulacion = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TipoComprobante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlanesSaas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Costo = table.Column<double>(type: "double", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LimiteUsuarios = table.Column<int>(type: "int", nullable: true),
                    LimiteProductos = table.Column<int>(type: "int", nullable: true),
                    LimiteVentasMensuales = table.Column<int>(type: "int", nullable: true),
                    LimiteAlmacenamientoMB = table.Column<int>(type: "int", nullable: true),
                    AccesoFacturacion = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AccesoReportes = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AccesoSoportePrioritario = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AccesoPersonalizacion = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesSaas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UnidadesMedidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abreviatura = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUnidadMedida = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedidas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Negocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDocumento = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroDocumento = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Calle = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Altura = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Provincia = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RubroId = table.Column<int>(type: "int", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Moneda = table.Column<int>(type: "int", nullable: false),
                    UsaFacturacion = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    TipoFacturacion = table.Column<int>(type: "int", nullable: true),
                    PlanSaasId = table.Column<int>(type: "int", nullable: false),
                    DebitoAutomaticoActivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaProximoDebito = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negocios_PlanesSaas_PlanSaasId",
                        column: x => x.PlanSaasId,
                        principalTable: "PlanesSaas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Negocios_Rubros_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazonSocial = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDocumento = table.Column<int>(type: "int", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(150)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Provincia = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Web = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RubroId = table.Column<int>(type: "int", nullable: false),
                    LimiteCredito = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DiasPlazoPago = table.Column<int>(type: "int", nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(500)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedores_Rubros_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDocumento = table.Column<int>(type: "int", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NegocioId = table.Column<int>(type: "int", nullable: true),
                    AvatarUrl = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UltimoLogin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IpUltimoLogin = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RowVersion = table.Column<DateTime>(type: "timestamp", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDocumento = table.Column<int>(type: "int", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsEmpresa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Provincia = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    EsConsumidorFinal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LimiteCredito = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SaldoActual = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(500)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PuntosFidelidad = table.Column<int>(type: "int", nullable: true),
                    UltimaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    RubroId = table.Column<int>(type: "int", nullable: false),
                    UnidadMedidaId = table.Column<int>(type: "int", nullable: false),
                    EsPrivado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NegocioId = table.Column<int>(type: "int", nullable: true),
                    ImagenUrl = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_Rubros_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_UnidadesMedidas_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadesMedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DireccionIP = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DireccionMAC = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    TipoImpresora = table.Column<int>(type: "int", nullable: true),
                    ImpresoraConfigurada = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaConexion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puestos_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProveedoresNegocios",
                columns: table => new
                {
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FormaPago = table.Column<int>(type: "int", nullable: false),
                    DiasPlazoPago = table.Column<int>(type: "int", nullable: true),
                    FechaVencimientoPago = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Pagado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    ComprobanteId = table.Column<int>(type: "int", nullable: false),
                    ComprobanteAnulacionId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Observaciones = table.Column<string>(type: "varchar(500)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compras_Comprobante_ComprobanteAnulacionId",
                        column: x => x.ComprobanteAnulacionId,
                        principalTable: "Comprobante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compras_Comprobante_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComprasDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Peso = table.Column<double>(type: "double", nullable: true),
                    Importe = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprasDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductosNegocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PrecioCosto = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Moneda = table.Column<int>(type: "int", nullable: false),
                    GestionaStock = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: true),
                    StockMaximo = table.Column<int>(type: "int", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosNegocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosNegocios_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosNegocios_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosPuestos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PuestoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosPuestos", x => new { x.UsuarioId, x.PuestoId });
                    table.ForeignKey(
                        name: "FK_UsuariosPuestos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosPuestos_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AfectaCaja = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ComprobanteId = table.Column<int>(type: "int", nullable: false),
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DescuentoTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Impuestos = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FormaPago = table.Column<int>(type: "int", nullable: false),
                    ComprobanteAnulacionId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_AspNetUsers_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ventas_Comprobante_ComprobanteAnulacionId",
                        column: x => x.ComprobanteAnulacionId,
                        principalTable: "Comprobante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ventas_Comprobante_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistoricosPrecios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoNegocioId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosPrecios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricosPrecios_ProductosNegocios_ProductoNegocioId",
                        column: x => x.ProductoNegocioId,
                        principalTable: "ProductosNegocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistoricoStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoNegocioId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoStocks_ProductosNegocios_ProductoNegocioId",
                        column: x => x.ProductoNegocioId,
                        principalTable: "ProductosNegocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VentasDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Peso = table.Column<double>(type: "double", nullable: true),
                    Importe = table.Column<double>(type: "double", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentasDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentasDetalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Activo", "Descripcion", "FechaAlta", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Productos comestibles, bebidas alcohólicas y no alcohólicas", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alimentos y Bebidas" },
                    { 2, true, "Artículos eléctricos para el hogar", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electrodomésticos" },
                    { 3, true, "Ropa y accesorios de moda", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indumentaria" },
                    { 4, true, "Productos de higiene y limpieza", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpieza" },
                    { 5, true, "Herramientas y artículos de construcción", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferretería" },
                    { 6, true, "Equipos informáticos, celulares, accesorios", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecnología" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NegocioId",
                table: "AspNetUsers",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_NegocioId",
                table: "Clientes",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ComprobanteAnulacionId",
                table: "Compras",
                column: "ComprobanteAnulacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ComprobanteId",
                table: "Compras",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_NegocioId",
                table: "Compras",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorId",
                table: "Compras",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalles_ProductoId",
                table: "ComprasDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosPrecios_ProductoNegocioId",
                table: "HistoricosPrecios",
                column: "ProductoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoStocks_ProductoNegocioId",
                table: "HistoricoStocks",
                column: "ProductoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_MediosPagos_NegocioId",
                table: "MediosPagos",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_PlanSaasId",
                table: "Negocios",
                column: "PlanSaasId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_RubroId",
                table: "Negocios",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_NegocioId",
                table: "Productos",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_RubroId",
                table: "Productos",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UnidadMedidaId",
                table: "Productos",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosNegocios_NegocioId",
                table: "ProductosNegocios",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosNegocios_ProductoId",
                table: "ProductosNegocios",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_RubroId",
                table: "Proveedores",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresNegocios_NegocioId",
                table: "ProveedoresNegocios",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_NegocioId",
                table: "Puestos",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPuestos_PuestoId",
                table: "UsuariosPuestos",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ComprobanteAnulacionId",
                table: "Ventas",
                column: "ComprobanteAnulacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ComprobanteId",
                table: "Ventas",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpleadoId",
                table: "Ventas",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_NegocioId",
                table: "Ventas",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_PuestoId",
                table: "Ventas",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalles_ProductoId",
                table: "VentasDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalles_VentaId",
                table: "VentasDetalles",
                column: "VentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "ComprasDetalles");

            migrationBuilder.DropTable(
                name: "HistoricosPrecios");

            migrationBuilder.DropTable(
                name: "HistoricoStocks");

            migrationBuilder.DropTable(
                name: "MediosPagos");

            migrationBuilder.DropTable(
                name: "ProveedoresNegocios");

            migrationBuilder.DropTable(
                name: "UsuariosPuestos");

            migrationBuilder.DropTable(
                name: "VentasDetalles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ProductosNegocios");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Comprobante");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "UnidadesMedidas");

            migrationBuilder.DropTable(
                name: "Negocios");

            migrationBuilder.DropTable(
                name: "PlanesSaas");

            migrationBuilder.DropTable(
                name: "Rubros");
        }
    }
}
