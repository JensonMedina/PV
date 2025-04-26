using Application.Models.Request;

namespace Application.Interfaces
{
    public interface INegocioService
    {
        Task Register(NegocioRequest newNegocio);
    }
}
