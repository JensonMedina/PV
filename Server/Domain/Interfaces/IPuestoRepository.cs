using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPuestoRepository : IRepositoryBase<Puesto>
    {
        Task<Puesto?> GetById(int id, int negocioId);
        Task<Puesto?> GetByIp(string ip);
        Task<Puesto?> GetByMac(string mac);
    }
}
