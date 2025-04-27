using Application.Common;
using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPuestoService
    {
        Task<PagedResponse<PuestoResponse>> GetAllAsync(int pageNumber, int pageSize);
        Task<PuestoResponse?> GetByIdAsync(int id);
        Task<PuestoResponse> AddAsync(PuestoRequest request);
        Task<PuestoResponse> UpdateAsync(int id, PuestoRequest request);
        Task DeleteAsync(int id);
    }
}
