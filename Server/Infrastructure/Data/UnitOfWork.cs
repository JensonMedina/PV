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
    public IRubroRepository Rubros { get; }
    public IUnidadMedidaRepository UnidadesMedidas { get; }
    public IUsuarioPuestoRepository UsuariosPuestos { get; }
    public IUsuarioRepository Usuarios { get; }
    public IVentaDetalleRepository VentasDetalles { get; }
    public IVentaRepository Ventas { get; }
    #endregion
    public UnitOfWork(ApplicationDbContext context, INegocioRepository negocioRepository)
    {
        _context = context;
        #region inyeccion repositorios
        Categorias = new CategoriaRepository(_context);
        Clientes = new ClienteRepository(_context);
        ComprasDetalles = new CompraDetalleRepository(_context);
        Compras = new CompraRepository(_context);
        Comprobantes = new ComprobanteRepository(_context);
        HistoricosPrecios = new HistoricoPrecioRepository(_context);
        HistoricoStocks = new HistoricoStockRepository(_context);
        Negocios = negocioRepository;
        PlanesSaas = new PlanSaasRepository(_context);
        ProductosNegocios = new ProductoNegocioRepository(_context);
        Productos = new ProductoRepository(_context);
        Proveedores = new ProveedorRepository(_context);
        Puestos = new PuestoRepository(_context);
        Rubros = new RubroRepository(_context);
        UnidadesMedidas = new UnidadMedidaRepository(_context);
        UsuariosPuestos = new UsuarioPuestoRepository(_context);
        Usuarios = new UsuarioRepository(_context);
        VentasDetalles = new VentaDetalleRepository(_context);
        Ventas = new VentaRepository(_context);
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
