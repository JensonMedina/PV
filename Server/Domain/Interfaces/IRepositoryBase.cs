namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>> ListAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
        Task SoftDeleteAsync<TId>(TId id) where TId : notnull;
        Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull;
    }
}
