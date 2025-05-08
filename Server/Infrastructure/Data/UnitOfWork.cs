using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    #region Instancia Interfaces de Repositorios
    public ICategoriaRepository Categorias { get; }
    public IClienteRepository Clientes { get; }
    public ICompraDetalleRepository ComprasDetalles { get; }
    public ICompraRepository Compras { get; }
    public IComprobanteRepository Comprobantes { get; }
    public IHistoricoPrecioRepository HistoricosPrecios { get; }
    public IHistoricoStockRepository HistoricoStocks { get; }
    public INegocioRepository Negocios { get; }
    public IPlanSaasRepository PlanesSaas { get; }
    public IProductoNegocioRepository ProductosNegocios { get; }
    public IProductoRepository Productos { get; }
    public IPuestoRepository Puestos { get; }
    public IProveedorRepository Proveedores { get; }
    public IProveedorNegocioRepository ProveedoresNegocio { get; }
    public IRubroRepository Rubros { get; }
    public IUnidadMedidaRepository UnidadesMedidas { get; }
    public IUsuarioPuestoRepository UsuariosPuestos { get; }
    public IUsuarioRepository Usuarios { get; }
    public IVentaDetalleRepository VentasDetalles { get; }
    public IVentaRepository Ventas { get; }
    public IMedioPagoRepository MedioPagos { get; }

    #endregion
    public UnitOfWork(ApplicationDbContext context, IProveedorRepository proveedores, IProveedorNegocioRepository proveedoresNegocio, IClienteRepository clientes, INegocioRepository negocios, IMedioPagoRepository medioPagos, IRubroRepository rubros, IPlanSaasRepository planesSaas, IPuestoRepository puestos)
    {
        _context = context;
        #region inyeccion repositorios
        Negocios = negocios;
        Rubros = rubros;
        PlanesSaas = planesSaas;
        MedioPagos = medioPagos;
        Puestos = puestos;
        Clientes = clientes;
        Proveedores = proveedores;
        ProveedoresNegocio = proveedoresNegocio;
        #endregion
    }


    //Todos se guardarían en un único SaveChanges.
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
