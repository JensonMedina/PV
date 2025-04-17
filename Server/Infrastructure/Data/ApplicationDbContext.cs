using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



        #region Definicion de DbSets
        
        #endregion
    }
}