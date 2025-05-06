using Domain.Interfaces;
namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriaRepository Categorias { get; }
        IClienteRepository Clientes { get; }
        ICompraDetalleRepository ComprasDetalles { get; }
        ICompraRepository Compras { get; }
        IComprobanteRepository Comprobantes { get; }
        IHistoricoPrecioRepository HistoricosPrecios { get; }
        IHistoricoStockRepository HistoricoStocks { get; }
        INegocioRepository Negocios { get; }
        IPlanSaasRepository PlanesSaas { get; }
        IProductoNegocioRepository ProductosNegocios { get; }
        IProductoRepository Productos { get; }
        IPuestoRepository Puestos { get; }
        IProveedorRepository Proveedores { get; }
        IProveedorNegocioRepository ProveedoresNegocio { get; }
        IRubroRepository Rubros { get; }
        IUnidadMedidaRepository UnidadesMedidas { get; }
        IUsuarioPuestoRepository UsuariosPuestos { get; }
        IUsuarioRepository Usuarios { get; }
        IVentaDetalleRepository VentasDetalles { get; }
        IVentaRepository Ventas { get; }
        IMedioPagoRepository MedioPagos { get; }
        Task<int> CompleteAsync(); // Guarda todos los cambios en una transacción
    }
}
