namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>> ListAsync();
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
        void HardDeleteAsync(T entity);
        Task SoftDeleteAsync<TId>(TId id) where TId : notnull;
        Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull;
        Task<(IEnumerable<T> Items, int TotalCount)> GetPageAsync(int negocioId, int pageNumber, int pageSize, bool onlyActive = true);
    }
}