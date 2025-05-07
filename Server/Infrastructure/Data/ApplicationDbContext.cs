using Domain.Entities;
using Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Claves compuestas
            modelBuilder.Entity<UsuarioPuesto>()
                .HasKey(up => new { up.UsuarioId, up.PuestoId });
            // Configuración de la relación muchos-a-muchos Negocio <-> Proveedor
            modelBuilder.Entity<ProveedorNegocio>()
                .HasKey(pn => new { pn.ProveedorId, pn.NegocioId });

            modelBuilder.Entity<ProveedorNegocio>()
                .HasOne(pn => pn.Proveedor)
                .WithMany(p => p.ProveedoresNegocio)
                .HasForeignKey(pn => pn.ProveedorId);

            modelBuilder.Entity<ProveedorNegocio>()
                .HasOne(pn => pn.Negocio)
                .WithMany(n => n.ProveedoresNegocio)
                .HasForeignKey(pn => pn.NegocioId);


            // Conversión de enums a int
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Tipo)
                .HasConversion<int>();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.TipoDocumento)
                .HasConversion<int>();

            // Configuración de RowVersion para MySQL
            modelBuilder.Entity<Usuario>()
                .Property(u => u.RowVersion)
                .HasColumnType("timestamp")
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            // Claves necesarias para Identity con claves int
            modelBuilder.Entity<IdentityUserLogin<int>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasKey(r => new { r.UserId, r.RoleId });

            modelBuilder.Entity<IdentityUserToken<int>>()
                .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            base.OnModelCreating(modelBuilder);

            #region DataSeeds
            modelBuilder.SeedUnidadesMedidas();
            modelBuilder.SeedRubros();
            modelBuilder.SeedPlanesSaas();

            #endregion
        }

        #region DbSets
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraDetalle> ComprasDetalles { get; set; }
        public DbSet<PlanSaas> PlanesSaas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<UnidadMedida> UnidadesMedidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPuesto> UsuariosPuestos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentasDetalles { get; set; }
        public DbSet<ProductoNegocio> ProductosNegocios { get; set; }
        public DbSet<HistoricoPrecio> HistoricosPrecios { get; set; }
        public DbSet<HistoricoStock> HistoricoStocks { get; set; }
        public DbSet<ProveedorNegocio> ProveedoresNegocios { get; set; }

<<<<<<< HEAD
        public DbSet<MedioPago> MediosPagos { get; set; }
=======
>>>>>>> PDVS-16-CRUD-para-Proveedores
        #endregion
    }
}