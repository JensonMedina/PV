using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class HistoricoStockMapping
    {
        public static HistoricoStock ToEntity(HistoricoStockRequest request) => new()
        {
           //revisar
        };

        public static HistoricoStockResponse ToResponse(HistoricoStock entity) => new()
        {
           //revisar

        };

    }
}

    
