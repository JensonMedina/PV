using Application.Models.Request;
using Application.Models.Response;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class DomainToDtoProfile:Profile
    {
        public DomainToDtoProfile()
        
        {
            // ==== Request -> Domain ====
            CreateMap<RubroRequest, Rubro>();
            CreateMap<CategoriaRequest, Categoria>();
            CreateMap<UnidadMedidaRequest, UnidadMedida>();
            CreateMap<ProductoRequest, Producto>();
            CreateMap<ProductoNegocioRequest, ProductoNegocio>();
            CreateMap<VentaDetalleRequest, VentaDetalle>();
            CreateMap<VentaRequest, Venta>();
            CreateMap<CompraDetalleRequest, CompraDetalle>();
            CreateMap<CompraRequest, Compra>();
            CreateMap<ClienteRequest, Cliente>();
            CreateMap<ComprobanteRequest, Comprobante>();
            CreateMap<HistoricoPrecioRequest, HistoricoPrecio>();
            CreateMap<HistoricoStockRequest, HistoricoStock>();
            CreateMap<NegocioRequest, Negocio>();
            CreateMap<PlanSaasRequest, PlanSaas>();
            CreateMap<ProveedorRequest, Proveedor>();
            CreateMap<PuestoRequest, Puesto>();
            CreateMap<UsuarioRequest, Usuario>();

            // ==== Domain -> Response ====
            CreateMap<Rubro, RubroResponse>();
            CreateMap<Categoria, CategoriaResponse>();
            CreateMap<UnidadMedida, UnidadMedidaResponse>();
            CreateMap<Producto, ProductoResponse>();
            CreateMap<ProductoNegocio, ProductoNegocioResponse>();
            CreateMap<VentaDetalle, VentaDetalleResponse>();
            CreateMap<Venta, VentaResponse>();
            CreateMap<CompraDetalle, CompraDetalleResponse>();
            CreateMap<Compra, CompraResponse>();
            CreateMap<Cliente, ClienteResponse>();
            CreateMap<Comprobante, ComprobanteResponse>();
            CreateMap<HistoricoPrecio, HistoricoPrecioResponse>();
            CreateMap<HistoricoStock, HistoricoStockResponse>();
            CreateMap<Negocio, NegocioResponse>();
            CreateMap<PlanSaas, PlanSaasResponse>();
            CreateMap<Proveedor, ProveedorResponse>();
            CreateMap<Puesto, PuestoResponse>();
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}
