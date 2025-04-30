using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPuestoRepository : IRepositoryBase<Puesto>
    {
        Task<Puesto?> GetById(int id, int negocioId);
        Task<Puesto?> GetByIp(string ip, int negocioId);
        Task<Puesto?> GetByMac(string mac, int negocioId);
    }
}
