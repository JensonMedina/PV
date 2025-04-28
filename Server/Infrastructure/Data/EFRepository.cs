using Application.Interfaces;

namespace Infrastructure.Data
{
    public class EFRepository<T> : RepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ILoggerApp _logger;
        
        public EFRepository(ApplicationDbContext context, ILoggerApp logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}