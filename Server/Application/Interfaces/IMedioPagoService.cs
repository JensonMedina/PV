using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMedioPagoService
    {
        Task Register(MedioPagoRequest newMedioPago, Negocio negocio);
    }
}
