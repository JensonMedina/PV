using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface INegocioService
    {
        Task Register(NegocioRequest newNegocio);
        Task Modify(NegocioModifiedRequest negocioRequest);
        Task<Negocio> ValidarNegocio(int id);
    }
}
