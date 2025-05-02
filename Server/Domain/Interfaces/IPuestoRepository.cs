using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPuestoRepository : IRepositoryBase<Puesto>
    {
        Task<Puesto?> GetById(int id, int negocioId);
        Task<bool> GetByIp(string ip);
        Task<bool> GetByMac(string mac);
    }
}
