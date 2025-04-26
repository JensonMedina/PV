using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProveedorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _loggerApp;

        public ProveedorService(IUnitOfWork unitOfWork, ILoggerApp loggerApp)
        {
            _unitOfWork = unitOfWork;
            _loggerApp = loggerApp;
        }

        // Registrar un proveedor
        public async Task RegistrarProveedor(Proveedor proveedor)
        {
            // Desde unitOfWork con base
        }

        // Consultar proveedor por ID
        public async Task<Proveedor?> ConsultarProveedorPorId(int id)
        {
            // Desde unitOfWork con base
        }

        // Consultar proveedor por negocio
        public async Task<List<Proveedor>> ConsultarProveedorPorNegocio(string negocio)
        {
            // Desde unitOfWork con proveedor
        }

        // Consultar proveedor por rubro
        public async Task<List<Proveedor>> ConsultarProveedorPorRubro(string rubro)
        {
            // Desde unitOfWork con proveedor
        }

        // Eliminar proveedor
        public async Task EliminarProveedor(int id)
        {
            // Desde unitOfWork con base
        }

        // Modificar proveedor
        public async Task ModificarProveedor(int id, Proveedor proveedor)
        {
            // Desde unitOfWork con base
        }
    }
}
