using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Seeds;


namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsuarioPuesto>()
                .HasKey(up => new { up.UsuarioId, up.PuestoId });

            base.OnModelCreating(modelBuilder);
            //llamo ala funcion con  los datos de la clase UnidadesMedidasSeed
            modelBuilder.SeedUnidadesMedidas();
        }

        #region Definicion de DbSets
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
        #endregion
    }
}