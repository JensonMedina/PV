using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class ProductoMapping
    {
        public static Producto ToEntity(ProductoRequest request) => new()
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Marca = request.Marca,
            CategoriaId = request.CategoriaId,
            RubroId = request.RubroId,
            UnidadMedidaId = request.UnidadMedidaId,
            ImagenUrl = request.ImagenUrl,
            EsPrivado = request.EsPrivado,
            NegocioId = request.NegocioId
        };

        public static ProductoResponse ToResponse(Producto entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            Marca = entity.Marca,
            CategoriaId = entity.CategoriaId,
            Categoria = CategoriaMapping.ToResponse(entity.Categoria),
            RubroId = entity.RubroId,
            Rubro = RubroMapping.ToResponse(entity.Rubro),
            UnidadMedidaId = entity.UnidadMedidaId,
            UnidadMedida = UnidadMedidaMapping.ToResponse(entity.UnidadMedida),
            ImagenUrl = entity.ImagenUrl,
            EsPrivado = entity.EsPrivado,
            NegocioId = entity.NegocioId
        };
    }
}
