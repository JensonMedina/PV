namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync(); // Guarda todos los cambios en una transacción
    }
}
