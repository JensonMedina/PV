using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync(); // Guarda todos los cambios en una transacción
    }
}
