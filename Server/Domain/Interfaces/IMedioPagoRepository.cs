using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMedioPagoRepository : IRepositoryBase<MedioPago>
    {
        Task RegisterAsync(MedioPago newMedioPago);
    }
}
